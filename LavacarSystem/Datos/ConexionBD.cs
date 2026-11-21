using Microsoft.Data.SqlClient;

namespace LavacarSystem.Datos
{
    public static class ConexionBD
    {
        private const string CadenaConexion =
            @"Server=LAPTOP-20BJTKI5\SQLEXPRESS;Database=LavacarDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(CadenaConexion);
        }

        public static bool ProbarConexion()
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    return true;
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}