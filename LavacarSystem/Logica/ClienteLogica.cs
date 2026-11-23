using LavacarSystem.Datos;
using LavacarSystem.Entidades;

namespace LavacarSystem.Logica
{
    public class ClienteLogica
    {
        private readonly ClienteDatos clienteDatos = new ClienteDatos();

        public string ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return "El nombre es obligatorio.";

            string nombreLimpio = nombre.Trim();

            if (nombreLimpio.Length < 3)
                return "El nombre debe tener al menos 3 caracteres.";
            if (nombreLimpio.Length > 100)
                return "El nombre no puede tener más de 100 caracteres.";

            foreach (char caracter in nombreLimpio)
            {
                if (!char.IsLetter(caracter) && caracter != ' ')
                    return "El nombre solo puede contener letras y espacios.";
            }

            return string.Empty;
        }

        public string ValidarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return "El teléfono es obligatorio.";

            string telefonoLimpio = telefono.Trim();

            if (telefonoLimpio.Length != 9 || telefonoLimpio[4] != '-')
                return "El teléfono debe tener el formato 8888-1111.";

            for (int posicion = 0; posicion < telefonoLimpio.Length; posicion++)
            {
                if (posicion != 4 && !char.IsDigit(telefonoLimpio[posicion]))
                    return "El teléfono debe tener el formato 8888-1111.";
            }

            return string.Empty;
        }

        public List<Cliente> ListarClientes()
        {
            return clienteDatos.ListarClientes();
        }

        public List<Cliente> BuscarClientes(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return clienteDatos.ListarClientes();

            return clienteDatos.BuscarClientes(texto.Trim());
        }

        public void GuardarCliente(string nombre, string telefono)
        {
            Cliente cliente = CrearCliente(nombre, telefono);
            clienteDatos.InsertarCliente(cliente);
        }

        public void ModificarCliente(int idCliente, string nombre, string telefono)
        {
            if (idCliente <= 0)
                throw new InvalidOperationException("Seleccione un cliente de la lista para modificarlo.");

            Cliente cliente = CrearCliente(nombre, telefono);
            cliente.Id = idCliente;

            if (!clienteDatos.ActualizarCliente(cliente))
                throw new InvalidOperationException("El cliente ya no existe en la base de datos.");
        }

        public void EliminarCliente(int idCliente)
        {
            if (idCliente <= 0)
                throw new InvalidOperationException("Seleccione un cliente de la lista para eliminarlo.");

            if (clienteDatos.ContarVehiculos(idCliente) > 0)
                throw new InvalidOperationException(
                    "No se puede eliminar el cliente porque tiene vehículos registrados. Elimine primero sus vehículos.");

            if (!clienteDatos.EliminarCliente(idCliente))
                throw new InvalidOperationException("El cliente ya no existe en la base de datos.");
        }

        private Cliente CrearCliente(string nombre, string telefono)
        {
            string errorNombre = ValidarNombre(nombre);
            if (errorNombre != string.Empty)
                throw new ArgumentException(errorNombre);

            string errorTelefono = ValidarTelefono(telefono);
            if (errorTelefono != string.Empty)
                throw new ArgumentException(errorTelefono);

            Cliente cliente = new Cliente();
            cliente.Nombre = nombre;
            cliente.Telefono = telefono;
            return cliente;
        }
    }
}