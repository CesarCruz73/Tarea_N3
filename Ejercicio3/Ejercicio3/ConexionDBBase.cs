namespace Ejercicio3
{
    public class ConexionDBBase
    {

        public bool InsertarCliente(Clientes clientes)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO CLIENTE ");
                sql.Append(" VALUES (@Nombre, @NumIdentidad, @Dirección); ");

                using (SqlConnection _conexion = new SqlConnection(cadena))
                {
                    _conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = clientes.Nombre;
                        comando.Parameters.Add("@NumIdentidad", SqlDbType.Int).Value = clientes.NumIdentidad;
                        comando.Parameters.Add("@Dirección", SqlDbType.NVarChar, 80).Value = clientes.Direccion;

                        comando.ExecuteNonQuery();
                        return true;

                    }

                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}