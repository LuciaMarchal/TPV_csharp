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
    public partial class ListadoFrutasBD : Form
    {
        public ListadoFrutasBD()
        {
            InitializeComponent();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DataSet dataset;
        
        private void ListadoFrutasBD_Load(object sender, EventArgs e)
        {
            ControladorFruta.cargarDatosDataGridView(dataGridView1);
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;

            dataGridView1.Columns[0].Name = "Codigo";
            dataGridView1.Columns[1].Name = "Nombre";
            dataGridView1.Columns[2].Name = "Sabor";
            dataGridView1.Columns[3].Name = "Tipo";
            dataGridView1.Columns[4].Name = "Precio";
            dataGridView1.Columns[5].Name = "Fecha";
            dataGridView1.Columns[6].Name = "Eliminar";

            dataset = ControladorFruta.rellenarDataSet();
            dataGridView1.DataSource = dataset.Tables[1];
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                DataGridViewCell cell = row.Cells[e.ColumnIndex];

                object newValue = cell.Value;
                string columnName = cell.OwningColumn.Name;
                object primaryKeyValue = dataGridView1.Rows[e.RowIndex].Cells[4].Value;

                if (cell.OwningColumn.Name == "precio")
                {
                    if (string.IsNullOrWhiteSpace(cell.Value?.ToString()))
                    {
                        MessageBox.Show("El campo no puede estar vacio");
                    }
                }

                ControladorFruta.actualizar(newValue, columnName, primaryKeyValue);
                ControladorFruta.cargarDatosDataGridView(dataGridView1);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex == dataGridView1.NewRowIndex)
            {
                e.Value = Resources.papelera;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                Fruta fruta = null;
                foreach (Fruta f in ControladorFruta.listaFrutas)
                {
                    if (f.codigo == id)
                    {
                        fruta = f;
                    }
                }
                ControladorFruta.eliminar(id);
                ControladorFruta.listaFrutas.Remove(fruta);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                ControladorFruta.actualizarDataSet(dataset);
            }
        }
    }
}
