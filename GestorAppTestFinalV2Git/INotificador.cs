using System;

namespace GestorAppTestFinalV2Git
{
    public interface INotificador
    {
        // Devuelve el mensaje de notificación para mostrar en la interfaz.
        string EnviarNotificacion(string mensaje);
    }
}
