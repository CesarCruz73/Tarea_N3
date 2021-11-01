using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Ejercicio3
{
    public class ConexionBD
    {
        public class ConexionDB
        {
            readonly string cadena = "Data Source=192.168.1.240;Initial Catalog=Login;User ID=sa;Password=BaseDatos1";

            public bool ValidarUsuario(Usuario usuario)
            {
                bool esUsuarioValido = false;

                try
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append(" SELECT 1 FROM LOGIN WHERE CORREO = @Correo AND CLAVE = @Clave; ");

                    using (SqlConnection _conexion = new SqlConnection(cadena))
                    {
                        _conexion.Open();
                        using (SqlCommand comando = new SqlCommand(sql.ToString(), _conexion))
                        {
                            comando.CommandType = CommandType.Text;
                            comando.Parameters.Add("@Correo", SqlDbType.NVarChar, 50).Value = usuario.Correo;
                            comando.Parameters.Add("@Clave", SqlDbType.NVarChar, 20).Value = usuario.Clave;
                            esUsuarioValido = Convert.ToBoolean(comando.ExecuteScalar());

                        }

                    }
                }
                catch (Exception)
                {

                }
                return esUsuarioValido;
            }


            public bool InsertarClientes(Clientes clientes)
            {
                try
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append(" INSERT INTO CLIENTE ");
                    sql.Append(" VALUES (@Nombre, @NumIdentidad, @Direccion); ");

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
}
