using ProyectoTrimestral.Clases;
using ProyectoTrimestral.Controladores;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProyectoTrimestral.Vistas
{
    public partial class BajaFruta : Form
    {
        public BajaFruta()
        {
            InitializeComponent();
        }

        private void BajaFruta_Load(object sender, EventArgs e)
        {
            ControladorFruta.leer();

            mostrarFruta();

            // Asociar el evento listView1_ItemChecked al evento ItemChecked del ListView
            listView1.ItemChecked += new ItemCheckedEventHandler(listView1_ItemChecked);

            // Habilitar la opción de checkboxes en el ListView
            listView1.CheckBoxes = true;
        }

        private void mostrarFruta()
        {
            listView1.Items.Clear();

            // Añadir columnas al ListView
            listView1.View = View.Details;
            listView1.Columns.Add("", 20);
            listView1.Columns.Add("Codigo", (listView1.Width - 20) / 6);
            listView1.Columns.Add("Nombre", (listView1.Width - 20) / 6);
            listView1.Columns.Add("Tipo", (listView1.Width - 20) / 6);
            listView1.Columns.Add("Sabor", (listView1.Width - 20) / 6);
            listView1.Columns.Add("Precio", (listView1.Width - 20) / 6);
            listView1.Columns.Add("Fecha alta", (listView1.Width - 20) / 6);

            // Iterar a través de las frutas y agregarlas al ListView
            foreach (Fruta fruta in ControladorFruta.listaFrutas)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(fruta.codigo);
                item.SubItems.Add(fruta.nombre);
                item.SubItems.Add(fruta.tipo);
                item.SubItems.Add(fruta.sabor);
                item.SubItems.Add(fruta.precio.ToString());
                item.SubItems.Add(fruta.fecha.ToString());

                // Asignar el objeto Fruta como etiqueta (Tag) del ListViewItem
                item.Tag = fruta;

                listView1.Items.Add(item);
                ControladorFruta.escribir();

            }
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            List<Fruta> frutasAEliminar = new List<Fruta>();

            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Checked)
                {
                    // Obtener el nombre de la fruta
                    string nombreFruta = item.SubItems[2].Text;

                    int position = ControladorFruta.listaFrutas.FindIndex(x => x.nombre == nombreFruta);

                    // Verificar si se encontró la fruta antes de intentar eliminarla
                    if (position != -1)
                    {
                        // Agregar la fruta a la lista de elementos a eliminar
                        frutasAEliminar.Add(ControladorFruta.listaFrutas[position]);
                    }
                }
            }

            foreach (Fruta fruta in frutasAEliminar)
            {
                ControladorFruta.listaFrutas.Remove(fruta);
            }

            listView1.Clear();
            mostrarFruta();

        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item != null && e.Item.Checked)
            {
                // Obtener la fruta asociada al elemento checked
                Fruta frutaSeleccionada = (Fruta)e.Item.Tag;
            }
        }

    }
}
