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
    public partial class FiltroReciboBD : Form
    {
        public FiltroReciboBD()
        {
            InitializeComponent();
        }
        private DataSet dataset;
        private void FiltroReciboBD_Load(object sender, EventArgs e)
        {
            ControladorRecibo.cargarDatosDataGridView(dataGridView1);

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;

            dataGridView1.Columns.Clear();

            dataset = ControladorRecibo.rellenarDataSet();

            dataGridView1.DataSource = dataset.Tables[0];
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
