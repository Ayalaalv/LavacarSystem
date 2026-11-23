using LavacarSystem.Entidades;
using LavacarSystem.Logica;
using Microsoft.Data.SqlClient;

namespace LavacarSystem.Presentacion
{
    public partial class frmClientes : Form
    {
        private readonly ClienteLogica clienteLogica = new ClienteLogica();
        private int idClienteSeleccionado = 0;

        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                clienteLogica.GuardarCliente(txtNombre.Text, txtTelefono.Text);
                MostrarExito("Cliente guardado correctamente.");
                LimpiarFormulario();
                CargarClientes();
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
                clienteLogica.ModificarCliente(idClienteSeleccionado, txtNombre.Text, txtTelefono.Text);
                MostrarExito("Cliente modificado correctamente.");
                LimpiarFormulario();
                CargarClientes();
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
            if (idClienteSeleccionado == 0)
            {
                MostrarAdvertencia("Seleccione un cliente de la lista para eliminarlo.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar al cliente " + txtNombre.Text + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                clienteLogica.EliminarCliente(idClienteSeleccionado);
                MostrarExito("Cliente eliminado correctamente.");
                LimpiarFormulario();
                CargarClientes();
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
            CargarClientes();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvClientes.Rows[e.RowIndex].DataBoundItem is Cliente cliente)
            {
                idClienteSeleccionado = cliente.Id;
                txtNombre.Text = cliente.Nombre;
                txtTelefono.Text = cliente.Telefono;
                errorProvider.Clear();
            }
        }

        private void CargarClientes()
        {
            try
            {
                List<Cliente> clientes = clienteLogica.BuscarClientes(txtBuscar.Text);
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = clientes;
                ConfigurarColumnas();
                lblCantidad.Text = "Clientes encontrados: " + clientes.Count;
            }
            catch (SqlException)
            {
                MostrarErrorBaseDatos();
            }
        }

        private void ConfigurarColumnas()
        {
            foreach (DataGridViewColumn columna in dgvClientes.Columns)
            {
                switch (columna.Name)
                {
                    case "Id":
                        columna.HeaderText = "Código";
                        columna.DisplayIndex = 0;
                        columna.FillWeight = 30;
                        break;
                    case "Telefono":
                        columna.HeaderText = "Teléfono";
                        break;
                    case "Vehiculos":
                        columna.Visible = false;
                        break;
                }
            }
        }

        private bool ValidarFormulario()
        {
            string errorNombre = clienteLogica.ValidarNombre(txtNombre.Text);
            string errorTelefono = clienteLogica.ValidarTelefono(txtTelefono.Text);

            errorProvider.SetError(txtNombre, errorNombre);
            errorProvider.SetError(txtTelefono, errorTelefono);

            return errorNombre == string.Empty && errorTelefono == string.Empty;
        }

        private void LimpiarFormulario()
        {
            idClienteSeleccionado = 0;
            txtNombre.Clear();
            txtTelefono.Clear();
            errorProvider.Clear();
            dgvClientes.ClearSelection();
            txtNombre.Focus();
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