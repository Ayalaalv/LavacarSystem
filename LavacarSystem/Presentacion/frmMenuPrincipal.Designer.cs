namespace LavacarSystem.Presentacion
{
    partial class frmMenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            btnClientes = new Button();
            btnVehiculos = new Button();
            btnServicios = new Button();
            btnOrdenes = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(420, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "LavacarSystem";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClientes
            // 
            btnClientes.Location = new Point(80, 100);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(300, 45);
            btnClientes.TabIndex = 1;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnVehiculos
            // 
            btnVehiculos.Location = new Point(80, 155);
            btnVehiculos.Name = "btnVehiculos";
            btnVehiculos.Size = new Size(300, 45);
            btnVehiculos.TabIndex = 2;
            btnVehiculos.Text = "Vehículos";
            btnVehiculos.UseVisualStyleBackColor = true;
            btnVehiculos.Click += btnVehiculos_Click;
            // 
            // btnServicios
            // 
            btnServicios.Location = new Point(80, 210);
            btnServicios.Name = "btnServicios";
            btnServicios.Size = new Size(300, 45);
            btnServicios.TabIndex = 3;
            btnServicios.Text = "Servicios";
            btnServicios.UseVisualStyleBackColor = true;
            btnServicios.Click += btnServicios_Click;
            // 
            // btnOrdenes
            // 
            btnOrdenes.Location = new Point(80, 265);
            btnOrdenes.Name = "btnOrdenes";
            btnOrdenes.Size = new Size(300, 45);
            btnOrdenes.TabIndex = 4;
            btnOrdenes.Text = "Órdenes";
            btnOrdenes.UseVisualStyleBackColor = true;
            btnOrdenes.Click += btnOrdenes_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(80, 330);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(300, 45);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 410);
            Controls.Add(lblTitulo);
            Controls.Add(btnClientes);
            Controls.Add(btnVehiculos);
            Controls.Add(btnServicios);
            Controls.Add(btnOrdenes);
            Controls.Add(btnSalir);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LavacarSystem - Menú principal";
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Button btnClientes;
        private Button btnVehiculos;
        private Button btnServicios;
        private Button btnOrdenes;
        private Button btnSalir;
    }
}