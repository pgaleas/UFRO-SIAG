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
    public partial class InsertarFolio : Form
    {

        Visualizador mainForm;

        //Inicializa la ventana para ingresar el folio de forma manual
        public InsertarFolio(Visualizador mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        //Evento al clickear el boton aceptar
        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            mainForm.folio_leido = true;

            mainForm.barcodeData.ResponseFormId = this.textBoxFolio.Text;

            // Setea el Folio en el formulario
            this.Invoke((MethodInvoker)delegate { mainForm.textBoxFolio.Text = this.textBoxFolio.Text; });

            // Setea el imagen_OK en el Rut del formulario
            this.Invoke((MethodInvoker)delegate { mainForm.pictureBox2.Image = global::WindowsFormsApplication1.Properties.Resources.scanner_green; });

            // Define el mensaje de Rut ingresado en la barra de Status
            mainForm.updateStatus(0, "El FOLIO fue leido exitosamente");


            // Si los datos estan completos, graba el objeto en la base de datos
            mainForm.checkAndSave();

            textBoxFolio.Text = "";
            //Esconde la ventana
            this.Hide();
        }

        //Evento al clickear el boton cancelar
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            textBoxFolio.Text = "";
            //Cierra la ventana
            this.Close();
        }

        //Evento al apretar enter con el puntero en el campo de folio
        private void textBoxFolio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                mainForm.folio_leido = true;

                mainForm.barcodeData.ResponseFormId = this.textBoxFolio.Text;

                // Setea el Folio en el formulario
                this.Invoke((MethodInvoker)delegate { mainForm.textBoxFolio.Text = this.textBoxFolio.Text; });

                // Setea el imagen_OK en el Rut del formulario
                this.Invoke((MethodInvoker)delegate { mainForm.pictureBox2.Image = global::WindowsFormsApplication1.Properties.Resources.scanner_green; });

                // Define el mensaje de Rut ingresado en la barra de Status
                mainForm.updateStatus(0, "El FOLIO fue leido exitosamente");


                // Si los datos estan completos, graba el objeto en la base de datos
                mainForm.checkAndSave();

                textBoxFolio.Text = "";
                this.Hide();
            }
        }
    }
}
