using ProyectoTrimestral.Clases;
using ProyectoTrimestral.Controladores;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckBox = System.Windows.Forms.CheckBox;
using Label = System.Windows.Forms.Label;

namespace ProyectoTrimestral.Vistas
{
    public partial class TPV : Form
    {
        private Empleado usuarioActual;

        private int posicion;
        private int contador;

        private List<CheckBox> checksFruta = new List<CheckBox>();
        private List<NumericUpDown> numericsFruta = new List<NumericUpDown>();

        public TPV(Empleado usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;

            // Configuración inicial del CheckedListBox
            checkedListBox1.Items.AddRange(new object[] {"Efectivo", "Tarjeta"});
            checkedListBox1.SelectedIndexChanged += CheckedListBox_SelectedIndexChanged;
        }

        private void TPV_Load(object sender, EventArgs e)
        {
            ControladorFruta.leer();
            mostrarFrutas();
            ControladorEmpleado.leer();
            mostrarEmpleado();

            // Marcar el elemento efectivo del metodo de pago como predeterminado
            int indiceElementoPredeterminado = 0;
            checkedListBox1.SetItemChecked(indiceElementoPredeterminado, true);

        }

        private void CheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Garantizar que solo una opción esté seleccionada en el CheckedListBox
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (i != checkedListBox1.SelectedIndex)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }

        private void mostrarFrutas()
        {        
            this.groupBoxAccesosFruta.Controls.Clear();
            this.contador = 1;
            this.posicion = 15;

            foreach (Fruta fruta in ControladorFruta.listaFrutas)
            {
                crearChecksFruta(fruta);
            }

        }

        private void crearChecksFruta(Fruta fruta)
        {
            // Crear CheckBox
            CheckBox checkBox = new CheckBox();
            
            // Configurar propiedades del CheckBox
            checkBox.AutoSize = true;
            checkBox.Font = new Font("Cascadia Code", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox.Location = new Point(30, this.posicion);
            checkBox.Name = "chkFruta" + this.contador;
            checkBox.Size = new Size(200, 20);
            checkBox.Text = fruta.nombre;

            // Crear NumericUpDown
            NumericUpDown numericUpDown = new NumericUpDown();

            // Agregar controles al formulario y a las listas
            numericUpDown.Font = new Font("Cascadia Code", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDown.Location = new Point(230, this.posicion);
            numericUpDown.Name = "numFruta" + this.contador;
            numericUpDown.Size = new Size(60, 20);
            numericUpDown.Minimum = 0;
            numericUpDown.Maximum = 100;

            groupBoxAccesosFruta.Controls.Add(checkBox);
            groupBoxAccesosFruta.Controls.Add(numericUpDown);

            checksFruta.Add(checkBox);
            numericsFruta.Add(numericUpDown);

            this.posicion += 30;
            this.contador++;
        }

        private void mostrarEmpleado()
        {
            this.contador = 1;
            this.posicion = 15;

            // Crear etiqueta de empleado para mostrar el correo del usuario actual
            crearLabelEmpleado(usuarioActual);
        }

        private void crearLabelEmpleado(Empleado empleado)
        {
            // Crear Label
            Label label = new Label();

            // Configurar propiedades del Label
            label.AutoSize = true;
            label.Font = new Font("Cascadia Code", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            label.Location = new Point(30, this.posicion);
            label.Name = "lblEmpleado" + this.contador;
            label.Size = new Size(200, 20);
            label.Text = empleado.correo;

            groupBoxEmpleado.Controls.Add(label);

            this.posicion += 30;
            this.contador++;
        }

        public void mostrarCarrito()
        {
            this.groupBoxCarrito.Controls.Clear();
            this.contador = 1;
            this.posicion = 15;

            crearEtiquetaCarrito();
        }

        private void buttonAnadir_Click(object sender, EventArgs e)
        {
            mostrarCarrito();
        }

        private int cantidad;
        public void crearEtiquetaCarrito()
        {
            for (int i = 0; i < checksFruta.Count; i++)
            {
                if (checksFruta[i].Checked && numericsFruta[i].Value > 0)
                {
                    // Crear etiquetas en el carrito para frutas seleccionadas
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Font = new Font("Cascadia Code", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
                    label.Location = new Point(30, this.posicion);
                    label.Name = "lblCarrito" + this.contador;
                    label.Size = new Size(200, 20);

                    cantidad = (int)numericsFruta[i].Value;

                    label.Text = checksFruta[i].Text + ": " + cantidad;

                    groupBoxCarrito.Controls.Add(label);

                    this.posicion += 30;
                    this.contador++;
                }
            }
        }

        private void mostrarTotal()
        {
            this.groupBoxTotal.Controls.Clear();
            this.contador = 1;
            this.posicion = 15;

            crearTotal();
        }

        private int precioTotal = 0;
        private void crearTotal()
        {
            // Calcular el precio total
            this.groupBoxTotal.Controls.Clear();
            this.posicion = 15;

            for (int i = 0; i < checksFruta.Count; i++)
            {
                if (checksFruta[i].Checked)
                {
                    // Obtener la cantidad del NumericUpDown correspondiente
                    int cantidad = (int)numericsFruta[i].Value;
                    
                    // Calcular el precio parcial (precio de la fruta * cantidad)
                    int precioParcial = ControladorFruta.listaFrutas[i].precio * cantidad;

                    precioTotal += precioParcial;
                }
            }

            // Crear Label con el precio total
            Label labelTotal = new Label();
            labelTotal.AutoSize = true;
            labelTotal.Font = new Font("Cascadia Code", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTotal.Location = new Point(30, this.posicion);
            labelTotal.Name = "lblTotal";
            labelTotal.Size = new Size(200, 20);
            labelTotal.Text = "Precio Total: €" + precioTotal;

            groupBoxTotal.Controls.Add(labelTotal);
        }

        private void crearRecibo()
        {
            // Crear un recibo con la información actual y guardarlo en el fichero
            string metodoPago = "Efectivo"; // Valor predeterminado

            // Verificar si hay algún item seleccionado en el CheckedListBox
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                metodoPago = checkedListBox1.CheckedItems[0].ToString();
            }

            Recibo recibo = new Recibo(usuarioActual.correo, metodoPago, precioTotal, DateTime.Now);
            ControladorRecibo.listaRecibos.Add(recibo);
            ControladorRecibo.escribir();
            ControladorRecibo.insertar(recibo);
        }

        private async void buttonTotal_Click(object sender, EventArgs e)
        {
            mostrarCarrito();
            // Deshabilitar el formulario temporalmente
            this.Enabled = false;
            mostrarTotal();
            // Esperar 2 segundos
            await Task.Delay(2000);
            // Crear el recibo y cerrar el formulario
            crearRecibo();
            this.Close();
        }

    }
}
