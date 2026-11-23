namespace LavacarSystem.Presentacion
{
    partial class frmClientes
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            btnGuardar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            dgvClientes = new DataGridView();
            lblCantidad = new Label();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(720, 40);
            lblTitulo.Text = "Gestión de clientes";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(20, 72);
            lblNombre.Name = "lblNombre";
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(110, 68);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(300, 23);
            txtNombre.TabIndex = 1;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(20, 107);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(110, 103);
            txtTelefono.MaxLength = 9;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "8888-1111";
            txtTelefono.Size = new Size(150, 23);
            txtTelefono.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(20, 145);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 35);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(150, 145);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(120, 35);
            btnModificar.TabIndex = 4;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(280, 145);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(120, 35);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(410, 145);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(120, 35);
            btnLimpiar.TabIndex = 6;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(20, 207);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(110, 203);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Nombre o teléfono";
            txtBuscar.Size = new Size(300, 23);
            txtBuscar.TabIndex = 7;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.Location = new Point(20, 240);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(720, 240);
            dgvClientes.TabIndex = 8;
            dgvClientes.CellClick += dgvClientes_CellClick;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(20, 490);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Text = "Clientes encontrados: 0";
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // frmClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 520);
            Controls.Add(lblTitulo);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(btnGuardar);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(btnLimpiar);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvClientes);
            Controls.Add(lblCantidad);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmClientes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de clientes";
            Load += frmClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Button btnGuardar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private DataGridView dgvClientes;
        private Label lblCantidad;
        private ErrorProvider errorProvider;
    }
}