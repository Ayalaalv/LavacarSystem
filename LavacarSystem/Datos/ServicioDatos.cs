using LavacarSystem.Entidades;
using Microsoft.Data.SqlClient;

namespace LavacarSystem.Datos
{
    public class ServicioDatos
    {
        public List<Servicio> ListarServicios()
        {
            string consulta = "SELECT id_servicio, nombre, precio FROM Servicios ORDER BY nombre";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                conexion.Open();
                return LeerServicios(comando);
            }
        }

        public List<Servicio> BuscarServicios(string texto)
        {
            string consulta = "SELECT id_servicio, nombre, precio FROM Servicios " +
                              "WHERE nombre LIKE @texto ORDER BY nombre";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@texto", "%" + texto + "%");
                conexion.Open();
                return LeerServicios(comando);
            }
        }

        public void InsertarServicio(Servicio servicio)
        {
            string consulta = "INSERT INTO Servicios (nombre, precio) VALUES (@nombre, @precio)";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@nombre", servicio.Nombre);
                comando.Parameters.AddWithValue("@precio", servicio.Precio);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public bool ActualizarServicio(Servicio servicio)
        {
            string consulta = "UPDATE Servicios SET nombre = @nombre, precio = @precio " +
                              "WHERE id_servicio = @id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@nombre", servicio.Nombre);
                comando.Parameters.AddWithValue("@precio", servicio.Precio);
                comando.Parameters.AddWithValue("@id", servicio.Id);
                conexion.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarServicio(int idServicio)
        {
            string consulta = "DELETE FROM Servicios WHERE id_servicio = @id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@id", idServicio);
                conexion.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public int ContarOrdenes(int idServicio)
        {
            string consulta = "SELECT COUNT(*) FROM Ordenes WHERE id_servicio = @id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@id", idServicio);
                conexion.Open();
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        public bool ExisteServicio(string nombre, int idServicioExcluir)
        {
            string consulta = "SELECT COUNT(*) FROM Servicios " +
                              "WHERE nombre = @nombre AND id_servicio <> @id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@id", idServicioExcluir);
                conexion.Open();
                return Convert.ToInt32(comando.ExecuteScalar()) > 0;
            }
        }

        private List<Servicio> LeerServicios(SqlCommand comando)
        {
            List<Servicio> servicios = new List<Servicio>();

            using (SqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    Servicio servicio = new Servicio();
                    servicio.Id = lector.GetInt32(0);
                    servicio.Nombre = lector.GetString(1);
                    servicio.Precio = lector.GetDecimal(2);
                    servicios.Add(servicio);
                }
            }

            return servicios;
        }
    }
}