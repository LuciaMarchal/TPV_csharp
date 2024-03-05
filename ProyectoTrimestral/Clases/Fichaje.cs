using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTrimestral.Clases
{
    public class Fichaje
    {
        public Empleado empleado { get; set; }
        public DateTime hora { get; set; }

        public Fichaje(Empleado empleado, DateTime fichaje)
        {
            this.empleado = empleado;
            this.hora = fichaje;
        }

        public Fichaje()
        {
        }
    }
}
