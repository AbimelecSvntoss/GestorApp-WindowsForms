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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblCosto = new Label();
            txtCosto = new TextBox();
            lblFecha = new Label();
            dtpFechaCobro = new DateTimePicker();
            btnAgregar = new Button();
            btnMostrar = new Button();
            txtOutput = new TextBox();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Dubai", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.ForeColor = SystemColors.ControlText;
            lblNombre.Location = new Point(17, 28);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(68, 21);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Suscripción:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(111, 22);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(446, 28);
            txtNombre.TabIndex = 1;
            // 
            // lblCosto
            // 
            lblCosto.AutoSize = true;
            lblCosto.Font = new Font("Dubai", 9F);
            lblCosto.ForeColor = SystemColors.ControlText;
            lblCosto.Location = new Point(17, 84);
            lblCosto.Name = "lblCosto";
            lblCosto.Size = new Size(84, 21);
            lblCosto.TabIndex = 2;
            lblCosto.Text = "Costo mensual:";
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(111, 78);
            txtCosto.Margin = new Padding(3, 4, 3, 4);
            txtCosto.Name = "txtCosto";
            txtCosto.PlaceholderText = "Ej: 129.99";
            txtCosto.Size = new Size(172, 28);
            txtCosto.TabIndex = 3;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Dubai", 9F);
            lblFecha.ForeColor = SystemColors.ControlText;
            lblFecha.Location = new Point(17, 140);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(86, 21);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha de cobro:";
            // 
            // dtpFechaCobro
            // 
            dtpFechaCobro.Format = DateTimePickerFormat.Short;
            dtpFechaCobro.Location = new Point(111, 134);
            dtpFechaCobro.Margin = new Padding(3, 4, 3, 4);
            dtpFechaCobro.Name = "dtpFechaCobro";
            dtpFechaCobro.Size = new Size(172, 28);
            dtpFechaCobro.TabIndex = 5;
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Dubai", 9F);
            btnAgregar.ForeColor = SystemColors.ControlText;
            btnAgregar.Location = new Point(17, 196);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(189, 45);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar suscripción";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnMostrar
            // 
            btnMostrar.Font = new Font("Dubai", 9F);
            btnMostrar.ForeColor = SystemColors.ControlText;
            btnMostrar.Location = new Point(223, 196);
            btnMostrar.Margin = new Padding(3, 4, 3, 4);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(189, 45);
            btnMostrar.TabIndex = 7;
            btnMostrar.Text = "Mostrar detalles y total";
            btnMostrar.Click += btnMostrar_Click;
            // 
            // txtOutput
            // 
            txtOutput.BackColor = SystemColors.Control;
            txtOutput.Font = new Font("Dubai", 9F);
            txtOutput.ForeColor = SystemColors.ControlText;
            txtOutput.Location = new Point(17, 266);
            txtOutput.Margin = new Padding(3, 4, 3, 4);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(541, 292);
            txtOutput.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(600, 588);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblCosto);
            Controls.Add(txtCosto);
            Controls.Add(lblFecha);
            Controls.Add(dtpFechaCobro);
            Controls.Add(btnAgregar);
            Controls.Add(btnMostrar);
            Controls.Add(txtOutput);
            Font = new Font("Dubai", 9F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Gestor de Gastos/Suscripciones 2026";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
