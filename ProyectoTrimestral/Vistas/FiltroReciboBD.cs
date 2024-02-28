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
    public partial class FiltroReciboBD : Form
    {
        public FiltroReciboBD()
        {
            InitializeComponent();
        }

        private void FiltroReciboBD_Load(object sender, EventArgs e)
        {
            ControladorRecibo.cargarDatosDataGridView(dataGridView1);
        }
    }
}
