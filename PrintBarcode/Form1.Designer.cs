namespace WindowsForms_CS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.tipoPrueba = new System.Windows.Forms.ComboBox();
            this.folioInicial = new System.Windows.Forms.TextBox();
            this.imprimir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.folioFinal = new System.Windows.Forms.TextBox();
            this.msj = new System.Windows.Forms.Label();
            this.previa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // tipoPrueba
            // 
            this.tipoPrueba.FormattingEnabled = true;
            this.tipoPrueba.Items.AddRange(new object[] {
            "Matemáticas",
            "Física",
            "Química"});
            this.tipoPrueba.Location = new System.Drawing.Point(93, 33);
            this.tipoPrueba.Name = "tipoPrueba";
            this.tipoPrueba.Size = new System.Drawing.Size(167, 21);
            this.tipoPrueba.TabIndex = 4;
            // 
            // folioInicial
            // 
            this.folioInicial.Location = new System.Drawing.Point(93, 72);
            this.folioInicial.Name = "folioInicial";
            this.folioInicial.Size = new System.Drawing.Size(167, 20);
            this.folioInicial.TabIndex = 5;
            // 
            // imprimir
            // 
            this.imprimir.Location = new System.Drawing.Point(46, 176);
            this.imprimir.Name = "imprimir";
            this.imprimir.Size = new System.Drawing.Size(75, 23);
            this.imprimir.TabIndex = 6;
            this.imprimir.Text = "Imprimir";
            this.imprimir.UseVisualStyleBackColor = true;
            this.imprimir.Click += new System.EventHandler(this.imprimir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tipo Prueba";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Folio inicial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Folio final";
            // 
            // folioFinal
            // 
            this.folioFinal.Location = new System.Drawing.Point(93, 108);
            this.folioFinal.Name = "folioFinal";
            this.folioFinal.Size = new System.Drawing.Size(167, 20);
            this.folioFinal.TabIndex = 10;
            // 
            // msj
            // 
            this.msj.AutoSize = true;
            this.msj.ForeColor = System.Drawing.SystemColors.InfoText;
            this.msj.Location = new System.Drawing.Point(32, 150);
            this.msj.Name = "msj";
            this.msj.Size = new System.Drawing.Size(0, 13);
            this.msj.TabIndex = 12;
            // 
            // previa
            // 
            this.previa.Location = new System.Drawing.Point(153, 176);
            this.previa.Name = "previa";
            this.previa.Size = new System.Drawing.Size(75, 23);
            this.previa.TabIndex = 13;
            this.previa.Text = "Vista Previa";
            this.previa.UseVisualStyleBackColor = true;
            this.previa.Click += new System.EventHandler(this.previa_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 246);
            this.Controls.Add(this.previa);
            this.Controls.Add(this.msj);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.folioFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imprimir);
            this.Controls.Add(this.folioInicial);
            this.Controls.Add(this.tipoPrueba);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ComboBox tipoPrueba;
        private System.Windows.Forms.TextBox folioInicial;
        private System.Windows.Forms.Button imprimir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox folioFinal;
        private System.Windows.Forms.Label msj;
        private System.Windows.Forms.Button previa;
    }
}