using LavacarSystem.Entidades;
using LavacarSystem.Logica;
using Microsoft.Data.SqlClient;

namespace LavacarSystem.Presentacion
{
    public partial class frmVehiculos : Form
    {
        private readonly VehiculoLogica vehiculoLogica = new VehiculoLogica();
        private readonly ClienteLogica clienteLogica = new ClienteLogica();
        private int idVehiculoSeleccionado = 0;

        public frmVehiculos()
        {
            InitializeComponent();
        }

        private void frmVehiculos_Load(object sender, EventArgs e)
        {
            CargarClientesEnCombo();
            CargarVehiculos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                vehiculoLogica.GuardarVehiculo(txtPlaca.Text, txtMarca.Text, ObtenerIdClienteSeleccionado());
                MostrarExito("Vehículo guardado correctamente.");
                LimpiarFormulario();
                CargarVehiculos();
            }
            catch (ArgumentException ex)
            {
                MostrarAdvertencia(ex.Message);
            }
            catch (SqlException)
            {
                MostrarErrorBaseDatos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                vehiculoLogica.ModificarVehiculo(idVehiculoSeleccionado, txtPlaca.Text, txtMarca.Text,
                    ObtenerIdClienteSeleccionado());
                MostrarExito("Vehículo modificado correctamente.");
                LimpiarFormulario();
                CargarVehiculos();
            }
            catch (ArgumentException ex)
            {
                MostrarAdvertencia(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MostrarAdvertencia(ex.Message);
            }
            catch (SqlException)
            {
                MostrarErrorBaseDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idVehiculoSeleccionado == 0)
            {
                MostrarAdvertencia("Seleccione un vehículo de la lista para eliminarlo.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar el vehículo con placa " + txtPlaca.Text + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                vehiculoLogica.EliminarVehiculo(idVehiculoSeleccionado);
                MostrarExito("Vehículo eliminado correctamente.");
                LimpiarFormulario();
                CargarVehiculos();
            }
            catch (InvalidOperationException ex)
            {
                MostrarAdvertencia(ex.Message);
            }
            catch (SqlException)
            {
                MostrarErrorBaseDatos();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarVehiculos();
        }

        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvVehiculos.Rows[e.RowIndex].DataBoundItem is Vehiculo vehiculo)
            {
                idVehiculoSeleccionado = vehiculo.Id;
                txtPlaca.Text = vehiculo.Placa;
                txtMarca.Text = vehiculo.Marca;
                cmbCliente.SelectedValue = vehiculo.IdCliente;
                errorProvider.Clear();
            }
        }

        private void CargarClientesEnCombo()
        {
            try
            {
                cmbCliente.DisplayMember = "Nombre";
                cmbCliente.ValueMember = "Id";
                cmbCliente.DataSource = clienteLogica.ListarClientes();
                cmbCliente.SelectedIndex = -1;
            }
            catch (SqlException)
            {
                MostrarErrorBaseDatos();
            }
        }

        private void CargarVehiculos()
        {
            try
            {
                List<Vehiculo> vehiculos = vehiculoLogica.BuscarVehiculos(txtBuscar.Text);
                dgvVehiculos.DataSource = null;
                dgvVehiculos.DataSource = vehiculos;
                ConfigurarColumnas();
                lblCantidad.Text = "Vehículos encontrados: " + vehiculos.Count;
            }
            catch (SqlException)
            {
                MostrarErrorBaseDatos();
            }
        }

        private void ConfigurarColumnas()
        {
            foreach (DataGridViewColumn columna in dgvVehiculos.Columns)
            {
                switch (columna.Name)
                {
                    case "Id":
                        columna.HeaderText = "Código";
                        columna.DisplayIndex = 0;
                        columna.FillWeight = 30;
                        break;
                    case "NombreCliente":
                        columna.HeaderText = "Dueño";
                        break;
                    case "IdCliente":
                        columna.Visible = false;
                        break;
                }
            }
        }

        private int ObtenerIdClienteSeleccionado()
        {
            if (cmbCliente.SelectedValue is int idCliente)
                return idCliente;

            return 0;
        }

        private bool ValidarFormulario()
        {
            string errorPlaca = vehiculoLogica.ValidarPlaca(txtPlaca.Text);
            string errorMarca = vehiculoLogica.ValidarMarca(txtMarca.Text);
            string errorCliente = vehiculoLogica.ValidarCliente(ObtenerIdClienteSeleccionado());

            errorProvider.SetError(txtPlaca, errorPlaca);
            errorProvider.SetError(txtMarca, errorMarca);
            errorProvider.SetError(cmbCliente, errorCliente);

            return errorPlaca == string.Empty && errorMarca == string.Empty && errorCliente == string.Empty;
        }

        private void LimpiarFormulario()
        {
            idVehiculoSeleccionado = 0;
            txtPlaca.Clear();
            txtMarca.Clear();
            cmbCliente.SelectedIndex = -1;
            errorProvider.Clear();
            dgvVehiculos.ClearSelection();
            txtPlaca.Focus();
        }

        private void MostrarExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MostrarAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void MostrarErrorBaseDatos()
        {
            MessageBox.Show(
                "No se pudo completar la operación con la base de datos. Verifique la conexión e intente de nuevo.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}