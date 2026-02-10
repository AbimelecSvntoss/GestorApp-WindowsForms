using System;
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
            this.lblNombre = new Label();
            this.txtNombre = new TextBox();
            this.lblCosto = new Label();
            this.txtCosto = new TextBox();
            this.lblFecha = new Label();
            this.dtpFechaCobro = new DateTimePicker();
            this.btnAgregar = new Button();
            this.btnMostrar = new Button();
            this.btnGuardar = new Button();
            this.btnCargar = new Button();
            this.txtOutput = new TextBox();

            // 
            // Form
            // 
            this.Text = "Gestor de Suscripciones";
            this.ClientSize = new System.Drawing.Size(720, 460);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = AutoScaleMode.Font;

            // 
            // lblNombre
            // 
            this.lblNombre.Text = "Suscripción:";
            this.lblNombre.Location = new System.Drawing.Point(20, 20);
            this.lblNombre.AutoSize = true;

            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(130, 16);
            this.txtNombre.Width = 560;

            // 
            // lblCosto
            // 
            this.lblCosto.Text = "Costo mensual:";
            this.lblCosto.Location = new System.Drawing.Point(20, 60);
            this.lblCosto.AutoSize = true;

            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(130, 56);
            this.txtCosto.Width = 200;
            this.txtCosto.PlaceholderText = "Ej: 129.99";

            // 
            // lblFecha
            // 
            this.lblFecha.Text = "Fecha de cobro:";
            this.lblFecha.Location = new System.Drawing.Point(20, 100);
            this.lblFecha.AutoSize = true;

            // 
            // dtpFechaCobro
            // 
            this.dtpFechaCobro.Location = new System.Drawing.Point(130, 96);
            this.dtpFechaCobro.Format = DateTimePickerFormat.Short;

            // 
            // btnAgregar
            // 
            this.btnAgregar.Text = "Agregar suscripción";
            this.btnAgregar.Location = new System.Drawing.Point(20, 140);
            this.btnAgregar.Size = new System.Drawing.Size(200, 34);
            this.btnAgregar.Click += new EventHandler(this.btnAgregar_Click);

            // 
            // btnMostrar
            // 
            this.btnMostrar.Text = "Mostrar detalles y total";
            this.btnMostrar.Location = new System.Drawing.Point(240, 140);
            this.btnMostrar.Size = new System.Drawing.Size(200, 34);
            this.btnMostrar.Click += new EventHandler(this.btnMostrar_Click);

            // 
            // btnGuardar
            // 
            this.btnGuardar.Text = "Guardar (JSON)";
            this.btnGuardar.Location = new System.Drawing.Point(460, 140);
            this.btnGuardar.Size = new System.Drawing.Size(110, 34);
            this.btnGuardar.Click += new EventHandler(this.btnGuardar_Click);

            // 
            // btnCargar
            // 
            this.btnCargar.Text = "Cargar (JSON)";
            this.btnCargar.Location = new System.Drawing.Point(580, 140);
            this.btnCargar.Size = new System.Drawing.Size(110, 34);
            this.btnCargar.Click += new EventHandler(this.btnCargar_Click);

            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(20, 190);
            this.txtOutput.Size = new System.Drawing.Size(680, 250);
            this.txtOutput.Multiline = true;
            this.txtOutput.ScrollBars = ScrollBars.Vertical;
            this.txtOutput.ReadOnly = true;

            // Add controls to form
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFechaCobro);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.txtOutput);
        }
    }
}
