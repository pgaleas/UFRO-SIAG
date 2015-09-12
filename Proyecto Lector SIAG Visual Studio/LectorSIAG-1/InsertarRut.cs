using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class InsertarRut : Form
    {
        Visualizador mainForm;

        //Inicializa la ventana
        public InsertarRut(Visualizador mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        //Evento al apretar el boton OK
        private void okButton_Click(object sender, EventArgs e)
        {
            checkAndSave();
        }

        //Evento al apretar el boton Cancelar
        private void CancelButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            //cierra la ventana
            this.Close();
        }


        //Copia el rut ingresado en el campo de rut de la ventana principal
        private void checkAndSave()
        {
            //Copia el texto ingresado en el formulario y añade codigo de rut

            CI_Code ciCode = new CI_Code(textBox1.Text, "17");

            //Si el dato ingresado no corresponde a un rut
            if (ciCode.RutError == true)
            {
                MessageBox.Show("Rut inválido !!");
                textBox1.Select(0, textBox1.TextLength);
            }
            //Si corresponde a un rut
            else
            {

                mainForm.rut_leido = true;

                // Define el Rut y el Nombre del estudiante en el onjeto Barcode
                mainForm.barcodeData.Rut = ciCode.Rut;
                mainForm.barcodeData.StudentName = "";

                // Setea el Rut en el formulario
                this.Invoke((MethodInvoker)delegate { mainForm.textRut.Text = ciCode.Rut; });

                // Setea el imagen_OK en el Rut del formulario
                this.Invoke((MethodInvoker)delegate { mainForm.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.scanner_green; });

                // Define el mensaje de Rut ingresado en la barra de Status
                mainForm.updateStatus(0, "El RUT fue leido exitosamente");


                // Si los datos estan completos, graba el objeto en la base de datos
                mainForm.checkAndSave();

                textBox1.Text = "";
                this.Hide();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        //Evento al apretar Enter con el puntero en el campo de rut
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                checkAndSave();
            }
        }

    }
}
