using LavacarSystem.Entidades;
using LavacarSystem.Logica;
using Microsoft.Data.SqlClient;

namespace LavacarSystem.Presentacion
{
    public partial class frmServicios : Form
    {
        private readonly ServicioLogica servicioLogica = new ServicioLogica();
        private int idServicioSeleccionado = 0;

        public frmServicios()
        {
            InitializeComponent();
        }

        private void frmServicios_Load(object sender, EventArgs e)
        {
            CargarServicios();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                servicioLogica.GuardarServicio(txtNombre.Text, txtPrecio.Text);
                MostrarExito("Servicio guardado correctamente.");
                LimpiarFormulario();
                CargarServicios();
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
                servicioLogica.ModificarServicio(idServicioSeleccionado, txtNombre.Text, txtPrecio.Text);
                MostrarExito("Servicio modificado correctamente.");
                LimpiarFormulario();
                CargarServicios();
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
            if (idServicioSeleccionado == 0)
            {
                MostrarAdvertencia("Seleccione un servicio de la lista para eliminarlo.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar el servicio " + txtNombre.Text + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                servicioLogica.EliminarServicio(idServicioSeleccionado);
                MostrarExito("Servicio eliminado correctamente.");
                LimpiarFormulario();
                CargarServicios();
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
            CargarServicios();
        }

        private void dgvServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvServicios.Rows[e.RowIndex].DataBoundItem is Servicio servicio)
            {
                idServicioSeleccionado = servicio.Id;
                txtNombre.Text = servicio.Nombre;
                txtPrecio.Text = servicio.Precio.ToString("0.##");
                errorProvider.Clear();
            }
        }

        private void CargarServicios()
        {
            try
            {
                List<Servicio> servicios = servicioLogica.BuscarServicios(txtBuscar.Text);
                dgvServicios.DataSource = null;
                dgvServicios.DataSource = servicios;
                ConfigurarColumnas();
                lblCantidad.Text = "Servicios encontrados: " + servicios.Count;
            }
            catch (SqlException)
            {
                MostrarErrorBaseDatos();
            }
        }

        private void ConfigurarColumnas()
        {
            foreach (DataGridViewColumn columna in dgvServicios.Columns)
            {
                switch (columna.Name)
                {
                    case "Id":
                        columna.HeaderText = "Código";
                        columna.DisplayIndex = 0;
                        columna.FillWeight = 30;
                        break;
                    case "Nombre":
                        columna.HeaderText = "Servicio";
                        break;
                    case "Precio":
                        columna.DefaultCellStyle.Format = "₡#,##0.00";
                        columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                }
            }
        }

        private bool ValidarFormulario()
        {
            string errorNombre = servicioLogica.ValidarNombre(txtNombre.Text);
            string errorPrecio = servicioLogica.ValidarPrecio(txtPrecio.Text);

            errorProvider.SetError(txtNombre, errorNombre);
            errorProvider.SetError(txtPrecio, errorPrecio);

            return errorNombre == string.Empty && errorPrecio == string.Empty;
        }

        private void LimpiarFormulario()
        {
            idServicioSeleccionado = 0;
            txtNombre.Clear();
            txtPrecio.Clear();
            errorProvider.Clear();
            dgvServicios.ClearSelection();
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