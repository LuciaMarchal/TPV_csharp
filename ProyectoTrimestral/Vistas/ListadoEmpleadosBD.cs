﻿using ProyectoTrimestral.Clases;
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
    public partial class ListadoEmpleadosBD : Form
    {
        public ListadoEmpleadosBD()
        {
            InitializeComponent();
        }
        private DataSet dataset;
        private void ListadoEmpleadosBD_Load(object sender, EventArgs e)
        {
            ControladorEmpleado.cargarDatosDataGridView(dataGridView1);

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;

            dataGridView1.Columns.Clear();

            dataset = ControladorEmpleado.rellenarDataSet();
            DataGridViewImageColumn borrar = new DataGridViewImageColumn();
            borrar.Image = Resources.papelera;
            borrar.ImageLayout = DataGridViewImageCellLayout.Zoom;
            borrar.Width = 60;
            borrar.Name = "eliminar";

            dataGridView1.DataSource = dataset.Tables[0];
            dataGridView1.Columns.Add(borrar);

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                DataGridViewCell cell = row.Cells[e.ColumnIndex];

                object valor = cell.Value;
                string columna = cell.OwningColumn.Name;
                object clave = dataGridView1.Rows[e.RowIndex].Cells["correo"].Value;

                if (cell.OwningColumn.Name == "contrasena")
                {
                    if (string.IsNullOrWhiteSpace(cell.Value?.ToString()))
                    {
                        MessageBox.Show("El campo no puede estar vacio");
                        return;
                    }
                }
                
                ControladorEmpleado.actualizar(columna, valor, clave);
                ControladorEmpleado.actualizarDataSet(dataset);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "eliminar" && e.RowIndex == dataGridView1.NewRowIndex)
            {
                e.Value = Resources.papelera;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["eliminar"].Index && e.RowIndex >= 0)
            {

                string id = dataGridView1.Rows[e.RowIndex].Cells["correo"].Value.ToString();
                Empleado empleado = null;
                foreach (Empleado emp in ControladorEmpleado.listaEmpleado)
                {
                    if (emp.correo == id)
                    {
                        empleado = emp;
                    }
                }
                ControladorEmpleado.eliminar(id);
                ControladorEmpleado.listaEmpleado.Remove(empleado);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                ControladorEmpleado.actualizarDataSet(dataset);
            }
        }
    }
}