using Microsoft.OData.Edm;
using System;

namespace ProyectoTrimestral.Clases
{
    public class Fruta
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string sabor { get; set; }
        public string tipo { get; set; }
        public int precio { get; set; }
        
        public Date fecha { get; set; }

        public Fruta()
        {
        }

        public Fruta(string codigo, string nombre, string sabor, string tipo, int precio, Date fecha)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.sabor = sabor;
            this.tipo = tipo;
            this.precio = precio;
            this.fecha = fecha;
        }
    }
}
