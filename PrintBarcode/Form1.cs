using System;
using System.Drawing;
using System.Windows.Forms;
using System.Web.UI;

using Limilabs.Barcode;

namespace WindowsForms_CS
{
    public partial class Form1 : Form
    {
        private long numeroHoja = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            
            e.Graphics.PageUnit = GraphicsUnit.Pixel;
            
            
            BaseBarcode b = BarcodeFactory.GetBarcode(Symbology.EAN13);
            int opcion = tipoPrueba.SelectedIndex;
            String numero = "";
            switch (opcion)
            {
                case 0: //Matemática
                    e.Graphics.DrawString("", new Font("Times New Roman", 18, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(CentimetersToPixels(6.0, e.Graphics.DpiX), CentimetersToPixels(0.7, e.Graphics.DpiY)));
                    numero += "100000";
                    break;
                case 1: // Física
                    e.Graphics.DrawString("", new Font("Times New Roman", 18, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(CentimetersToPixels(6.0, e.Graphics.DpiX), CentimetersToPixels(0.7, e.Graphics.DpiY)));
                    numero += "200000";
                    break;
                case 2: //Química
                    e.Graphics.DrawString("", new Font("Times New Roman", 18, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(CentimetersToPixels(6.0, e.Graphics.DpiX), CentimetersToPixels(0.7, e.Graphics.DpiY)));
                    numero += "300000";
                    break;
                default:
                    numero += "999999";
                    break;
            }

            // Formatea 
            b.Number = numero +  String.Format("{0:000000}", numeroHoja);      
            
            b.ChecksumAdd = true;
            b.Rotation = RotationType.Degrees270;

            b.Height = CentimetersToPixels(2.5, e.Graphics.DpiY);           // 2.5 cm
            b.NarrowBarWidth = CentimetersToPixels(0.05, e.Graphics.DpiX);  // 0.05 cm = 0.5 mm

            b.Render(e.Graphics,
                CentimetersToPixels(17.0, e.Graphics.DpiX),
                CentimetersToPixels(18.0, e.Graphics.DpiY));
            if (numeroHoja < Convert.ToInt64(folioFinal.Text))
            {
                e.HasMorePages = true;
                numeroHoja++;
            }
            else
            {
                e.HasMorePages = false;
            }
            
        }

        private static int InchesToPixels(double inches, double dpi)
        {
            return (int)(dpi * inches);
        }

        private static int CentimetersToPixels(double centimeters, double dpi)
        {
            return (int)(dpi * CentimetersToInches(centimeters));
        }

        private static double CentimetersToInches(double d)
        {
            return d / 2.54;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }



        private void imprimir_Click(object sender, EventArgs e)
        {
            if (this.validarImpresion())
            {
                this.printDocument1.Print();
            }
        }

        private void previa_Click(object sender, EventArgs e)
        {
            if (this.validarImpresion())
            {
                this.printPreviewDialog1.ShowDialog();
            }
        }

        public Boolean validarImpresion()
        {
            try
            {
                this.numeroHoja = Convert.ToInt64(folioInicial.Text);

                if (numeroHoja > Convert.ToInt64(folioFinal.Text))
                {
                    msj.Text = "Folio inicial es mayos que folio final";
                    msj.ForeColor = Color.Red;
                }
                else if (tipoPrueba.SelectedIndex == -1)
                {
                    msj.Text = "Debe seleccionar un tipo de prueba";
                    msj.ForeColor = Color.Red;
                }
                else
                {
                    msj.Text = "";
                    //this.printPreviewDialog1.ShowDialog();
                    //this.printDocument1.Print();
                    return true;
                }
            }
            catch (FormatException exp)
            {
                msj.Text = "Folio inicial o folio final no son numeros enteros";
                msj.ForeColor = Color.Red;
            }
            return false;
        }

    };
}