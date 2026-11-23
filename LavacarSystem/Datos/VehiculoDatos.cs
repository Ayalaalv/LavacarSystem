using LavacarSystem.Entidades;
using Microsoft.Data.SqlClient;

namespace LavacarSystem.Datos
{
    public class VehiculoDatos
    {
        private const string ConsultaBase =
            "SELECT v.id_vehiculo, v.placa, v.marca, v.id_cliente, c.nombre " +
            "FROM Vehiculos v INNER JOIN Clientes c ON v.id_cliente = c.id_cliente ";

        public List<Vehiculo> ListarVehiculos()
        {
            string consulta = ConsultaBase + "ORDER BY v.placa";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                conexion.Open();
                return LeerVehiculos(comando);
            }
        }

        public List<Vehiculo> BuscarVehiculos(string texto)
        {
            string consulta = ConsultaBase +
                              "WHERE v.placa LIKE @texto OR v.marca LIKE @texto OR c.nombre LIKE @texto " +
                              "ORDER BY v.placa";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@texto", "%" + texto + "%");
                conexion.Open();
                return LeerVehiculos(comando);
            }
        }

        public void InsertarVehiculo(Vehiculo vehiculo)
        {
            string consulta = "INSERT INTO Vehiculos (placa, marca, id_cliente) " +
                              "VALUES (@placa, @marca, @idCliente)";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@placa", vehiculo.Placa);
                comando.Parameters.AddWithValue("@marca", vehiculo.Marca);
                comando.Parameters.AddWithValue("@idCliente", vehiculo.IdCliente);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public bool ActualizarVehiculo(Vehiculo vehiculo)
        {
            string consulta = "UPDATE Vehiculos SET placa = @placa, marca = @marca, id_cliente = @idCliente " +
                              "WHERE id_vehiculo = @id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@placa", vehiculo.Placa);
                comando.Parameters.AddWithValue("@marca", vehiculo.Marca);
                comando.Parameters.AddWithValue("@idCliente", vehiculo.IdCliente);
                comando.Parameters.AddWithValue("@id", vehiculo.Id);
                conexion.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarVehiculo(int idVehiculo)
        {
            string consulta = "DELETE FROM Vehiculos WHERE id_vehiculo = @id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@id", idVehiculo);
                conexion.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public int ContarOrdenes(int idVehiculo)
        {
            string consulta = "SELECT COUNT(*) FROM Ordenes WHERE id_vehiculo = @id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@id", idVehiculo);
                conexion.Open();
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        public bool ExistePlaca(string placa, int idVehiculoExcluir)
        {
            string consulta = "SELECT COUNT(*) FROM Vehiculos WHERE placa = @placa AND id_vehiculo <> @id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@placa", placa);
                comando.Parameters.AddWithValue("@id", idVehiculoExcluir);
                conexion.Open();
                return Convert.ToInt32(comando.ExecuteScalar()) > 0;
            }
        }

        private List<Vehiculo> LeerVehiculos(SqlCommand comando)
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();

            using (SqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    Vehiculo vehiculo = new Vehiculo();
                    vehiculo.Id = lector.GetInt32(0);
                    vehiculo.Placa = lector.GetString(1);
                    vehiculo.Marca = lector.GetString(2);
                    vehiculo.IdCliente = lector.GetInt32(3);
                    vehiculo.NombreCliente = lector.GetString(4);
                    vehiculos.Add(vehiculo);
                }
            }

            return vehiculos;
        }
    }
}