using Microsoft.OData.Edm;
using ProyectoTrimestral.Clases;
using ProyectoTrimestral.Controladores;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProyectoTrimestral.Vistas
{
    public partial class AltaEmpleado : Form
    {
        public AltaEmpleado()
        {
            InitializeComponent();
        }

        private void AltaEmpleado_Load(object sender, EventArgs e)
        {
            ControladorEmpleado.leer();
        }

        private List<TextBox> textBoxs = new List<TextBox>();

        // Crear todos los elementos de textBox en una lista
        private void cargarObjetos()
        {
            textBoxs.Add(textBoxNombre);
            textBoxs.Add(textBoxApellidos);
            textBoxs.Add(textBoxCorreo);
            textBoxs.Add(textBoxContrasena);
            textBoxs.Add(textBoxContrasenaConf);
        }

        // Comprobar el registro
        private bool comprobarRegistro()
        {
            errorProvider1.Clear();
            cargarObjetos();
            foreach (var item in textBoxs)
            {
                // Comprobar que no este vacio
                if (string.IsNullOrWhiteSpace(item.Text) || esSoloNumero(item.Text))
                {
                    errorProvider1.SetError(item, "En este campo solo pueden introducirse letras");
                    item.BackColor = Color.LightCoral;
                    return false;
                }
                else
                {
                    item.BackColor = Color.White;
                }
            }
            
            // Comprobacion de que la contraseña es la misma que la confirmada
            if (!textBoxContrasena.Text.Equals(textBoxContrasenaConf.Text))
            {
                errorProvider1.SetError(textBoxContrasena, "Comprueba que la contraseña es la misma.");
                textBoxContrasenaConf.BackColor = Color.LightCoral;
                return false;
            }
            else if (!verificarCorreo()) // Verifica si es un correo electronico valido
            {
                errorProvider1.SetError(textBoxCorreo, "Introduce un correo electrónico válido.");
                textBoxCorreo.BackColor = Color.LightCoral;
                return false;
            }
            else
            {
                textBoxContrasenaConf.BackColor = Color.White;
                textBoxContrasenaConf.BackColor = Color.White;

                return true;
            }

        }

        // Verificar que se introducen solamente numeros
        private bool esSoloNumero(string texto)
        {
            if (int.TryParse(texto, out int resultadoEntero))
            {
                return true;
            }

            if (double.TryParse(texto, out double resultadoDecimal))
            {
                return true;
            }

            return false;
        }

        // Verificar el formato del correo
        public Boolean verificarCorreo()
        {
            string email = textBoxCorreo.Text;

            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(patron);

            if (regex.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private Empleado crearEmpleado()
        {
            string nombre = textBoxNombre.Text;
            string apellidos = textBoxApellidos.Text;
            string correo = textBoxCorreo.Text;
            string contrasena = textBoxContrasena.Text;
            Date fecha = dateTimePicker1.Value;

            Empleado e = new Empleado(correo, nombre, apellidos, fecha, contrasena);

            return e;
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            if (!buscarEmpleado()) // Si no existe el empleado
            {
                if (comprobarRegistro()) // Comprueba que los datos introducidos en el registro sean validos
                {
                    Empleado emp = crearEmpleado();
                    ControladorEmpleado.listaEmpleado.Add(emp);

                    ControladorEmpleado.escribir();
                    ControladorEmpleado.escribirAccesos();

                    ControladorEmpleado.insertar(emp);
                    MessageBox.Show("Empleado creado");
                }
            }
            else
            {
                MessageBox.Show("Empleado ya existe. Por favor inicia sesion.");
            }
        }

        private Boolean buscarEmpleado()
        {
            foreach (Empleado e in ControladorEmpleado.listaEmpleado)
            {
                // Comprueba que el correo introducido este en la lista
                if (e.correo == textBoxCorreo.Text)
                {
                    return true;
                }
            }
            return false;
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
