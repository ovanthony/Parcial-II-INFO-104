using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ExamenIIProgra.Clases
{
    public class ClsCitas
    {

        public ClsCitas() { }
        public static int ID_Mascota { set; get; }
        public static string Proxima_Fecha { set; get; }
        public static string Medico_Asignado { set; get; }

        //Ingresar CONTROL_CITAS
        public static int IngresarCitas()
        {

            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_AgregarCitas", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@ID_Mascota", ID_Mascota));
                    cmd.Parameters.Add(new SqlParameter("@Proxima_Fecha", Proxima_Fecha));
                    cmd.Parameters.Add(new SqlParameter("@Medico_Asignado", Medico_Asignado));

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

        //Borrar CONTROL_CITAS
        public static int BorrarCitas()
        {

            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_BorrarCitas", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@ID_Mascota", ID_Mascota));

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

        //Modificar CONTROL_CITAS
        public static int ModificarCitas()
        {

            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_ModificarCitas", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@ID_Mascota", ID_Mascota));
                    cmd.Parameters.Add(new SqlParameter("@Proxima_Fecha", Proxima_Fecha));
                    cmd.Parameters.Add(new SqlParameter("@Medico_Asignado", Medico_Asignado));

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