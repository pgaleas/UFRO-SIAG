using CoreScanner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using System.Data.OleDb;
using System.Resources;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class EliminarRegistro : Form
    {
        private Boolean buscarPorRut = false;
        DatabaseManager dbmanager = new DatabaseManager();
        Visualizador mainForm;
        
        //Inicialiaz, y modifica las etiquetas de la ventana EliminarRegistro
        public EliminarRegistro(Visualizador mainForm, bool buscarPorRut)
        {
            this.buscarPorRut = buscarPorRut;
            this.mainForm = mainForm;
            InitializeComponent();
            //Cambia las etiquetas
            if (buscarPorRut)
            {
                label1.Text = "RUT";
            }
            else
            {
                label1.Text = "FOLIO";
            }
            
        }

        //Evento al clickear el boton buscar
        private void botonBuscar_Click(object sender, EventArgs e)
        {
            Buscador();
        }

        //Evento al clickear el boton Limpiar Formulario
        private void botonLimpiaForm_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }


        //Evento al clickear el boton Eliminar Registro
        private void botonEliminarRegistro_Click(object sender, EventArgs e)
        {
                String rut = textRut.Text;
                //Elimina el registro de la base de datos
                dbmanager.ElimRegistro(rut);
                //Limpia el formulario
                LimpiarDatos();
                //Actualiza la tabla de la ventana principal
                dbmanager.readLastRegisters(mainForm.dataGridView1);      
                       
            
        }

        //Limpia el formulario
        private void LimpiarDatos()
        {
            textDato.Clear();
            textRut.Clear();
            textNombre.Clear();
            textFolio.Clear();
        }

        private void EliminarRegistro_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        //Evento al apretar enter con el puntero en el campo de rut/folio
        private void textDato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Buscador();

            }          
        }
        //Busca el registro en la base de datos y lo muestra en el formulario
        public void Buscador()
        {
            String dato = textDato.Text;
            String[] datos;
            //Si buscará el registro a través del rut
            if (buscarPorRut)
            {
                datos = dbmanager.buscarPorRut(dato);
            }
            //Si buscará el registro a través del folio
            else
            {
                datos = dbmanager.buscarPorFolio(dato);
            }
            //Escribe los datos encontrados en los campos del formulario
            textRut.Text = datos[0];
            textNombre.Text = datos[1];
            textFolio.Text = datos[2];
        }

        

        

    }

}
