using ProyectoTrimestral.Clases;
using ProyectoTrimestral.Controladores;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoTrimestral.Vistas
{
    public partial class ModificarPrecio : Form
    {
        private Fruta frutaNueva;

        public ModificarPrecio(Fruta fruta)
        {
            InitializeComponent();
            this.frutaNueva = fruta;
        }

        private void ModificarPrecio_Load(object sender, EventArgs e)
        {
            ControladorFruta.leer();
        }

        private void buttonCambiar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (numericUpDown1.Value <= 0)
            {
                numericUpDown1.BackColor = Color.LightCoral;
                errorProvider1.SetError(numericUpDown1, "Introduce un valor mayor que 0.");
            } 
            else if (frutaNueva.precio == numericUpDown1.Value) 
            {
                numericUpDown1.BackColor = Color.LightCoral;
                errorProvider1.SetError(numericUpDown1, "Introduce un valor distinto que el original.");
            }
            else
            {
                // Modificar precio
                numericUpDown1.BackColor = Color.White;

                foreach (Fruta fruta in ControladorFruta.listaFrutas)
                {
                    if (fruta.codigo == frutaNueva.codigo)
                    {
                        fruta.precio = (int)numericUpDown1.Value;
                    }
                }

                ControladorFruta.escribir();
                this.Close();
            }
        }
    }
}
