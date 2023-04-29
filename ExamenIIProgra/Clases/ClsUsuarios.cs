using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ExamenIIProgra.Clases
{
    public class ClsUsuarios
    {

        public ClsUsuarios() { }
        public static int Login_Usuario { set; get; }
        public static string Clave_Usuario { set; get; }
        public static string Nombre_Usuario { set; get; }

        //Ingresar MAE_USUARIOS
        public static int IngresarUsuarios()
        {

            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_AgregarUsuarios", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@Clave_Usuario", Clave_Usuario));
                    cmd.Parameters.Add(new SqlParameter("@Nombre_Usuario", Nombre_Usuario));

                    retorno = cmd.ExecuteNonQuery();

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;

        }

        //Borrar MAE_USUARIOS
        public static int BorrarUsuarios()
        {

            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_BorrarUsuarios", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@Login_Usuario", Login_Usuario));

                    retorno = cmd.ExecuteNonQuery();

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;

        }

        //Modificar MAE_USUARIOS
        public static int ModificarUsuarios()
        {

            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_ModificarUsuarios", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@Login_Usuario", Login_Usuario));
                    cmd.Parameters.Add(new SqlParameter("@Clave_Usuario", Clave_Usuario));
                    cmd.Parameters.Add(new SqlParameter("@Nombre_Usuario", Nombre_Usuario));

                    retorno = cmd.ExecuteNonQuery();

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;

        }

    }
}