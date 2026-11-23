using LavacarSystem.Entidades;
using LavacarSystem.Logica;
using Microsoft.Data.SqlClient;

namespace LavacarSystem.Presentacion
{
    public partial class frmOrdenes : Form
    {
        private const string FormatoColones = "₡#,##0.00";
        private readonly OrdenLogica ordenLogica = new OrdenLogica();
        private readonly VehiculoLogica vehiculoLogica = new VehiculoLogica();
        private readonly ServicioLogica servicioLogica = new ServicioLogica();
        private int idOrdenSeleccionada = 0;

        public frmOrdenes()
        {
            InitializeComponent();
        }

        private void frmOrdenes_Load(object sender, EventArgs e)
        {
            CargarListas();
            CargarOrdenes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                ordenLogica.GuardarOrden(ObtenerIdSeleccionado(cmbVehiculo),
                    ObtenerIdSeleccionado(cmbServicio), cmbEstado.Text);
                MostrarExito("Orden registrada correctamente.");
                LimpiarFormulario();
                CargarOrdenes();
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
                ordenLogica.ModificarOrden(idOrdenSeleccionada, ObtenerIdSeleccionado(cmbVehiculo),
                    ObtenerIdSeleccionado(cmbServicio), cmbEstado.Text);
                MostrarExito("Orden modificada correctamente.");
                LimpiarFormulario();
                CargarOrdenes();
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
            if (idOrdenSeleccionada == 0)
            {
                MostrarAdvertencia("Seleccione una orden de la lista para eliminarla.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar la orden N.º " + idOrdenSeleccionada + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                ordenLogica.EliminarOrden(idOrdenSeleccionada);
                MostrarExito("Orden eliminada correctamente.");
                LimpiarFormulario();
                CargarOrdenes();
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

        private void cmbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarTotalOrden();
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarOrdenes();
        }

        private void txtBuscarPlaca_TextChanged(object sender, EventArgs e)
        {
            CargarOrdenes();
        }

        private void dgvOrdenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvOrdenes.Rows[e.RowIndex].DataBoundItem is Orden orden)
            {
                idOrdenSeleccionada = orden.Id;
                cmbVehiculo.SelectedValue = orden.Vehiculo.Id;
                cmbServicio.SelectedValue = orden.Servicio.Id;
                cmbEstado.SelectedItem = orden.Estado;
                errorProvider.Clear();
            }
        }

        private void CargarListas()
        {
            cmbEstado.Items.AddRange(Orden.EstadosValidos);
            cmbFiltroEstado.Items.Add("Todos");
            cmbFiltroEstado.Items.AddRange(Orden.EstadosValidos);
            cmbFiltroEstado.SelectedIndex = 0;

            try
            {
                cmbVehiculo.DisplayMember = "Placa";
                cmbVehiculo.ValueMember = "Id";
                cmbVehiculo.DataSource = vehiculoLogica.ListarVehiculos();

                cmbServicio.DisplayMember = "Nombre";
                cmbServicio.ValueMember = "Id";
                cmbServicio.DataSource = servicioLogica.ListarServicios();
            }
            catch (SqlException)
            {
                MostrarErrorBaseDatos();
            }

            LimpiarFormulario();
        }

        private void CargarOrdenes()
        {
            try
            {
                List<Orden> ordenes = ordenLogica.ListarOrdenes(cmbFiltroEstado.Text, txtBuscarPlaca.Text);
                dgvOrdenes.DataSource = null;
                dgvOrdenes.DataSource = ordenes;
                ConfigurarColumnas();

                lblCantidad.Text = "Órdenes: " + ordenes.Count;
                lblTotalFiltrado.Text = "Total: " + ordenLogica.CalcularTotal(ordenes).ToString(FormatoColones);
                lblVentasDelDia.Text = "Ventas de hoy: " + ordenLogica.CalcularVentasDelDia().ToString(FormatoColones);
            }
            catch (SqlException)
            {
                MostrarErrorBaseDatos();
            }
        }

        private void ConfigurarColumnas()
        {
            OcultarColumna("Vehiculo");
            OcultarColumna("Servicio");

            ConfigurarColumna("Id", "N.º", 0);
            ConfigurarColumna("Fecha", "Fecha", 1);
            ConfigurarColumna("NombreCliente", "Cliente", 2);
            ConfigurarColumna("Placa", "Placa", 3);
            ConfigurarColumna("NombreServicio", "Servicio", 4);
            ConfigurarColumna("Total", "Total", 5);
            ConfigurarColumna("Estado", "Estado", 6);
            ConfigurarColumna("DiasTranscurridos", "Días", 7);

            DataGridViewColumn? columnaFecha = dgvOrdenes.Columns["Fecha"];
            if (columnaFecha != null)
                columnaFecha.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            DataGridViewColumn? columnaTotal = dgvOrdenes.Columns["Total"];
            if (columnaTotal != null)
            {
                columnaTotal.DefaultCellStyle.Format = FormatoColones;
                columnaTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void ConfigurarColumna(string nombre, string encabezado, int posicion)
        {
            DataGridViewColumn? columna = dgvOrdenes.Columns[nombre];
            if (columna == null)
                return;

            columna.HeaderText = encabezado;
            columna.DisplayIndex = posicion;
        }

        private void OcultarColumna(string nombre)
        {
            DataGridViewColumn? columna = dgvOrdenes.Columns[nombre];
            if (columna != null)
                columna.Visible = false;
        }

        private void MostrarTotalOrden()
        {
            if (cmbServicio.SelectedItem is Servicio servicio)
                lblTotalOrden.Text = "Total a cobrar: " + servicio.Precio.ToString(FormatoColones);
            else
                lblTotalOrden.Text = "Total a cobrar: ₡0.00";
        }

        private int ObtenerIdSeleccionado(ComboBox combo)
        {
            if (combo.SelectedValue is int id)
                return id;

            return 0;
        }

        private bool ValidarFormulario()
        {
            string errorVehiculo = ordenLogica.ValidarVehiculo(ObtenerIdSeleccionado(cmbVehiculo));
            string errorServicio = ordenLogica.ValidarServicio(ObtenerIdSeleccionado(cmbServicio));
            string errorEstado = ordenLogica.ValidarEstado(cmbEstado.Text);

            errorProvider.SetError(cmbVehiculo, errorVehiculo);
            errorProvider.SetError(cmbServicio, errorServicio);
            errorProvider.SetError(cmbEstado, errorEstado);

            return errorVehiculo == string.Empty && errorServicio == string.Empty && errorEstado == string.Empty;
        }

        private void LimpiarFormulario()
        {
            idOrdenSeleccionada = 0;
            cmbVehiculo.SelectedIndex = -1;
            cmbServicio.SelectedIndex = -1;
            cmbEstado.SelectedItem = "Pendiente";
            errorProvider.Clear();
            dgvOrdenes.ClearSelection();
            MostrarTotalOrden();
            cmbVehiculo.Focus();
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