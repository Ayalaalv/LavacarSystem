using LavacarSystem.Entidades;
using Microsoft.Data.SqlClient;

namespace LavacarSystem.Datos
{
    public class ClienteDatos
    {
        public List<Cliente> ListarClientes()
        {
            string consulta = "SELECT id_cliente, nombre, telefono FROM Clientes ORDER BY nombre";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                conexion.Open();
                return LeerClientes(comando);
            }
        }

        public List<Cliente> BuscarClientes(string texto)
        {
            string consulta = "SELECT id_cliente, nombre, telefono FROM Clientes " +
                              "WHERE nombre LIKE @texto OR telefono LIKE @texto ORDER BY nombre";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@texto", "%" + texto + "%");
                conexion.Open();
                return LeerClientes(comando);
            }
        }

        public void InsertarCliente(Cliente cliente)
        {
            string consulta = "INSERT INTO Clientes (nombre, telefono) VALUES (@nombre, @telefono)";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@telefono", cliente.Telefono);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            string consulta = "UPDATE Clientes SET nombre = @nombre, telefono = @telefono " +
                              "WHERE id_cliente = @id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@telefono", cliente.Telefono);
                comando.Parameters.AddWithValue("@id", cliente.Id);
                conexion.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarCliente(int idCliente)
        {
            string consulta = "DELETE FROM Clientes WHERE id_cliente = @id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@id", idCliente);
                conexion.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public int ContarVehiculos(int idCliente)
        {
            string consulta = "SELECT COUNT(*) FROM Vehiculos WHERE id_cliente = @id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@id", idCliente);
                conexion.Open();
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        private List<Cliente> LeerClientes(SqlCommand comando)
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = lector.GetInt32(0);
                    cliente.Nombre = lector.GetString(1);
                    cliente.Telefono = lector.GetString(2);
                    clientes.Add(cliente);
                }
            }

            return clientes;
        }
    }
}