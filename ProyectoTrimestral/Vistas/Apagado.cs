using System;
using System.Windows.Forms;

namespace ProyectoTrimestral.Vistas
{
    public partial class Apagado : Form
    {
        public Apagado()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Autoincrementa el tamaño del panel de carga
            panel2.Width += 2;

            if (panel2.Width >= panel1.Width) // Hasta que sea el tamaño del primero, se para y se cierra todo el formulario
            {
                timer1.Stop();
                Application.Exit();
            }
        }
    }
}
