using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Drawing;

namespace GestorAppTestFinalV2Git
{
    public partial class Form1 : Form
    {
        private readonly List<Suscripcion> listaSuscripciones = new();
        // Controla suscripciones ya notificadas para evitar repetir notificaciones en la misma ejecución
        private readonly HashSet<string> notifiedKeys = new();

        public Form1()
        {
            InitializeComponent();

            // Inicializar NotifyIcon y Timer
            notifyIcon.Icon = SystemIcons.Application;
            notifyIcon.Visible = false; // sólo visible cuando estén activos los recordatorios

            // Aseguramos el intervalo por defecto (1 minuto)
            timerRecordatorio.Interval = 60_000;
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

            var sus = new Suscripcion(txtNombre.Text.Trim(), costo, fecha);
            listaSuscripciones.Add(sus);

            // Limpiar entradas
            txtNombre.Clear();
            txtCosto.Clear();
            dtpFechaCobro.Value = DateTime.Now;
            txtNombre.Focus();

            // Limpiamos el registro de notificaciones para permitir notificar la nueva entrada si aplica
            notifiedKeys.Clear();

            MessageBox.Show("Suscripción agregada correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            MostrarEnOutput();
        }

        private void MostrarEnOutput()
        {
            if (listaSuscripciones.Count == 0)
            {
                MessageBox.Show("No hay suscripciones agregadas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOutput.Clear();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (listaSuscripciones.Count == 0)
            {
                MessageBox.Show("No hay suscripciones para guardar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                DefaultExt = "json",
                FileName = "suscripciones.json"
            };

            if (sfd.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true
                };

                string json = JsonSerializer.Serialize(listaSuscripciones, options);
                File.WriteAllText(sfd.FileName, json);
                MessageBox.Show("Suscripciones guardadas correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                DefaultExt = "json"
            };

            if (ofd.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                string json = File.ReadAllText(ofd.FileName);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var items = JsonSerializer.Deserialize<List<Suscripcion>>(json, options);
                if (items == null)
                {
                    MessageBox.Show("El archivo no contiene suscripciones válidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                listaSuscripciones.Clear();
                listaSuscripciones.AddRange(items);

                // Limpiamos notificaciones previas para permitir notificar después de cargar
                notifiedKeys.Clear();

                MostrarEnOutput();
                MessageBox.Show("Suscripciones cargadas correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del checkbox para activar/desactivar recordatorios
        private void chkActivarRecordatorios_CheckedChanged(object sender, EventArgs e)
        {
            bool activar = chkActivarRecordatorios.Checked;
            notifyIcon.Visible = activar;
            if (activar)
            {
                timerRecordatorio.Start();
                ShowStatusInOutput("Recordatorios activados.");
            }
            else
            {
                timerRecordatorio.Stop();
                ShowStatusInOutput("Recordatorios desactivados.");
            }
        }

        // Lógica ejecutada periódicamente por el Timer
        private void timerRecordatorio_Tick(object sender, EventArgs e)
        {
            if (listaSuscripciones.Count == 0) return;

            int diasAntes = (int)nudDiasAntes.Value;
            DateTime hoy = DateTime.Today;

            foreach (var item in listaSuscripciones)
            {
                var diasHasta = (item.FechaCobro.Date - hoy).Days;
                if (diasHasta <= diasAntes && diasHasta >= 0)
                {
                    string key = $"{item.Nombre}|{item.FechaCobro:yyyyMMdd}";
                    if (!notifiedKeys.Contains(key))
                    {
                        string mensaje = $"{item.Nombre} se renueva en {diasHasta} día(s) - {item.FechaCobro:d} - ${item.PrecioMensual:F2}";
                        // Mostrar balloon tip
                        try
                        {
                            notifyIcon.BalloonTipTitle = "Recordatorio de suscripción";
                            notifyIcon.BalloonTipText = mensaje;
                            notifyIcon.ShowBalloonTip(5000);
                        }
                        catch
                        {
                            // si falla la balloon tip, seguimos sin interrumpir la app
                        }

                        // También añadir al output para historial
                        ShowStatusInOutput($"[Recordatorio] {mensaje}");

                        // Marcar como notificado para no repetir en esta sesión
                        notifiedKeys.Add(key);
                    }
                }
            }
        }

        private void ShowStatusInOutput(string texto)
        {
            txtOutput.Text = $"{DateTime.Now:G} - {texto}{Environment.NewLine}{txtOutput.Text}";
        }

        // Liberar icono cuando se cierre el formulario
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            try
            {
                notifyIcon.Visible = false;
                notifyIcon.Dispose();
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
