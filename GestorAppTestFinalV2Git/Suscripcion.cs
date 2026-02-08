using System;

namespace GestorAppTestFinalV2Git
{
    public class Suscripcion
    {
        public string Nombre { get; set; }
        public double PrecioMensual { get; set; }
        public DateTime FechaCobro { get; set; }

        public Suscripcion(string nombre, double precioMensual, DateTime fechaCobro)
        {
            Nombre = nombre;
            PrecioMensual = precioMensual;
            FechaCobro = fechaCobro;
        }

        public virtual string MostrarDetalles()
        {
            return $"Suscripción: {Nombre}, Precio Mensual: {PrecioMensual:C2}, Fecha de Cobro: {FechaCobro:d}";
        }

        public override string ToString() => MostrarDetalles();
    }
}
