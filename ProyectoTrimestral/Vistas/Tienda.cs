using ProyectoTrimestral.Clases;
using ProyectoTrimestral.Controladores;
using System;
using System.Windows.Forms;

namespace ProyectoTrimestral.Vistas
{
    public partial class Tienda : Form
    {
        // Usuario actual que ha iniciado sesión
        private Empleado usuarioActual;

        public Tienda(Empleado usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void TiendaAdmin_Load(object sender, EventArgs e)
        {
            ControladorEmpleado.leer();
        }

        private void darDeAltaEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaEmpleado a = new AltaEmpleado();
            a.ShowDialog();
        }

        private void darDeBajaEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BajaEmpleado b = new BajaEmpleado();
            b.ShowDialog();
        }

        private void consultarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoEmpleados listadoEmpleados = new ListadoEmpleados();
            listadoEmpleados.ShowDialog();

        }

        private void darDeAltaFrutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaFruta a = new AltaFruta();
            a.ShowDialog();
        }

        private void consultarStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoFruta listadoFruta = new ListadoFruta();
            listadoFruta.ShowDialog();
        }

        private void darDeBajaFrutaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BajaFruta a = new BajaFruta();
            a.ShowDialog();
        }

        private void tpvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TPV a = new TPV(usuarioActual);
            a.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Apagado apagar = new Apagado();
            apagar.ShowDialog();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarFruta modificar = new ModificarFruta();
            modificar.ShowDialog();
        }

        private void consultarEnBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoEmpleadosBD listadoEmpleadosBD = new ListadoEmpleadosBD();
            listadoEmpleadosBD.ShowDialog();
        }

        private void consultarEnBaseDeDatosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListadoFrutasBD listadoFrutasBD = new ListadoFrutasBD();
            listadoFrutasBD.ShowDialog();
        }

        private void localToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiltroRecibos filtroRecibos = new FiltroRecibos();
            filtroRecibos.ShowDialog();

        }

        private void baseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiltroReciboBD filtroReciboBD = new FiltroReciboBD();
            filtroReciboBD.ShowDialog();
        }

        private void consultarFichajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoFichajesBD listadoFichajesBD = new ListadoFichajesBD();
            listadoFichajesBD.ShowDialog();
        }
    }
}
