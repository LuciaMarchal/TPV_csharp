using ProyectoTrimestral.Clases;
using ProyectoTrimestral.Controladores;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoTrimestral.Vistas
{
    public partial class BajaEmpleado : Form
    {
        private int posicionInicial;
        private int contadorNombres;

        private List<CheckBox> checks = new List<CheckBox>();

        public BajaEmpleado()
        {
            InitializeComponent();
        }

        private void BajaEmpleado_Load(object sender, EventArgs e)
        {
            ControladorEmpleado.leer();
        }

        // Crear los CheckBox de los empleados
        private void crearCheck(Empleado usuario)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.AutoSize = true;
            checkBox.Font = new Font("Cascadia Code", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox.Location = new Point(75, this.posicionInicial);
            checkBox.Location = new Point(checkBox.Location.X - 50, checkBox.Location.Y + 15);
            checkBox.Name = "chkEmpleado" + this.contadorNombres;
            checkBox.Size = new Size(200, 20);
            checkBox.Text = usuario.correo;

            groupBox1.Controls.Add(checkBox);

            this.posicionInicial += 30;
            this.contadorNombres++;

            checks.Add(checkBox);
        }

        private void mostrarEmpleados()
        {
            this.contadorNombres = 1;
            this.posicionInicial = 15;

            foreach (Empleado usuario in ControladorEmpleado.listaEmpleado)
            {
                crearCheck(usuario);
            }
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            foreach (CheckBox cb in groupBox1.Controls)
            {
                if (cb.Checked) // Si esta seleccionado el empleado
                {
                    // Encontrar la posición del empleado en la lista
                    int position = ControladorEmpleado.listaEmpleado.FindIndex(x => x.correo == cb.Text);

                    ControladorEmpleado.listaEmpleado.RemoveAt(position);

                    ControladorEmpleado.escribir();
                    ControladorEmpleado.escribirAccesos();
                }
            }

            // Limpiar y volver a mostrar los empleados en el groupBox
            this.groupBox1.Controls.Clear();
            mostrarEmpleados();
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            this.groupBox1.Controls.Clear();

            ControladorEmpleado.leer();
            mostrarEmpleados();
        }

    }
}
