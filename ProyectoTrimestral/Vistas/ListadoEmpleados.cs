using ProyectoTrimestral.Clases;
using ProyectoTrimestral.Controladores;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoTrimestral.Vistas
{
    public partial class ListadoEmpleados : Form
    {
        private int posicion;
        private int contador;

        public ListadoEmpleados()
        {
            InitializeComponent();
        }

        private void ListadoEmpleados_Load(object sender, EventArgs e)
        {
            ControladorEmpleado.leerAccesos();
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            this.groupBox1.Controls.Clear();
            mostrarUsuarios();
        }

        private void crearEtiqueta(Empleado usuario)
        {
            // Crear Label
            Label label = new Label();

            // Configurar propiedades del Label
            label.AutoSize = true;
            label.Font = new Font("Cascadia Code", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            label.Location = new Point(75, this.posicion);
            label.Location = new Point(label.Location.X - 50, label.Location.Y + 15);
            label.Name = "chkEmpleado" + this.contador;
            label.Size = new Size(200, 20);
            label.Text = usuario.correo + ": " + usuario.inicio;

            groupBox1.Controls.Add(label);

            this.posicion += 32;
            this.contador++;
        }

        private void mostrarUsuarios()
        {
            this.contador = 1;
            this.posicion = 15;

            foreach (Empleado usuario in ControladorEmpleado.listaEmpleado)
            {
                crearEtiqueta(usuario);
            }
        }

    }
}
