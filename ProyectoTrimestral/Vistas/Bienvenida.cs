using Microsoft.OData.Edm;
using ProyectoTrimestral.Clases;
using ProyectoTrimestral.Controladores;
using ProyectoTrimestral.Vistas;
using System;
using System.Windows.Forms;

namespace ProyectoTrimestral
{
    public partial class Bienvenida : Form
    {
        public Bienvenida()
        {
            InitializeComponent();
        }

        private void Bienvenida_Load(object sender, EventArgs e)
        {
            ControladorEmpleado.leer();
            Empleado empleado = new Empleado("admin1@platanitos.com", "admin1", "admin1", Date.Now, "1234");

            if (ControladorEmpleado.listaEmpleado.Count == 0)
            {
                // Agregar un empleado predeterminado (administrador) si no hay empleados
                ControladorEmpleado.listaEmpleado.Add(empleado);
                ControladorEmpleado.escribir();

            }

            if (!ControladorEmpleado.usuarioExiste(empleado.correo))
            {
                ControladorEmpleado.insertar(empleado);
                ControladorFichaje.insertar(empleado);
            }

        }
        private void buttonInicioSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            InicioSesion i = new InicioSesion();
            i.ShowDialog();
            this.Close();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
