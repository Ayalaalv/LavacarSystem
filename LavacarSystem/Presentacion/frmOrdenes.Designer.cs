namespace LavacarSystem.Presentacion
{
    partial class frmOrdenes
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
            components = new System.ComponentModel.Container();
            lblTitulo = new Label();
            lblVehiculo = new Label();
            cmbVehiculo = new ComboBox();
            lblServicio = new Label();
            cmbServicio = new ComboBox();
            lblTotalOrden = new Label();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            btnGuardar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            lblFiltroEstado = new Label();
            cmbFiltroEstado = new ComboBox();
            lblBuscarPlaca = new Label();
            txtBuscarPlaca = new TextBox();
            dgvOrdenes = new DataGridView();
            lblCantidad = new Label();
            lblTotalFiltrado = new Label();
            lblVentasDelDia = new Label();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(860, 40);
            lblTitulo.Text = "Órdenes de lavado";
            // 
            // lblVehiculo
            // 
            lblVehiculo.AutoSize = true;
            lblVehiculo.Location = new Point(20, 72);
            lblVehiculo.Name = "lblVehiculo";
            lblVehiculo.Text = "Vehículo:";
            // 
            // cmbVehiculo
            // 
            cmbVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVehiculo.Location = new Point(110, 68);
            cmbVehiculo.Name = "cmbVehiculo";
            cmbVehiculo.Size = new Size(200, 23);
            cmbVehiculo.TabIndex = 1;
            // 
            // lblServicio
            // 
            lblServicio.AutoSize = true;
            lblServicio.Location = new Point(20, 107);
            lblServicio.Name = "lblServicio";
            lblServicio.Text = "Servicio:";
            // 
            // cmbServicio
            // 
            cmbServicio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServicio.Location = new Point(110, 103);
            cmbServicio.Name = "cmbServicio";
            cmbServicio.Size = new Size(250, 23);
            cmbServicio.TabIndex = 2;
            cmbServicio.SelectedIndexChanged += cmbServicio_SelectedIndexChanged;
            // 
            // lblTotalOrden
            // 
            lblTotalOrden.AutoSize = true;
            lblTotalOrden.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalOrden.Location = new Point(390, 104);
            lblTotalOrden.Name = "lblTotalOrden";
            lblTotalOrden.Text = "Total a cobrar: ₡0.00";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(20, 142);
            lblEstado.Name = "lblEstado";
            lblEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Location = new Point(110, 138);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(150, 23);
            cmbEstado.TabIndex = 3;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(20, 180);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 35);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(150, 180);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(120, 35);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(280, 180);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(120, 35);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(410, 180);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(120, 35);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblFiltroEstado
            // 
            lblFiltroEstado.AutoSize = true;
            lblFiltroEstado.Location = new Point(20, 242);
            lblFiltroEstado.Name = "lblFiltroEstado";
            lblFiltroEstado.Text = "Filtrar estado:";
            // 
            // cmbFiltroEstado
            // 
            cmbFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroEstado.Location = new Point(110, 238);
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.Size = new Size(150, 23);
            cmbFiltroEstado.TabIndex = 8;
            cmbFiltroEstado.SelectedIndexChanged += cmbFiltroEstado_SelectedIndexChanged;
            // 
            // lblBuscarPlaca
            // 
            lblBuscarPlaca.AutoSize = true;
            lblBuscarPlaca.Location = new Point(290, 242);
            lblBuscarPlaca.Name = "lblBuscarPlaca";
            lblBuscarPlaca.Text = "Placa:";
            // 
            // txtBuscarPlaca
            // 
            txtBuscarPlaca.CharacterCasing = CharacterCasing.Upper;
            txtBuscarPlaca.Location = new Point(340, 238);
            txtBuscarPlaca.MaxLength = 10;
            txtBuscarPlaca.Name = "txtBuscarPlaca";
            txtBuscarPlaca.Size = new Size(150, 23);
            txtBuscarPlaca.TabIndex = 9;
            txtBuscarPlaca.TextChanged += txtBuscarPlaca_TextChanged;
            // 
            // dgvOrdenes
            // 
            dgvOrdenes.AllowUserToAddRows = false;
            dgvOrdenes.AllowUserToDeleteRows = false;
            dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdenes.Location = new Point(20, 275);
            dgvOrdenes.MultiSelect = false;
            dgvOrdenes.Name = "dgvOrdenes";
            dgvOrdenes.ReadOnly = true;
            dgvOrdenes.RowHeadersVisible = false;
            dgvOrdenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenes.Size = new Size(860, 240);
            dgvOrdenes.TabIndex = 10;
            dgvOrdenes.CellClick += dgvOrdenes_CellClick;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(20, 530);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Text = "Órdenes: 0";
            // 
            // lblTotalFiltrado
            // 
            lblTotalFiltrado.AutoSize = true;
            lblTotalFiltrado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalFiltrado.Location = new Point(250, 528);
            lblTotalFiltrado.Name = "lblTotalFiltrado";
            lblTotalFiltrado.Text = "Total: ₡0.00";
            // 
            // lblVentasDelDia
            // 
            lblVentasDelDia.AutoSize = true;
            lblVentasDelDia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblVentasDelDia.Location = new Point(560, 528);
            lblVentasDelDia.Name = "lblVentasDelDia";
            lblVentasDelDia.Text = "Ventas de hoy: ₡0.00";
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // frmOrdenes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 565);
            Controls.Add(lblTitulo);
            Controls.Add(lblVehiculo);
            Controls.Add(cmbVehiculo);
            Controls.Add(lblServicio);
            Controls.Add(cmbServicio);
            Controls.Add(lblTotalOrden);
            Controls.Add(lblEstado);
            Controls.Add(cmbEstado);
            Controls.Add(btnGuardar);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(btnLimpiar);
            Controls.Add(lblFiltroEstado);
            Controls.Add(cmbFiltroEstado);
            Controls.Add(lblBuscarPlaca);
            Controls.Add(txtBuscarPlaca);
            Controls.Add(dgvOrdenes);
            Controls.Add(lblCantidad);
            Controls.Add(lblTotalFiltrado);
            Controls.Add(lblVentasDelDia);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmOrdenes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Órdenes de lavado";
            Load += frmOrdenes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblVehiculo;
        private ComboBox cmbVehiculo;
        private Label lblServicio;
        private ComboBox cmbServicio;
        private Label lblTotalOrden;
        private Label lblEstado;
        private ComboBox cmbEstado;
        private Button btnGuardar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Label lblFiltroEstado;
        private ComboBox cmbFiltroEstado;
        private Label lblBuscarPlaca;
        private TextBox txtBuscarPlaca;
        private DataGridView dgvOrdenes;
        private Label lblCantidad;
        private Label lblTotalFiltrado;
        private Label lblVentasDelDia;
        private ErrorProvider errorProvider;
    }
}