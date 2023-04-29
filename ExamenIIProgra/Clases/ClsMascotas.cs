using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ExamenIIProgra.Clases
{
    public class ClsMascotas
    {
        public ClsMascotas() { }
        public static int ID_Mascota { set; get; }
        public static string Nombre_Mascota { set; get; }
        public static string Tipo_Mascota { set; get; }
        public static string Comida_Favorita { set; get; }

        //Ingresar MAE_MASCOTAS
        public static int IngresarMascotas()
        {

            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_AgregarMascotas", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@Nombre_Mascota", Nombre_Mascota));
                    cmd.Parameters.Add(new SqlParameter("@Tipo_Mascota", Tipo_Mascota));
                    cmd.Parameters.Add(new SqlParameter("@Comida_Favorita", Comida_Favorita));

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

        //Borrar MAE_MASCOTAS
        public static int BorrarMascotas()
        {

            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_BorrarMascotas", Conn)
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

        //Modificar MAE_MASCOTAS
        public static int ModificarMascotas()
        {

            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_ModificarMascotas", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@ID_Mascota", ID_Mascota));
                    cmd.Parameters.Add(new SqlParameter("@Nombre_Mascota", Nombre_Mascota));
                    cmd.Parameters.Add(new SqlParameter("@Tipo_Mascota", Tipo_Mascota));
                    cmd.Parameters.Add(new SqlParameter("@Comida_Favorita", Comida_Favorita));

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