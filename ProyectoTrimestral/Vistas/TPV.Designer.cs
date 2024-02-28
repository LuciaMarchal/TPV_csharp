namespace ProyectoTrimestral.Vistas
{
    partial class TPV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TPV));
            this.buttonAnadir = new System.Windows.Forms.Button();
            this.groupBoxCarrito = new System.Windows.Forms.GroupBox();
            this.groupBoxMetodoPago = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.groupBoxTotal = new System.Windows.Forms.GroupBox();
            this.buttonTotal = new System.Windows.Forms.Button();
            this.groupBoxEmpleado = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.groupBoxAccesosFruta = new System.Windows.Forms.GroupBox();
            this.groupBoxMetodoPago.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAnadir
            // 
            this.buttonAnadir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonAnadir.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.buttonAnadir.Location = new System.Drawing.Point(12, 321);
            this.buttonAnadir.Name = "buttonAnadir";
            this.buttonAnadir.Size = new System.Drawing.Size(303, 36);
            this.buttonAnadir.TabIndex = 2;
            this.buttonAnadir.Text = "Añadir";
            this.buttonAnadir.UseVisualStyleBackColor = false;
            this.buttonAnadir.Click += new System.EventHandler(this.buttonAnadir_Click);
            // 
            // groupBoxCarrito
            // 
            this.groupBoxCarrito.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.groupBoxCarrito.Location = new System.Drawing.Point(321, 84);
            this.groupBoxCarrito.Name = "groupBoxCarrito";
            this.groupBoxCarrito.Size = new System.Drawing.Size(467, 298);
            this.groupBoxCarrito.TabIndex = 1;
            this.groupBoxCarrito.TabStop = false;
            this.groupBoxCarrito.Text = "Carrito de compra";
            // 
            // groupBoxMetodoPago
            // 
            this.groupBoxMetodoPago.Controls.Add(this.checkedListBox1);
            this.groupBoxMetodoPago.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.groupBoxMetodoPago.Location = new System.Drawing.Point(12, 363);
            this.groupBoxMetodoPago.Name = "groupBoxMetodoPago";
            this.groupBoxMetodoPago.Size = new System.Drawing.Size(303, 75);
            this.groupBoxMetodoPago.TabIndex = 2;
            this.groupBoxMetodoPago.TabStop = false;
            this.groupBoxMetodoPago.Text = "Metodo de pago";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(222)))));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(24, 34);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(255, 22);
            this.checkedListBox1.TabIndex = 0;
            // 
            // groupBoxTotal
            // 
            this.groupBoxTotal.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.groupBoxTotal.Location = new System.Drawing.Point(321, 388);
            this.groupBoxTotal.Name = "groupBoxTotal";
            this.groupBoxTotal.Size = new System.Drawing.Size(226, 50);
            this.groupBoxTotal.TabIndex = 1;
            this.groupBoxTotal.TabStop = false;
            this.groupBoxTotal.Text = "Total";
            // 
            // buttonTotal
            // 
            this.buttonTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonTotal.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.buttonTotal.Location = new System.Drawing.Point(553, 388);
            this.buttonTotal.Name = "buttonTotal";
            this.buttonTotal.Size = new System.Drawing.Size(120, 50);
            this.buttonTotal.TabIndex = 2;
            this.buttonTotal.Text = "Imprimir Total";
            this.buttonTotal.UseVisualStyleBackColor = false;
            this.buttonTotal.Click += new System.EventHandler(this.buttonTotal_Click);
            // 
            // groupBoxEmpleado
            // 
            this.groupBoxEmpleado.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.groupBoxEmpleado.Location = new System.Drawing.Point(321, 12);
            this.groupBoxEmpleado.Name = "groupBoxEmpleado";
            this.groupBoxEmpleado.Size = new System.Drawing.Size(467, 66);
            this.groupBoxEmpleado.TabIndex = 1;
            this.groupBoxEmpleado.TabStop = false;
            this.groupBoxEmpleado.Text = "Datos del empleado";
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCerrar.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.buttonCerrar.Location = new System.Drawing.Point(679, 388);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(109, 50);
            this.buttonCerrar.TabIndex = 3;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = false;
            // 
            // groupBoxAccesosFruta
            // 
            this.groupBoxAccesosFruta.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.groupBoxAccesosFruta.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAccesosFruta.Name = "groupBoxAccesosFruta";
            this.groupBoxAccesosFruta.Size = new System.Drawing.Size(303, 303);
            this.groupBoxAccesosFruta.TabIndex = 2;
            this.groupBoxAccesosFruta.TabStop = false;
            this.groupBoxAccesosFruta.Text = "Acceso de frutas";
            // 
            // TPV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(222)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CancelButton = this.buttonCerrar;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxAccesosFruta);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.groupBoxEmpleado);
            this.Controls.Add(this.buttonTotal);
            this.Controls.Add(this.buttonAnadir);
            this.Controls.Add(this.groupBoxTotal);
            this.Controls.Add(this.groupBoxCarrito);
            this.Controls.Add(this.groupBoxMetodoPago);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TPV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TPV";
            this.Load += new System.EventHandler(this.TPV_Load);
            this.groupBoxMetodoPago.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxCarrito;
        private System.Windows.Forms.GroupBox groupBoxMetodoPago;
        private System.Windows.Forms.GroupBox groupBoxTotal;
        private System.Windows.Forms.Button buttonAnadir;
        private System.Windows.Forms.Button buttonTotal;
        private System.Windows.Forms.GroupBox groupBoxEmpleado;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.GroupBox groupBoxAccesosFruta;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}