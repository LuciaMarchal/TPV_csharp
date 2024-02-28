namespace ProyectoTrimestral.Vistas
{
    partial class AltaFruta
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaFruta));
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonAlta = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelPrecio = new System.Windows.Forms.Label();
            this.labelTipo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSabor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelNombre = new System.Windows.Forms.Label();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.comboBoxSabor = new System.Windows.Forms.ComboBox();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.numericPrecio = new System.Windows.Forms.NumericUpDown();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.AutoSize = true;
            this.buttonCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.buttonCancelar.Location = new System.Drawing.Point(650, 270);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(106, 27);
            this.buttonCancelar.TabIndex = 45;
            this.buttonCancelar.Text = "Cerrar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            // 
            // buttonAlta
            // 
            this.buttonAlta.AutoSize = true;
            this.buttonAlta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonAlta.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.buttonAlta.Location = new System.Drawing.Point(650, 215);
            this.buttonAlta.Name = "buttonAlta";
            this.buttonAlta.Size = new System.Drawing.Size(106, 27);
            this.buttonAlta.TabIndex = 44;
            this.buttonAlta.Text = "Dar de alta";
            this.buttonAlta.UseVisualStyleBackColor = false;
            this.buttonAlta.Click += new System.EventHandler(this.buttonAlta_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(597, -26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 193);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // labelPrecio
            // 
            this.labelPrecio.AutoSize = true;
            this.labelPrecio.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.labelPrecio.Location = new System.Drawing.Point(55, 215);
            this.labelPrecio.Name = "labelPrecio";
            this.labelPrecio.Size = new System.Drawing.Size(64, 17);
            this.labelPrecio.TabIndex = 37;
            this.labelPrecio.Text = "Precio:";
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.labelTipo.Location = new System.Drawing.Point(55, 185);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(48, 17);
            this.labelTipo.TabIndex = 33;
            this.labelTipo.Text = "Tipo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.label1.Location = new System.Drawing.Point(55, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 17);
            this.label1.TabIndex = 55;
            this.label1.Text = "Codigo de barras:";
            // 
            // labelSabor
            // 
            this.labelSabor.AutoSize = true;
            this.labelSabor.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.labelSabor.Location = new System.Drawing.Point(55, 154);
            this.labelSabor.Name = "labelSabor";
            this.labelSabor.Size = new System.Drawing.Size(56, 17);
            this.labelSabor.TabIndex = 57;
            this.labelSabor.Text = "Sabor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.label2.Location = new System.Drawing.Point(55, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 60;
            this.label2.Text = "Fecha de alta:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.labelNombre.Location = new System.Drawing.Point(55, 125);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(64, 17);
            this.labelNombre.TabIndex = 61;
            this.labelNombre.Text = "Nombre:";
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.textBoxCodigo.Location = new System.Drawing.Point(259, 93);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(250, 23);
            this.textBoxCodigo.TabIndex = 62;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.textBoxNombre.Location = new System.Drawing.Point(259, 122);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(250, 23);
            this.textBoxNombre.TabIndex = 63;
            // 
            // comboBoxSabor
            // 
            this.comboBoxSabor.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.comboBoxSabor.FormattingEnabled = true;
            this.comboBoxSabor.Items.AddRange(new object[] {
            "Dulce",
            "Semidulce",
            "Acido",
            "Semiacido",
            "Neutras"});
            this.comboBoxSabor.Location = new System.Drawing.Point(259, 151);
            this.comboBoxSabor.Name = "comboBoxSabor";
            this.comboBoxSabor.Size = new System.Drawing.Size(250, 25);
            this.comboBoxSabor.TabIndex = 64;
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Items.AddRange(new object[] {
            "Tropical/exoticas",
            "Frutos secos",
            "Citricos",
            "Frutos rojos/bayas",
            "Comunes"});
            this.comboBoxTipo.Location = new System.Drawing.Point(259, 183);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(250, 25);
            this.comboBoxTipo.TabIndex = 65;
            // 
            // numericPrecio
            // 
            this.numericPrecio.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.numericPrecio.Location = new System.Drawing.Point(259, 215);
            this.numericPrecio.Name = "numericPrecio";
            this.numericPrecio.Size = new System.Drawing.Size(250, 23);
            this.numericPrecio.TabIndex = 66;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.monthCalendar1.Location = new System.Drawing.Point(259, 250);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 67;
            // 
            // AltaFruta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(222)))));
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.numericPrecio);
            this.Controls.Add(this.comboBoxTipo);
            this.Controls.Add(this.comboBoxSabor);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.textBoxCodigo);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelSabor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAlta);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelPrecio);
            this.Controls.Add(this.labelTipo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AltaFruta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AltaFruta";
            this.Load += new System.EventHandler(this.AltaFruta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrecio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonAlta;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelPrecio;
        private System.Windows.Forms.Label labelTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSabor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.ComboBox comboBoxSabor;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.NumericUpDown numericPrecio;
        private System.Windows.Forms.ComboBox comboBoxTipo;
    }
}