using ProyectoTrimestral.Clases;
using ProyectoTrimestral.Controladores;
using ProyectoTrimestral.Properties;
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
    public partial class ListadoFichajesBD : Form
    {
        public ListadoFichajesBD()
        {
            InitializeComponent();
        }

        private DataSet dataset;

        private void ListadoFichajesBD_Load(object sender, EventArgs e)
        {
            ControladorFichaje.cargarDatosDataGridView(dataGridView1);

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;

            dataGridView1.Columns.Clear();

            dataset = ControladorFichaje.rellenarDataSet();
            dataGridView1.DataSource = dataset.Tables[0];
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}