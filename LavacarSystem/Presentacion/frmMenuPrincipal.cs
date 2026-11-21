namespace LavacarSystem.Presentacion
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            using (frmClientes formulario = new frmClientes())
            {
                formulario.ShowDialog();
            }
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            using (frmVehiculos formulario = new frmVehiculos())
            {
                formulario.ShowDialog();
            }
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            using (frmServicios formulario = new frmServicios())
            {
                formulario.ShowDialog();
            }
        }

        private void btnOrdenes_Click(object sender, EventArgs e)
        {
            using (frmOrdenes formulario = new frmOrdenes())
            {
                formulario.ShowDialog();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}