using ProyectoTrimestral.Clases;
using ProyectoTrimestral.Controladores;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace ProyectoTrimestral.Vistas
{
    public partial class FiltroRecibos : Form
    {
        public FiltroRecibos()
        {
            InitializeComponent();
        }

        private void FiltroRecibos_Load(object sender, EventArgs e)
        {
            ControladorRecibo.leer();
            cargarListView();
        }

        public void cargarListView()
        {
            listView1.Clear();
            // Configurar el ListView
            listView1.View = View.Details;
            listView1.Columns.Add("Correo", listView1.Width / 4);
            listView1.Columns.Add("Método", listView1.Width / 4);
            listView1.Columns.Add("Total", (listView1.Width / 4) / 2);
            listView1.Columns.Add("Fecha de venta", (listView1.Width / 4) * 2);

        }
        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            cargarListView();
            // Obtener el mes seleccionado en el ComboBox
            int mesSeleccionado = comboBox1.SelectedIndex + 1;

            List<Recibo> recibosFiltrados = new List<Recibo>();

            // Filtrar los recibos según el mes seleccionado
            for (int i = 0; i < ControladorRecibo.listaRecibos.Count; i++)
            {
                Recibo recibo = ControladorRecibo.listaRecibos[i];
                if (recibo.fecha.Month == mesSeleccionado)
                {
                    recibosFiltrados.Add(recibo);
                }
            }

            // Mostrar los recibos filtrados en el ListView
            foreach (Recibo recibo in recibosFiltrados)
            {
                // Verificar si el recibo ya existe en el ListView
                bool reciboExistente = false;
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[0].Text == recibo.correo && item.SubItems[1].Text == recibo.metodoPago
                        && item.SubItems[2].Text == recibo.total.ToString() && item.SubItems[3].Text == recibo.fecha.ToString())
                    {
                        reciboExistente = true;
                        break;
                    }
                }

                // Agregar el recibo al ListView solo si no existe
                if (!reciboExistente)
                {
                    ListViewItem item = new ListViewItem(new[]
                    {
                        recibo.correo,
                        recibo.metodoPago,
                        recibo.total.ToString(),
                        recibo.fecha.ToString()
                    });

                    // Agregar el item al ListView
                    listView1.Items.Add(item);
                }
            }
        }
    }
}