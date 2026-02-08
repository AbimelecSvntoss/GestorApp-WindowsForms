using System;

namespace GestorAppTestFinalV2Git
{
    public class SPremium : Suscripcion, INotificador
    {
        public string BeneficiosAdicionales { get; set; }

        public SPremium(string nombre, double precioMensual, DateTime fechaCobro, string beneficiosAdicionales)
            : base(nombre, precioMensual, fechaCobro)
        {
            BeneficiosAdicionales = beneficiosAdicionales;
        }

        public override string MostrarDetalles()
        {
            return base.MostrarDetalles() + Environment.NewLine + $"Beneficios Adicionales: {BeneficiosAdicionales}";
        }

        public string EnviarNotificacion(string mensaje)
        {
            return $"ALERTA PUSH!: {Nombre} dice {mensaje}";
        }
    }
}
