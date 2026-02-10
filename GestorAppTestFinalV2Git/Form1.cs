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
        private readonly HashSet<string> categorias = new(StringComparer.OrdinalIgnoreCase);
        // Controla suscripciones ya notificadas para evitar repetir notificaciones en la misma ejecución
        private readonly HashSet<string> notifiedKeys = new();

        public Form1()
        {
            InitializeComponent();

            // Inicializar NotifyIcon y Timer (si existen)
            try
            {
                notifyIcon.Icon = SystemIcons.Application;
                notifyIcon.Visible = false;
                timerRecordatorio.Interval = 60_000;
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Categorías por defecto
            AddCategory("Todas"); // siempre primero como opción de filtro
            AddCategory("General");
            AddCategory("Streaming");
            AddCategory("Música");
            AddCategory("Utilidades");
            AddCategory("Software");

            // Seleccionar "Todas" en el filtro por defecto
            cmbFiltroCategoria.SelectedIndex = 0;
        }

        private void AddCategory(string categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria)) return;
            if (categorias.Contains(categoria.Trim())) return;

            categorias.Add(categoria.Trim());

            // Añadir a combobox de categoría (para selección/entrada) y filtro
            cmbCategoria.Items.Add(categoria.Trim());

            // filtro: mantener "Todas" en la posición 0
            if (!cmbFiltroCategoria.Items.Contains(categoria.Trim()))
            {
                if (string.Equals(categoria.Trim(), "Todas", StringComparison.OrdinalIgnoreCase))
                    cmbFiltroCategoria.Items.Insert(0, "Todas");
                else
                    cmbFiltroCategoria.Items.Add(categoria.Trim());
            }
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

            string categoria = string.IsNullOrWhiteSpace(cmbCategoria.Text) ? "General" : cmbCategoria.Text.Trim();
            // si es nueva, añadirla a listas y comboboxes
            AddCategory(categoria);

            var sus = new Suscripcion(txtNombre.Text.Trim(), costo, fecha, categoria);
            listaSuscripciones.Add(sus);

            // Limpiar entradas
            txtNombre.Clear();
            txtCosto.Clear();
            dtpFechaCobro.Value = DateTime.Now;
            cmbCategoria.Text = string.Empty;
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
            MostrarEnOutput(cmbFiltroCategoria.SelectedItem?.ToString());
        }

        private void MostrarEnOutput(string filtroCategoria)
        {
            if (listaSuscripciones.Count == 0)
            {
                MessageBox.Show("No hay suscripciones agregadas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOutput.Clear();
                return;
            }

            var sb = new StringBuilder();
            double total = 0;

            IEnumerable<Suscripcion> items = listaSuscripciones;

            if (!string.IsNullOrWhiteSpace(filtroCategoria) && !string.Equals(filtroCategoria, "Todas", StringComparison.OrdinalIgnoreCase))
            {
                items = items.Where(s => string.Equals(s.Categoria, filtroCategoria, StringComparison.OrdinalIgnoreCase));
            }

            foreach (var item in items)
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

        private void cmbFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Actualizar vista al cambiar filtro
            MostrarEnOutput();
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

                // Reconstruir categorías desde las suscripciones cargadas
                categorias.Clear();
                cmbCategoria.Items.Clear();
                cmbFiltroCategoria.Items.Clear();
                AddCategory("Todas");
                foreach (var s in listaSuscripciones)
                {
                    AddCategory(string.IsNullOrWhiteSpace(s.Categoria) ? "General" : s.Categoria);
                }

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
                        try
                        {
                            notifyIcon.BalloonTipTitle = "Recordatorio de suscripción";
                            notifyIcon.BalloonTipText = mensaje;
                            notifyIcon.ShowBalloonTip(5000);
                        }
                        catch { }

                        ShowStatusInOutput($"[Recordatorio] {mensaje}");
                        notifiedKeys.Add(key);
                    }
                }
            }
        }

        private void ShowStatusInOutput(string texto)
        {
            txtOutput.Text = $"{DateTime.Now:G} - {texto}{Environment.NewLine}{txtOutput.Text}";
        }

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
    }
}
