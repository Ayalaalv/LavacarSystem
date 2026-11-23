using LavacarSystem.Datos;
using LavacarSystem.Entidades;

namespace LavacarSystem.Logica
{
    public class ServicioLogica
    {
        private const decimal PrecioMaximo = 1000000;
        private readonly ServicioDatos servicioDatos = new ServicioDatos();

        public string ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return "El nombre del servicio es obligatorio.";

            string nombreLimpio = nombre.Trim();

            if (nombreLimpio.Length < 3)
                return "El nombre debe tener al menos 3 caracteres.";
            if (nombreLimpio.Length > 100)
                return "El nombre no puede tener más de 100 caracteres.";

            return string.Empty;
        }

        public string ValidarPrecio(string textoPrecio)
        {
            if (string.IsNullOrWhiteSpace(textoPrecio))
                return "El precio es obligatorio.";

            if (!decimal.TryParse(textoPrecio.Trim(), out decimal precio))
                return "El precio debe ser un número válido, por ejemplo 5000.";

            if (precio <= 0)
                return "El precio debe ser mayor que cero.";
            if (precio > PrecioMaximo)
                return "El precio no puede ser mayor a ₡1 000 000.";

            return string.Empty;
        }

        public List<Servicio> ListarServicios()
        {
            return servicioDatos.ListarServicios();
        }

        public List<Servicio> BuscarServicios(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return servicioDatos.ListarServicios();

            return servicioDatos.BuscarServicios(texto.Trim());
        }

        public void GuardarServicio(string nombre, string textoPrecio)
        {
            Servicio servicio = CrearServicio(nombre, textoPrecio);

            if (servicioDatos.ExisteServicio(servicio.Nombre, 0))
                throw new ArgumentException("Ya existe un servicio con el nombre " + servicio.Nombre + ".");

            servicioDatos.InsertarServicio(servicio);
        }

        public void ModificarServicio(int idServicio, string nombre, string textoPrecio)
        {
            if (idServicio <= 0)
                throw new InvalidOperationException("Seleccione un servicio de la lista para modificarlo.");

            Servicio servicio = CrearServicio(nombre, textoPrecio);
            servicio.Id = idServicio;

            if (servicioDatos.ExisteServicio(servicio.Nombre, idServicio))
                throw new ArgumentException("Ya existe otro servicio con el nombre " + servicio.Nombre + ".");

            if (!servicioDatos.ActualizarServicio(servicio))
                throw new InvalidOperationException("El servicio ya no existe en la base de datos.");
        }

        public void EliminarServicio(int idServicio)
        {
            if (idServicio <= 0)
                throw new InvalidOperationException("Seleccione un servicio de la lista para eliminarlo.");

            if (servicioDatos.ContarOrdenes(idServicio) > 0)
                throw new InvalidOperationException(
                    "No se puede eliminar el servicio porque está registrado en órdenes de lavado.");

            if (!servicioDatos.EliminarServicio(idServicio))
                throw new InvalidOperationException("El servicio ya no existe en la base de datos.");
        }

        private Servicio CrearServicio(string nombre, string textoPrecio)
        {
            string errorNombre = ValidarNombre(nombre);
            if (errorNombre != string.Empty)
                throw new ArgumentException(errorNombre);

            string errorPrecio = ValidarPrecio(textoPrecio);
            if (errorPrecio != string.Empty)
                throw new ArgumentException(errorPrecio);

            Servicio servicio = new Servicio();
            servicio.Nombre = nombre;
            servicio.Precio = decimal.Parse(textoPrecio.Trim());
            return servicio;
        }
    }
}