using ProyectoTrimestral.Clases;
using ProyectoTrimestral.Controladores;
using System;
using System.Windows.Forms;

namespace ProyectoTrimestral.Vistas
{
    public partial class InicioSesion : Form
    {
        // Almacenar el correo electrónico del usuario que ha iniciado sesión
        public string CorreoElectronico { get; set; }
        private Empleado usuarioActual;

        public InicioSesion()
        {
            InitializeComponent();
        }

        private bool validarLogin(string correo, string pass)
        {
            ControladorEmpleado.leer();

            int posicion = ControladorEmpleado.listaEmpleado.FindIndex(x => x.correo == correo.ToLower());

            // Verificar si se encontró el correo y la contraseña es correcta
            if (posicion != -1 && ControladorEmpleado.listaEmpleado[posicion].contrasena == pass)
            {
                usuarioActual = ControladorEmpleado.listaEmpleado[posicion];
                return true;
            }
            return false;
        }

        // Validar el usuario antes de iniciar sesión
        private bool validar_usuario(string correo, string pass)
        {
            if (!validarLogin(correo, pass))
            {
                MessageBox.Show("Error en el correo y/o contraseña.");
                textBoxCorreo.Clear();
                textBoxContrasena.Clear();
                textBoxCorreo.Focus();
                return false;
            }
            else
            {
                // El inicio de sesión es exitoso
                return true;
            }
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (validar_usuario(textBoxCorreo.Text, textBoxContrasena.Text))
            {
                // Verificar que el usuario actual no sea nulo
                if (usuarioActual != null)
                {
                    CorreoElectronico = textBoxCorreo.Text;

                    textBoxCorreo.Clear();
                    textBoxContrasena.Clear();

                    // Registrar el inicio de sesión
                    usuarioActual.inicio = DateTime.Now;
                    ControladorEmpleado.escribirAccesos();
                    ControladorFichaje.actualizar(DateTime.Now.ToString(), usuarioActual.correo);
                    Tienda tienda = new Tienda(usuarioActual);
                    tienda.ShowDialog();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Bienvenida b = new Bienvenida();
            this.Hide();
            b.ShowDialog();
        }

    }
}
