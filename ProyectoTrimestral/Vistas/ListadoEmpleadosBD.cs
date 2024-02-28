using ProyectoTrimestral.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTrimestral.Vistas
{
    public partial class ListadoEmpleadosBD : Form
    {
        public ListadoEmpleadosBD()
        {
            InitializeComponent();
        }

        private void ListadoEmpleadosBD_Load(object sender, EventArgs e)
        {
            ControladorEmpleado.cargarDatosDataGridView(dataGridView1);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
