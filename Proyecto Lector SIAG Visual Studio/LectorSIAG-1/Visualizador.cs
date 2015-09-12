using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CoreScanner;
using System.Xml;
using System.Data.OleDb;
using System.Resources;
using System.Configuration;


namespace WindowsFormsApplication1
{
    public partial class Visualizador : Form
    {

        // Manejador de la base de datos
        static DatabaseManager dbManager = new DatabaseManager();

        static CCoreScanner cCoreScannerClass;


        //Estados de lectura del Scanner
        public bool rut_leido = false;
        public bool folio_leido = false;


        // Crea un Resource manager para manejar imágenes
        public static ResourceManager resourceManager; //I prefer the ResourceManager to be static


        // Crea un objeto de tipo BardataObject para almacenar temporalmente los codigos de barras leidos
        public BarcodeDataObject barcodeData = new BarcodeDataObject();



        public Visualizador()
        {
            InitializeComponent();
            dbManager.readLastRegisters(dataGridView1);
            this.Text = "Lector SIAG - Prueba " + ConfigurationManager.AppSettings["table"].ToString();
            
        }


        // Inicializa las variables de estado (Flags)
        private void initializeFlags()
        {
            rut_leido = false;
            folio_leido = false;

            this.Invoke((MethodInvoker)delegate { textRut.Text = ""; });
            this.Invoke((MethodInvoker)delegate { pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.scanner_white; });
            this.Invoke((MethodInvoker)delegate { textBoxFolio.Text = ""; });
            this.Invoke((MethodInvoker)delegate { pictureBox2.Image = global::WindowsFormsApplication1.Properties.Resources.scanner_white; });
        }

        


        // Setea un objeto con los datos escaneados
        private void SetBarcodeDataObjetc(string strXml)
        {
            //System.Diagnostics.Debug.WriteLine("Initial XML" + strXml);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(strXml);

            string strData = String.Empty;
            string serialnumber = xmlDoc.DocumentElement.GetElementsByTagName("serialnumber").Item(0).InnerText;
            string barcode = xmlDoc.DocumentElement.GetElementsByTagName("datalabel").Item(0).InnerText;
            string codetype = xmlDoc.DocumentElement.GetElementsByTagName("datatype").Item(0).InnerText;
            string[] numbers = barcode.Split(' ');

            foreach (string number in numbers)
            {
                if (String.IsNullOrEmpty(number))
                {
                    break;
                }

                strData += ((char)Convert.ToInt32(number, 16)).ToString();
            }

            barcodeData.ReaderSerial = serialnumber;
            barcodeData.BarType = codetype;
            barcodeData.BarData = strData;

        }


        /* Evento lanzado cuando se lee un código de barras, independientemente si es el Rut o el Folio  * */
        void OnBarcodeEvent(short eventType, ref string pscanData)
        {

            // Setea los valores del objeto que contiene la informacion escaneada
            SetBarcodeDataObjetc(pscanData);

            if (barcodeData != null)
            {

                // Si codigo leido es el Rut
                if (barcodeData.BarType.Trim().Equals("17") || barcodeData.BarType.Trim().Equals("0"))
                {

                    if (rut_leido == false) // SE LEE EL RUT POR PRIMERA VEZ
                    {
                        // Comprueba con el digito verificador
                        CI_Code ciCode = new CI_Code(barcodeData.BarData.Trim(), barcodeData.BarType.Trim());
                        if (ciCode.RutError == true)
                        {

                            // Envia señal audible de error al Scanner

                            // Define el mensaje de error en la barra de Status
                            updateStatus(2, "ERROR: El codigo de barra del Rut presenta errores.");

                            // Resetea Flags y Formulario
                            initializeFlags();

                            return;
                        }
                        else
                        {
                            rut_leido = true;

                            // Define el Rut y el Nombre del estudiante en el objeto Barcode
                            barcodeData.Rut = ciCode.Rut;
                            barcodeData.StudentName = ciCode.Name;

                            // Setea el Rut en el formulario
                            this.Invoke((MethodInvoker)delegate { textRut.Text = ciCode.Rut; });

                            // Setea el imagen_OK en el Rut del formulario
                            this.Invoke((MethodInvoker)delegate { pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.scanner_green; });

                            // Define el mensaje de Rut ingresado en la barra de Status
                            updateStatus(0, "El RUT fue leido exitosamente");

                        }


                    }
                    else // ERROR : SE LEE EL RUT POR SEGUNDA VEZ
                    {
                        // Aqui intercatuar con el formulario (Resetear)

                        // Aqui Resetear flags
                        initializeFlags();


                        // Define el mensaje de error en la barra de Status
                        updateStatus(2, "ERROR: el RUT fue leido por segunda vez.     ... Ingrese nuevamente los datos");

                        return;
                    }

                }
                else
                {
                    if (folio_leido == false) // PRIMERA LECTURA DEL FOLIO
                    {
                        folio_leido = true;
                        barcodeData.ResponseFormId = barcodeData.BarData.Trim();

                        // Actualizar el formulario (Setear FOlio)
                        this.Invoke((MethodInvoker)delegate { textBoxFolio.Text = barcodeData.BarData.Trim(); });
                        this.Invoke((MethodInvoker)delegate { pictureBox2.Image = global::WindowsFormsApplication1.Properties.Resources.scanner_green; });

                        // Define el mensaje de folio ingresado en la barra de Status
                        updateStatus(0, "El FOLIO fue leido exitosamente");

                    }
                    else // ERROR : SE LEE EL FOLIO POR SEGUNDA VEZ
                    {

                        // Define el mensaje de error en la barra de Status
                        updateStatus(2, "ERROR: el FOLIO fue leido por segunda vez.     ... Ingrese nuevamente los datos");

                        // Inicializa Flags
                        initializeFlags();

                        return;
                    }


                }


                // GRABA CODIGOS EN LA BASE DE DATOS
                // Si los datos estan completos, graba el objeto en la base de datos
                checkAndSave();


            }
            else
            {
                MessageBox.Show("Error de lectura de códigos");

            }

        }


        // GRABA CODIGOS EN LA BASE DE DATOS
        // Si los datos estan completos, graba el objeto en la base de datos
        public void checkAndSave()
        {
            if (folio_leido == true && rut_leido == true)
            {

                // Guarda los datos en la BD 
                bool saveOK = dbManager.saveRegisterMySql(barcodeData, this);

                // Carga los primeros registros de la BD en la tabla del formulario
                bool updateTable = dbManager.readLastRegisters(dataGridView1);



                initializeFlags();
            }
        }





        // Inicializa el Scanner
        private void initializeScanner()
        {
            try
            {
                //Instantiate CoreScanner Class
                cCoreScannerClass = new CCoreScanner();
                //Call Open API
                short[] scannerTypes = new short[1];//Scanner Types you are interested in
                scannerTypes[0] = 1; // 1 for all scanner types
                short numberOfScannerTypes = 1; // Size of the scannerTypes array
                int status; // Extended API return code
                cCoreScannerClass.Open(0, scannerTypes, numberOfScannerTypes, out status);
                // Subscribe for barcode events in cCoreScannerClass
                cCoreScannerClass.BarcodeEvent += new
                _ICoreScannerEvents_BarcodeEventEventHandler(OnBarcodeEvent);
                // Let's subscribe for events
                int opcode = 1001; // Method for Subscribe events
                string outXML; // XML Output
                string inXML = "<inArgs>" +
                "<cmdArgs>" +
                "<arg-int>1</arg-int>" + // Number of events you want to subscribe
                "<arg-int>1</arg-int>" + // Comma separated event IDs
                "</cmdArgs>" +
                "</inArgs>";
                cCoreScannerClass.ExecCommand(opcode, ref inXML, out outXML, out status);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error de conexión con el Scanner... " + exp.Message);
            }

        }


        // Define un mensaje audible en el scanner
        private void soundScanner(int soundtype)
        {
            try
            {
                string soundCommand;

                switch (soundtype)
                {
                    case 0: // no emite sonido
                        return;
                    case 1: // sonido de OK
                        soundCommand = "5"; // 1 low short beep
                        break;
                    case 2: // sonido de ERROR
                        soundCommand = "3"; // 4 high short beep pattern
                        break;
                    default:  // no emite sonido
                        return;
                }



                //Call Open API
                short[] scannerTypes = new short[1]; // Scanner Types you are interested in
                scannerTypes[0] = 1; // 1 for all scanner types
                short numberOfScannerTypes = 1; // Size of the scannerTypes array
                int status; // Extended API return code
                cCoreScannerClass.Open(0, scannerTypes, numberOfScannerTypes, out status);
                // Let's beep the beeper
                int opcode = 6000; // Method for Beep the beeper
                string outXML; // Output
                string inXML = "<inArgs>" +
                "<scannerID>1</scannerID>" + // The scanner you need to beep
                "<cmdArgs>" +
                "<arg-int>" + soundCommand + "</arg-int>" + // 4 high short beep pattern
                "</cmdArgs>" +
                "</inArgs>";
                cCoreScannerClass.ExecCommand(opcode, ref inXML, out outXML, out status);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error de conexión con el Scanner... " + exp.Message);
            }

        }


        // Actualiza la barra inferior de mensajes y envia un mensaje de sonido
        public void updateStatus(int messagetype, string message)
        {
            this.Invoke((MethodInvoker)delegate { textBox4.Text = message; });
            soundScanner(messagetype);
        }

        private void Visualizador_Load(object sender, EventArgs e)
        {
            initializeScanner();
        }

        //Abre la ventana de InsertarRut al clickear el boton Insertar Manual
        private void button2_Click(object sender, EventArgs e)
        {
            InsertarRut subForm = new InsertarRut(this);
            subForm.Show();
        }
        //Evento al clickear el boton actualizar, refresca la tabla
        private void button1_Click(object sender, EventArgs e)
        {
            // Carga los primeros registros de la BD en la tabla del formulario
            bool updateTable = dbManager.readLastRegisters(dataGridView1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        /*
        private void buttonInsertFolio_Click(object sender, EventArgs e)
        {
            InsertarFolio subForm = new InsertarFolio(this);
            subForm.Show();
        }*/

        //Abre la ventana InsertarFolio al clickear el boton insertar manual
        private void buttonInsertFolio_Click_1(object sender, EventArgs e)
        {
            InsertarFolio subForm = new InsertarFolio(this);
            subForm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Muestra la ventana de Eliminar registros por RUT presente en la barra menú
        private void eliminarPorRUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                //Revisa todas las ventanas abiertas
                foreach (Form existe in Application.OpenForms)
                {   
                    //Si encuentra otra ventana EliminarRegistro abierta, la cierra
                    if (existe.GetType() == typeof(EliminarRegistro))
                    {
                        existe.Close();
                    }
                }
            }
            catch (Exception ex)
            {
            }
                //Crea y abre una ventana EliminarRegistro
                EliminarRegistro elimPorRut = new EliminarRegistro(this,true);
                elimPorRut.Show();
                                          
                        
        }
        //Actualiza la tabla con los registros de la BD
        private void ActualizarTabla()
        {
            dbManager.readLastRegisters(dataGridView1);
        }

        //Evento al clickear el boton actualizar
        private void button1_Click_1(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void textBoxFolio_TextChanged(object sender, EventArgs e)
        {

        }

        //Muestra la ventana de Eliminar registros por FOLIO presente en la barra menú
        private void buscarPorFolioToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
            
            
            try
            {
                //Revisa todas las ventanas abiertas
                foreach (Form existe in Application.OpenForms)
                {
                    //Si encuentra otra ventana EliminarRegistro abierta, la cierra
                    if (existe.GetType() == typeof(EliminarRegistro))
                    {
                        existe.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            //Crea y abre una ventana EliminarRegistro
            EliminarRegistro elimPorFolio = new EliminarRegistro(this,false);
            elimPorFolio.Show();
                
                       
        }
    }
}
