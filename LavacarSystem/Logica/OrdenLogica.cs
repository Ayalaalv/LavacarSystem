using LavacarSystem.Datos;
using LavacarSystem.Entidades;

namespace LavacarSystem.Logica
{
    public class OrdenLogica
    {
        private const string EstadoTerminado = "Terminado";
        private const string FiltroTodos = "Todos";
        private readonly OrdenDatos ordenDatos = new OrdenDatos();

        public string ValidarVehiculo(int idVehiculo)
        {
            if (idVehiculo <= 0)
                return "Seleccione el vehículo.";

            return string.Empty;
        }

        public string ValidarServicio(int idServicio)
        {
            if (idServicio <= 0)
                return "Seleccione el servicio.";

            return string.Empty;
        }

        public string ValidarEstado(string estado)
        {
            if (!Orden.EstadosValidos.Contains(estado))
                return "Seleccione un estado válido.";

            return string.Empty;
        }

        public List<Orden> ListarOrdenes(string estadoFiltro, string placa)
        {
            string estado = estadoFiltro;
            if (estadoFiltro == FiltroTodos)
                estado = string.Empty;

            return ordenDatos.ListarOrdenes(estado, placa.Trim());
        }

        public void GuardarOrden(int idVehiculo, int idServicio, string estado)
        {
            Orden orden = CrearOrden(idVehiculo, idServicio, estado);
            orden.Fecha = DateTime.Now;
            ordenDatos.InsertarOrden(orden);
        }

        public void ModificarOrden(int idOrden, int idVehiculo, int idServicio, string estado)
        {
            string estadoActual = ObtenerEstadoActual(idOrden, "modificarla");

            if (estadoActual == EstadoTerminado)
                throw new InvalidOperationException("La orden ya está terminada y no se puede modificar.");

            Orden orden = CrearOrden(idVehiculo, idServicio, estado);
            orden.Id = idOrden;
            ordenDatos.ActualizarOrden(orden);
        }

        public void EliminarOrden(int idOrden)
        {
            string estadoActual = ObtenerEstadoActual(idOrden, "eliminarla");

            if (estadoActual == EstadoTerminado)
                throw new InvalidOperationException(
                    "No se puede eliminar una orden terminada porque ya forma parte de las ventas.");

            ordenDatos.EliminarOrden(idOrden);
        }

        public decimal CalcularTotal(List<Orden> ordenes)
        {
            decimal total = 0;

            foreach (Orden orden in ordenes)
            {
                total += orden.CalcularTotal();
            }

            return total;
        }

        public decimal CalcularVentasDelDia()
        {
            List<Orden> ordenesTerminadas = ordenDatos.ListarOrdenes(EstadoTerminado, string.Empty);
            decimal ventas = 0;

            foreach (Orden orden in ordenesTerminadas)
            {
                if (orden.Fecha.Date == DateTime.Today)
                    ventas += orden.CalcularTotal();
            }

            return ventas;
        }

        private string ObtenerEstadoActual(int idOrden, string accion)
        {
            if (idOrden <= 0)
                throw new InvalidOperationException("Seleccione una orden de la lista para " + accion + ".");

            string estadoActual = ordenDatos.ObtenerEstado(idOrden);

            if (estadoActual == string.Empty)
                throw new InvalidOperationException("La orden ya no existe en la base de datos.");

            return estadoActual;
        }

        private Orden CrearOrden(int idVehiculo, int idServicio, string estado)
        {
            string errorVehiculo = ValidarVehiculo(idVehiculo);
            if (errorVehiculo != string.Empty)
                throw new ArgumentException(errorVehiculo);

            string errorServicio = ValidarServicio(idServicio);
            if (errorServicio != string.Empty)
                throw new ArgumentException(errorServicio);

            string errorEstado = ValidarEstado(estado);
            if (errorEstado != string.Empty)
                throw new ArgumentException(errorEstado);

            Orden orden = new Orden();
            orden.Vehiculo.Id = idVehiculo;
            orden.Servicio.Id = idServicio;
            orden.Estado = estado;
            return orden;
        }
    }
}