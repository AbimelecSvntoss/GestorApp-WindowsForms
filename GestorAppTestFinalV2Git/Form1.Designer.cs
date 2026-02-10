using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestorAppTestFinalV2Git
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblCosto;
        private TextBox txtCosto;
        private Label lblFecha;
        private DateTimePicker dtpFechaCobro;
        private Button btnAgregar;
        private Button btnMostrar;
        private Button btnGuardar;
        private Button btnCargar;
        private TextBox txtOutput;

        // Nuevos controles para recordatorios
        private CheckBox chkActivarRecordatorios;
        private Label lblRecordatorioDias;
        private NumericUpDown nudDiasAntes;
        private NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer timerRecordatorio;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblCosto = new Label();
            txtCosto = new TextBox();
            lblFecha = new Label();
            dtpFechaCobro = new DateTimePicker();
            btnAgregar = new Button();
            btnMostrar = new Button();
            btnGuardar = new Button();
            btnCargar = new Button();
            txtOutput = new TextBox();
            chkActivarRecordatorios = new CheckBox();
            lblRecordatorioDias = new Label();
            nudDiasAntes = new NumericUpDown();
            notifyIcon = new NotifyIcon(components);
            timerRecordatorio = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)nudDiasAntes).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Dubai", 8.999999F);
            lblNombre.Location = new Point(20, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(68, 21);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Suscripción:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Dubai", 8.999999F);
            txtNombre.Location = new Point(130, 16);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(560, 28);
            txtNombre.TabIndex = 1;
            // 
            // lblCosto
            // 
            lblCosto.AutoSize = true;
            lblCosto.Font = new Font("Dubai", 8.999999F);
            lblCosto.Location = new Point(20, 60);
            lblCosto.Name = "lblCosto";
            lblCosto.Size = new Size(84, 21);
            lblCosto.TabIndex = 2;
            lblCosto.Text = "Costo mensual:";
            // 
            // txtCosto
            // 
            txtCosto.Font = new Font("Dubai", 8.999999F);
            txtCosto.Location = new Point(130, 56);
            txtCosto.Name = "txtCosto";
            txtCosto.PlaceholderText = "Ej: 129.99";
            txtCosto.Size = new Size(200, 28);
            txtCosto.TabIndex = 3;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Dubai", 8.999999F);
            lblFecha.Location = new Point(20, 100);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(86, 21);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha de cobro:";
            // 
            // dtpFechaCobro
            // 
            dtpFechaCobro.Font = new Font("Dubai", 8.999999F);
            dtpFechaCobro.Format = DateTimePickerFormat.Short;
            dtpFechaCobro.Location = new Point(130, 96);
            dtpFechaCobro.Name = "dtpFechaCobro";
            dtpFechaCobro.Size = new Size(200, 28);
            dtpFechaCobro.TabIndex = 5;
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Dubai", 8.999999F);
            btnAgregar.Location = new Point(65, 136);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(200, 34);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar suscripción";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnMostrar
            // 
            btnMostrar.Font = new Font("Dubai", 8.999999F);
            btnMostrar.Location = new Point(285, 136);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(200, 34);
            btnMostrar.TabIndex = 7;
            btnMostrar.Text = "Mostrar detalles y total";
            btnMostrar.Click += btnMostrar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Dubai", 8.999999F);
            btnGuardar.Location = new Point(515, 136);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(133, 34);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar Suscripciones";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCargar
            // 
            btnCargar.Font = new Font("Dubai", 8.999999F);
            btnCargar.Location = new Point(515, 186);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(133, 34);
            btnCargar.TabIndex = 9;
            btnCargar.Text = "Cargar Suscripciones";
            btnCargar.Click += btnCargar_Click;
            // 
            // txtOutput
            // 
            txtOutput.BackColor = SystemColors.ButtonFace;
            txtOutput.Font = new Font("Dubai", 8.999999F);
            txtOutput.Location = new Point(20, 230);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(680, 270);
            txtOutput.TabIndex = 13;
            // 
            // chkActivarRecordatorios
            // 
            chkActivarRecordatorios.AutoSize = true;
            chkActivarRecordatorios.Font = new Font("Dubai", 8.999999F);
            chkActivarRecordatorios.Location = new Point(65, 186);
            chkActivarRecordatorios.Name = "chkActivarRecordatorios";
            chkActivarRecordatorios.Size = new Size(132, 25);
            chkActivarRecordatorios.TabIndex = 10;
            chkActivarRecordatorios.Text = "Activar recordatorios";
            chkActivarRecordatorios.CheckedChanged += chkActivarRecordatorios_CheckedChanged;
            // 
            // lblRecordatorioDias
            // 
            lblRecordatorioDias.AutoSize = true;
            lblRecordatorioDias.Font = new Font("Dubai", 8.999999F);
            lblRecordatorioDias.Location = new Point(285, 188);
            lblRecordatorioDias.Name = "lblRecordatorioDias";
            lblRecordatorioDias.Size = new Size(64, 21);
            lblRecordatorioDias.TabIndex = 11;
            lblRecordatorioDias.Text = "Días antes:";
            // 
            // nudDiasAntes
            // 
            nudDiasAntes.Location = new Point(365, 184);
            nudDiasAntes.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            nudDiasAntes.Name = "nudDiasAntes";
            nudDiasAntes.Size = new Size(60, 23);
            nudDiasAntes.TabIndex = 12;
            nudDiasAntes.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // notifyIcon
            // 
            notifyIcon.BalloonTipTitle = "Gestor de Suscripciones";
            notifyIcon.Text = "Gestor de Suscripciones";
            // 
            // timerRecordatorio
            // 
            timerRecordatorio.Interval = 60000;
            timerRecordatorio.Tick += timerRecordatorio_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(720, 520);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblCosto);
            Controls.Add(txtCosto);
            Controls.Add(lblFecha);
            Controls.Add(dtpFechaCobro);
            Controls.Add(btnAgregar);
            Controls.Add(btnMostrar);
            Controls.Add(btnGuardar);
            Controls.Add(btnCargar);
            Controls.Add(chkActivarRecordatorios);
            Controls.Add(lblRecordatorioDias);
            Controls.Add(nudDiasAntes);
            Controls.Add(txtOutput);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestor de Gastos y Suscripciones 2026";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)nudDiasAntes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}