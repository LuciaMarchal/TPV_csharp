using ProyectoTrimestral.Clases;
using ProyectoTrimestral.Controladores;
using System;
using System.Drawing;
using System.Windows.Forms;
using RadioButton = System.Windows.Forms.RadioButton;

namespace ProyectoTrimestral.Vistas
{
    public partial class ModificarFruta : Form
    {
        private Fruta frutaSeleccionada;
        private int posicion;
        private int contador;

        public ModificarFruta()
        {
            InitializeComponent();
        }

        private void ModificarFruta_Load(object sender, EventArgs e)
        {
            ControladorFruta.leer();
            mostrarFrutas();
        }

        private void cargarCheckbox(Fruta fruta)
        {
            // Crear RadioButton
            RadioButton radioButton = new RadioButton();

            // Configurar propiedades del RadioButton
            radioButton.AutoSize = true;
            radioButton.Font = new Font("Cascadia Code", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButton.Location = new Point(30, posicion + 10);
            radioButton.Size = new Size(200, 20);
            radioButton.Text = fruta.nombre;

            // Crear Label
            Label label = new Label();

            // Configurar propiedades del Label
            label.AutoSize = true;
            label.Font = new Font("Cascadia Code", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            label.Location = new Point(230, posicion + 10);
            label.Name = "chkEmpleado" + this.contador;
            label.Size = new Size(200, 20);
            label.Text = fruta.codigo + ": " + fruta.precio;

            radioButton.Tag = fruta;

            groupBox1.Controls.Add(radioButton);
            groupBox1.Controls.Add(label);

            this.posicion += 32;
            this.contador++;

            radioButton.CheckedChanged += RadioButton_CheckedChanged;

        }

        private void mostrarFrutas()
        {
            this.contador = 1;
            this.posicion = 15;

            foreach (Fruta fruta in ControladorFruta.listaFrutas)
            {
                cargarCheckbox(fruta);
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Checked)
            {
                // Obtener el objeto Fruta de la etiqueta (Tag) del RadioButton
                frutaSeleccionada = (Fruta)radioButton.Tag;
            }
        }

        private void buttonCambiar_Click(object sender, EventArgs e)
        {
            if (frutaSeleccionada != null)
            {
                ModificarPrecio modificarPrecio = new ModificarPrecio(frutaSeleccionada);
                modificarPrecio.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fruta antes de cambiar el precio.");
            }
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            ControladorFruta.leer();
            groupBox1.Controls.Clear();
            mostrarFrutas();

        }
    }
}
