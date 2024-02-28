using System;

namespace ProyectoTrimestral.Clases
{
    public class Recibo
    {
        public string correo {  get; set; }
        public string metodoPago { get; set; }
        public float total { get; set; }
        public DateTime fecha { get; set; }

        public Recibo()
        {
        }

        public Recibo(string correo, string metodoPago, float total, DateTime fecha)
        {
            this.correo = correo;
            this.metodoPago = metodoPago;
            this.total = total;
            this.fecha = fecha;
        }

        public override string ToString()
        {
            return $"Correo: {correo}\nMétodo de Pago: {metodoPago}\nTotal: {total}\nFecha: {fecha}";
        }

    }
}
