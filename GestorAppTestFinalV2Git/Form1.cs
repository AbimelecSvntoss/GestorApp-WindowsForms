using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace GestorAppTestFinalV2Git
{
    public partial class Form1 : Form
    {
        private readonly List<Suscripcion> listaSuscripciones = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre de la suscripción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (!double.TryParse(txtCosto.Text, NumberStyles.Number | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double costo))
            {
                MessageBox.Show("Ingrese un costo mensual válido (usar punto como separador decimal si aplica).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCosto.Focus();
                return;
            }

            DateTime fecha = dtpFechaCobro.Value.Date;

            // Añadir suscripción básica; si en el futuro quieres añadir Premium, puedes usar otro formulario o campo adicional.
            var sus = new Suscripcion(txtNombre.Text.Trim(), costo, fecha);
            listaSuscripciones.Add(sus);

            // Limpiar entradas
            txtNombre.Clear();
            txtCosto.Clear();
            dtpFechaCobro.Value = DateTime.Now;
            txtNombre.Focus();

            MessageBox.Show("Suscripción agregada correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (listaSuscripciones.Count == 0)
            {
                MessageBox.Show("No hay suscripciones agregadas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sb = new StringBuilder();
            double total = 0;

            foreach (var item in listaSuscripciones)
            {
                sb.AppendLine(item.MostrarDetalles());
                total += item.PrecioMensual;

                if (item is INotificador notificador)
                {
                    sb.AppendLine(notificador.EnviarNotificacion("Tu suscripción está por renovarse."));
                }

                sb.AppendLine(new string('═', 60));
            }

            sb.AppendLine();
            sb.AppendLine($"Total de gastos mensuales: {total:C2}");

            txtOutput.Text = sb.ToString();
        }
    }
}
