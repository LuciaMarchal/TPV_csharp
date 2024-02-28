using ProyectoTrimestral.Clases;
using ProyectoTrimestral.Controladores;
using System;
using System.Windows.Forms;

namespace ProyectoTrimestral.Vistas
{
    public partial class ListadoFruta : Form
    {
        public ListadoFruta()
        {
            InitializeComponent();
        }

        private void ListadoFruta_Load(object sender, EventArgs e)
        {
            ControladorFruta.leer();
        }

        private void cargarListView()
        {
            // Añadir columnas al ListView para mostrar la información de las frutas
            listView1.View = View.Details;
            listView1.Columns.Add("Codigo", listView1.Width / 6);
            listView1.Columns.Add("Nombre", listView1.Width / 6);
            listView1.Columns.Add("Tipo", listView1.Width / 6);
            listView1.Columns.Add("Sabor", listView1.Width / 6);
            listView1.Columns.Add("Precio", listView1.Width / 6);
            listView1.Columns.Add("Fecha alta", listView1.Width / 6);

            // Llenar el ListView con los datos de las frutas
            foreach (Fruta fruta in ControladorFruta.listaFrutas)
            {
                ListViewItem item = new ListViewItem(fruta.codigo);
                item.SubItems.Add(fruta.nombre);
                item.SubItems.Add(fruta.tipo);
                item.SubItems.Add(fruta.sabor);
                item.SubItems.Add(fruta.precio.ToString());
                item.SubItems.Add(fruta.fecha.ToString());

                listView1.Items.Add(item);
            }
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ControladorFruta.leer();
            cargarListView();
        }
    }
}
