namespace WindowsFormsApplication1
{
    partial class EliminarRegistro
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textDato = new System.Windows.Forms.TextBox();
            this.textRut = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.textFolio = new System.Windows.Forms.TextBox();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.botonLimpiaForm = new System.Windows.Forms.Button();
            this.botonEliminarRegistro = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "RUT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "RUT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "NOMBRE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "FOLIO";
            // 
            // textDato
            // 
            this.textDato.Location = new System.Drawing.Point(120, 28);
            this.textDato.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textDato.Name = "textDato";
            this.textDato.Size = new System.Drawing.Size(273, 22);
            this.textDato.TabIndex = 4;
            this.textDato.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textDato.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDato_KeyPress);
            // 
            // textRut
            // 
            this.textRut.Location = new System.Drawing.Point(120, 118);
            this.textRut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textRut.Name = "textRut";
            this.textRut.ReadOnly = true;
            this.textRut.Size = new System.Drawing.Size(273, 22);
            this.textRut.TabIndex = 5;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(120, 151);
            this.textNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textNombre.Name = "textNombre";
            this.textNombre.ReadOnly = true;
            this.textNombre.Size = new System.Drawing.Size(273, 22);
            this.textNombre.TabIndex = 6;
            // 
            // textFolio
            // 
            this.textFolio.Location = new System.Drawing.Point(120, 181);
            this.textFolio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textFolio.Name = "textFolio";
            this.textFolio.ReadOnly = true;
            this.textFolio.Size = new System.Drawing.Size(273, 22);
            this.textFolio.TabIndex = 7;
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(259, 57);
            this.botonBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(135, 23);
            this.botonBuscar.TabIndex = 8;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // botonLimpiaForm
            // 
            this.botonLimpiaForm.Location = new System.Drawing.Point(72, 252);
            this.botonLimpiaForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botonLimpiaForm.Name = "botonLimpiaForm";
            this.botonLimpiaForm.Size = new System.Drawing.Size(153, 23);
            this.botonLimpiaForm.TabIndex = 9;
            this.botonLimpiaForm.Text = "Limpiar formulario";
            this.botonLimpiaForm.UseVisualStyleBackColor = true;
            this.botonLimpiaForm.Click += new System.EventHandler(this.botonLimpiaForm_Click);
            // 
            // botonEliminarRegistro
            // 
            this.botonEliminarRegistro.Location = new System.Drawing.Point(249, 252);
            this.botonEliminarRegistro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botonEliminarRegistro.Name = "botonEliminarRegistro";
            this.botonEliminarRegistro.Size = new System.Drawing.Size(153, 23);
            this.botonEliminarRegistro.TabIndex = 10;
            this.botonEliminarRegistro.Text = "Eliminar Registro";
            this.botonEliminarRegistro.UseVisualStyleBackColor = true;
            this.botonEliminarRegistro.Click += new System.EventHandler(this.botonEliminarRegistro_Click);
            // 
            // EliminarRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(541, 326);
            this.Controls.Add(this.botonEliminarRegistro);
            this.Controls.Add(this.botonLimpiaForm);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.textFolio);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.textRut);
            this.Controls.Add(this.textDato);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EliminarRegistro";
            this.Text = "Eliminar Registro";
            this.Load += new System.EventHandler(this.EliminarRegistro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textDato;
        private System.Windows.Forms.TextBox textRut;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.TextBox textFolio;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.Button botonLimpiaForm;
        private System.Windows.Forms.Button botonEliminarRegistro;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}