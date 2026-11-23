using LavacarSystem.Datos;
using LavacarSystem.Entidades;

namespace LavacarSystem.Logica
{
    public class VehiculoLogica
    {
        private readonly VehiculoDatos vehiculoDatos = new VehiculoDatos();

        public string ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return "La placa es obligatoria.";

            string placaLimpia = placa.Trim();

            if (placaLimpia.Length < 3 || placaLimpia.Length > 10)
                return "La placa debe tener entre 3 y 10 caracteres.";

            foreach (char caracter in placaLimpia)
            {
                if (!char.IsLetterOrDigit(caracter))
                    return "La placa solo puede contener letras y números, sin guiones ni espacios.";
            }

            return string.Empty;
        }

        public string ValidarMarca(string marca)
        {
            if (string.IsNullOrWhiteSpace(marca))
                return "La marca es obligatoria.";

            string marcaLimpia = marca.Trim();

            if (marcaLimpia.Length < 2)
                return "La marca debe tener al menos 2 caracteres.";
            if (marcaLimpia.Length > 50)
                return "La marca no puede tener más de 50 caracteres.";

            return string.Empty;
        }

        public string ValidarCliente(int idCliente)
        {
            if (idCliente <= 0)
                return "Seleccione el dueño del vehículo.";

            return string.Empty;
        }

        public List<Vehiculo> ListarVehiculos()
        {
            return vehiculoDatos.ListarVehiculos();
        }

        public List<Vehiculo> BuscarVehiculos(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return vehiculoDatos.ListarVehiculos();

            return vehiculoDatos.BuscarVehiculos(texto.Trim());
        }

        public void GuardarVehiculo(string placa, string marca, int idCliente)
        {
            Vehiculo vehiculo = CrearVehiculo(placa, marca, idCliente);

            if (vehiculoDatos.ExistePlaca(vehiculo.Placa, 0))
                throw new ArgumentException("Ya existe un vehículo registrado con la placa " + vehiculo.Placa + ".");

            vehiculoDatos.InsertarVehiculo(vehiculo);
        }

        public void ModificarVehiculo(int idVehiculo, string placa, string marca, int idCliente)
        {
            if (idVehiculo <= 0)
                throw new InvalidOperationException("Seleccione un vehículo de la lista para modificarlo.");

            Vehiculo vehiculo = CrearVehiculo(placa, marca, idCliente);
            vehiculo.Id = idVehiculo;

            if (vehiculoDatos.ExistePlaca(vehiculo.Placa, idVehiculo))
                throw new ArgumentException("Ya existe otro vehículo registrado con la placa " + vehiculo.Placa + ".");

            if (!vehiculoDatos.ActualizarVehiculo(vehiculo))
                throw new InvalidOperationException("El vehículo ya no existe en la base de datos.");
        }

        public void EliminarVehiculo(int idVehiculo)
        {
            if (idVehiculo <= 0)
                throw new InvalidOperationException("Seleccione un vehículo de la lista para eliminarlo.");

            if (vehiculoDatos.ContarOrdenes(idVehiculo) > 0)
                throw new InvalidOperationException(
                    "No se puede eliminar el vehículo porque tiene órdenes de lavado registradas.");

            if (!vehiculoDatos.EliminarVehiculo(idVehiculo))
                throw new InvalidOperationException("El vehículo ya no existe en la base de datos.");
        }

        private Vehiculo CrearVehiculo(string placa, string marca, int idCliente)
        {
            string errorPlaca = ValidarPlaca(placa);
            if (errorPlaca != string.Empty)
                throw new ArgumentException(errorPlaca);

            string errorMarca = ValidarMarca(marca);
            if (errorMarca != string.Empty)
                throw new ArgumentException(errorMarca);

            string errorCliente = ValidarCliente(idCliente);
            if (errorCliente != string.Empty)
                throw new ArgumentException(errorCliente);

            Vehiculo vehiculo = new Vehiculo();
            vehiculo.Placa = placa;
            vehiculo.Marca = marca;
            vehiculo.IdCliente = idCliente;
            return vehiculo;
        }
    }
}