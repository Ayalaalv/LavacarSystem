using LavacarSystem.Entidades;
using Microsoft.Data.SqlClient;

namespace LavacarSystem.Datos
{
    public class OrdenDatos
    {
        private const string ConsultaBase =
            "SELECT o.id_orden, o.fecha, o.estado, v.id_vehiculo, v.placa, c.nombre, " +
            "s.id_servicio, s.nombre, s.precio " +
            "FROM Ordenes o " +
            "INNER JOIN Vehiculos v ON o.id_vehiculo = v.id_vehiculo " +
            "INNER JOIN Clientes c ON v.id_cliente = c.id_cliente " +
            "INNER JOIN Servicios s ON o.id_servicio = s.id_servicio ";

        public List<Orden> ListarOrdenes(string estado, string placa)
        {
            string consulta = ConsultaBase +
                              "WHERE (@estado = '' OR o.estado = @estado) AND v.placa LIKE @placa " +
                              "ORDER BY o.fecha DESC";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@estado", estado);
                comando.Parameters.AddWithValue("@placa", "%" + placa + "%");
                conexion.Open();
                return LeerOrdenes(comando);
            }
        }

        public void InsertarOrden(Orden orden)
        {
            string consulta = "INSERT INTO Ordenes (fecha, estado, id_vehiculo, id_servicio) " +
                              "VALUES (@fecha, @estado, @idVehiculo, @idServicio)";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@fecha", orden.Fecha);
                comando.Parameters.AddWithValue("@estado", orden.Estado);
                comando.Parameters.AddWithValue("@idVehiculo", orden.Vehiculo.Id);
                comando.Parameters.AddWithValue("@idServicio", orden.Servicio.Id);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public bool ActualizarOrden(Orden orden)
        {
            string consulta = "UPDATE Ordenes SET estado = @estado, id_vehiculo = @idVehiculo, " +
                              "id_servicio = @idServicio WHERE id_orden = @id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@estado", orden.Estado);
                comando.Parameters.AddWithValue("@idVehiculo", orden.Vehiculo.Id);
                comando.Parameters.AddWithValue("@idServicio", orden.Servicio.Id);
                comando.Parameters.AddWithValue("@id", orden.Id);
                conexion.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarOrden(int idOrden)
        {
            string consulta = "DELETE FROM Ordenes WHERE id_orden = @id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@id", idOrden);
                conexion.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public string ObtenerEstado(int idOrden)
        {
            string consulta = "SELECT estado FROM Ordenes WHERE id_orden = @id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@id", idOrden);
                conexion.Open();

                object? resultado = comando.ExecuteScalar();
                if (resultado == null)
                    return string.Empty;

                return (string)resultado;
            }
        }

        private List<Orden> LeerOrdenes(SqlCommand comando)
        {
            List<Orden> ordenes = new List<Orden>();

            using (SqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    Orden orden = new Orden();
                    orden.Id = lector.GetInt32(0);
                    orden.Fecha = lector.GetDateTime(1);
                    orden.Estado = lector.GetString(2);
                    orden.Vehiculo.Id = lector.GetInt32(3);
                    orden.Vehiculo.Placa = lector.GetString(4);
                    orden.Vehiculo.NombreCliente = lector.GetString(5);
                    orden.Servicio.Id = lector.GetInt32(6);
                    orden.Servicio.Nombre = lector.GetString(7);
                    orden.Servicio.Precio = lector.GetDecimal(8);
                    ordenes.Add(orden);
                }
            }

            return ordenes;
        }
    }
}