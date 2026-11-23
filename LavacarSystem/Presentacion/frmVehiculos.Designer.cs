namespace LavacarSystem.Presentacion
{
    partial class frmVehiculos
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
            lblPlaca = new Label();
            txtPlaca = new TextBox();
            lblMarca = new Label();
            txtMarca = new TextBox();
            lblCliente = new Label();
            cmbCliente = new ComboBox();
            btnGuardar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            dgvVehiculos = new DataGridView();
            lblCantidad = new Label();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(720, 40);
            lblTitulo.Text = "Gestión de vehículos";
            // 
            // lblPlaca
            // 
            lblPlaca.AutoSize = true;
            lblPlaca.Location = new Point(20, 72);
            lblPlaca.Name = "lblPlaca";
            lblPlaca.Text = "Placa:";
            // 
            // txtPlaca
            // 
            txtPlaca.CharacterCasing = CharacterCasing.Upper;
            txtPlaca.Location = new Point(110, 68);
            txtPlaca.MaxLength = 10;
            txtPlaca.Name = "txtPlaca";
            txtPlaca.PlaceholderText = "ABC123";
            txtPlaca.Size = new Size(150, 23);
            txtPlaca.TabIndex = 1;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(20, 107);
            lblMarca.Name = "lblMarca";
            lblMarca.Text = "Marca:";
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(110, 103);
            txtMarca.MaxLength = 50;
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(200, 23);
            txtMarca.TabIndex = 2;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(20, 142);
            lblCliente.Name = "lblCliente";
            lblCliente.Text = "Dueño:";
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.Location = new Point(110, 138);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(300, 23);
            cmbCliente.TabIndex = 3;
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
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(20, 242);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(110, 238);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Placa, marca o dueño";
            txtBuscar.Size = new Size(300, 23);
            txtBuscar.TabIndex = 8;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dgvVehiculos
            // 
            dgvVehiculos.AllowUserToAddRows = false;
            dgvVehiculos.AllowUserToDeleteRows = false;
            dgvVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehiculos.Location = new Point(20, 275);
            dgvVehiculos.MultiSelect = false;
            dgvVehiculos.Name = "dgvVehiculos";
            dgvVehiculos.ReadOnly = true;
            dgvVehiculos.RowHeadersVisible = false;
            dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehiculos.Size = new Size(720, 215);
            dgvVehiculos.TabIndex = 9;
            dgvVehiculos.CellClick += dgvVehiculos_CellClick;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(20, 500);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Text = "Vehículos encontrados: 0";
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // frmVehiculos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 530);
            Controls.Add(lblTitulo);
            Controls.Add(lblPlaca);
            Controls.Add(txtPlaca);
            Controls.Add(lblMarca);
            Controls.Add(txtMarca);
            Controls.Add(lblCliente);
            Controls.Add(cmbCliente);
            Controls.Add(btnGuardar);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(btnLimpiar);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvVehiculos);
            Controls.Add(lblCantidad);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmVehiculos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de vehículos";
            Load += frmVehiculos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblPlaca;
        private TextBox txtPlaca;
        private Label lblMarca;
        private TextBox txtMarca;
        private Label lblCliente;
        private ComboBox cmbCliente;
        private Button btnGuardar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private DataGridView dgvVehiculos;
        private Label lblCantidad;
        private ErrorProvider errorProvider;
    }
}