using Microsoft.OData.Edm;
using System;

namespace ProyectoTrimestral.Clases
{
    [Serializable]
    public class Empleado
    {
        public string correo { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public Date fecha { get; set; }
        public string contrasena { get; set; }
        public DateTime inicio { get; set; }

        public Empleado()
        {
        }

        public Empleado(string correo, string nombre, string apellidos, Date fecha, string contrasena)
        {
            this.correo = correo;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fecha = fecha;
            this.contrasena = contrasena;
        }
    }
}