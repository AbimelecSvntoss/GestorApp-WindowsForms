using System;
using System.Text.Json.Serialization;

namespace GestorAppTestFinalV2Git
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Suscripcion), "Suscripcion")]
    [JsonDerivedType(typeof(SPremium), "SPremium")]
    public class Suscripcion
    {
        public string Nombre { get; set; }
        public double PrecioMensual { get; set; }
        public DateTime FechaCobro { get; set; }
        public string Categoria { get; set; }

        // ctor parameterless necesario para deserialización
        public Suscripcion() { }

        public Suscripcion(string nombre, double precioMensual, DateTime fechaCobro, string categoria = "General")
        {
            Nombre = nombre;
            PrecioMensual = precioMensual;
            FechaCobro = fechaCobro;
            Categoria = string.IsNullOrWhiteSpace(categoria) ? "General" : categoria;
        }

        public virtual string MostrarDetalles()
        {
            return $"Suscripción: {Nombre}, Categoria: {Categoria}, Precio Mensual: {PrecioMensual:C2}, Fecha de Cobro: {FechaCobro:d}";
        }

        public override string ToString() => MostrarDetalles();
    }
}
