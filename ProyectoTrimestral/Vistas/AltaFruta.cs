using ProyectoTrimestral.Clases;
using ProyectoTrimestral.Controladores;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace ProyectoTrimestral.Vistas
{
    public partial class AltaFruta : Form
    {
        private List<ComboBox> comboBoxs = new List<ComboBox>();
        private List<TextBox> texts = new List<TextBox>();
        private List<NumericUpDown> numerics = new List<NumericUpDown>();

        public AltaFruta()
        {
            InitializeComponent();
        }

        private void AltaFruta_Load(object sender, EventArgs e)
        {
            ControladorFruta.leer();
        }

        // Cargar los objetos de controles en las listas
        private void cargarObjetos()
        {
            comboBoxs.Add(comboBoxSabor);
            comboBoxs.Add(comboBoxTipo);
            numerics.Add(numericPrecio);
            texts.Add(textBoxCodigo);
            texts.Add(textBoxNombre);
        }

        // Comprobar que los datos introducidos en el formulario son válidos
        private bool comprobarAlta()
        {
            cargarObjetos();
            
            errorProvider1.Clear();

            // Validar cada TextBox
            foreach (TextBox item in texts)
            {
                // Si esta vacio o es numero
                if (string.IsNullOrWhiteSpace(item.Text) || esSoloNumero(item.Text))
                {
                    errorProvider1.SetError(item, "Este campo tiene que contener letras");

                    item.BackColor = Color.LightCoral;
                    return false;
                }
                else
                {
                    item.BackColor = Color.White;
                }
            }

            // Validar cada ComboBox
            foreach (ComboBox item in comboBoxs)
            {
                // Si los combobox tienen los posibles valores

                switch (item.Text)
                {
                    case "Tropical/exoticas":
                    case "Frutos secos":
                    case "Frutos rojos/bayas":
                    case "Citricos":
                    case "Comunes":
                    case "Dulce":
                    case "Semidulce":
                    case "Acido":
                    case "Semiacido":
                    case "Neutras":
                        item.BackColor = Color.White;
                        break;
                    default:
                        errorProvider1.SetError(item, "Elige una de las opciones disponibles");
                        item.BackColor = Color.LightCoral;
                        return false;
                }
            }

            // Validar cada NumericUpDown
            foreach (NumericUpDown item in numerics)
            {
                // Si los numeric tienen un numero mayor que 0
                if (item.Value <= 0)
                {
                    errorProvider1.SetError(item, "Introduce algun numero. Minimo 1.");
                    item.BackColor = Color.LightCoral;
                    return false;
                }
                else
                {
                    item.BackColor = Color.White;
                }
            }
            
            return true;
            
        }

        private bool esSoloNumero(string texto)
        {
            if (int.TryParse(texto, out int resultadoEntero))
            {
                return true;
            }

            if (double.TryParse(texto, out double resultadoDecimal))
            {
                return true;
            }

            return false;
        }

        private Fruta crearFruta()
        {
            string codigo = textBoxCodigo.Text;
            string nombre = textBoxNombre.Text;
            string sabor = comboBoxSabor.Text;
            string tipo = comboBoxTipo.Text;
            int precio = (int) numericPrecio.Value;
            DateTime fecha = monthCalendar1.SelectionStart;

            Fruta f = new Fruta(codigo, nombre, sabor, tipo, precio, fecha);
            
            return f;
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            if (!buscarFruta()) // Si no encuentra la fruta
            {
                if (comprobarAlta()) // Si los datos son correctos
                {
                    // Crear una nueva fruta
                    Fruta f = crearFruta();
                    // Agregar la fruta a la lista de frutas
                    ControladorFruta.listaFrutas.Add(f);
                    // Guardar la lista actualizada en el archivo
                    ControladorFruta.escribir();
                    
                    ControladorFruta.insertar(f);

                    MessageBox.Show("Fruta creada");
                }
            }
            else
            {
                MessageBox.Show("Fruta ya existe.");
            }
        }

        private Boolean buscarFruta()
        {
            // Leer datos de frutas
            ControladorFruta.leer();
            foreach (Fruta f in ControladorFruta.listaFrutas)
            {
                if (f.nombre == textBoxCodigo.Text)
                {
                    return true; // La fruta ya existe
                }
            }
            return false; 
        }

        
    }
}
