using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using ExamenIIProgra.Clases;

namespace ExamenIIProgra
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["UHExamenII"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM MAE_USUARIOS"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridUsuarios.DataSource = dt;
                            GridUsuarios.DataBind();
                        }
                    }
                }
            }
        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TClave_Usuario.Text) || string.IsNullOrWhiteSpace(TNombre_Usuario.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            ClsUsuarios.Clave_Usuario = TClave_Usuario.Text;
            ClsUsuarios.Nombre_Usuario = TNombre_Usuario.Text;

            if (ClsUsuarios.IngresarUsuarios() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Usuario fue registrado con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Usuario no fue registrado con éxito**");
            }
        }

        protected void BBorrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TLogin_Usuario.Text))
            {
                DBConn.RegistrarAlerta(this, "**El código de usuario es requerido**");
                return;
            }

            ClsUsuarios.Login_Usuario = int.Parse(TLogin_Usuario.Text);

            if (ClsUsuarios.BorrarUsuarios() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Usuario fue borrado con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Usuario no fue borrado con éxito**");
            }
        }

        protected void BModificar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TLogin_Usuario.Text) || string.IsNullOrWhiteSpace(TClave_Usuario.Text) || string.IsNullOrWhiteSpace(TNombre_Usuario.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            ClsUsuarios.Login_Usuario = int.Parse(TLogin_Usuario.Text);
            ClsUsuarios.Clave_Usuario = TClave_Usuario.Text;
            ClsUsuarios.Nombre_Usuario = TNombre_Usuario.Text;

            if (ClsUsuarios.ModificarUsuarios() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Usuario fue modificado con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Escuela no fue modificado con éxito**");
            }
        }
    }
}