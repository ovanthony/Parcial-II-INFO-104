using ExamenIIProgra.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenIIProgra
{
    public partial class Mascotas : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM MAE_MASCOTAS"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridMascotas.DataSource = dt;
                            GridMascotas.DataBind();
                        }
                    }
                }
            }
        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TNombre_Mascota.Text) || string.IsNullOrWhiteSpace(TTipo_Mascota.Text) || string.IsNullOrWhiteSpace(TComida_Favorita.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            ClsMascotas.Nombre_Mascota = TNombre_Mascota.Text;
            ClsMascotas.Tipo_Mascota = TTipo_Mascota.Text;
            ClsMascotas.Comida_Favorita = TComida_Favorita.Text;

            if (ClsMascotas.IngresarMascotas() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Mascota fue registrada con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Mascota no fue registrada con éxito**");
            }
        }

        protected void BBorrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TID_Mascota.Text))
            {
                DBConn.RegistrarAlerta(this, "**El código de mascota es requerido**");
                return;
            }

            ClsMascotas.ID_Mascota = int.Parse(TID_Mascota.Text);

            if (ClsMascotas.BorrarMascotas() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Mascota fue borrada con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Mascota no fue borrada con éxito**");
            }
        }

        protected void BModificar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TID_Mascota.Text) || string.IsNullOrWhiteSpace(TNombre_Mascota.Text) || string.IsNullOrWhiteSpace(TTipo_Mascota.Text) || string.IsNullOrWhiteSpace(TComida_Favorita.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            ClsMascotas.ID_Mascota = int.Parse(TID_Mascota.Text);
            ClsMascotas.Nombre_Mascota = TNombre_Mascota.Text;
            ClsMascotas.Tipo_Mascota = TTipo_Mascota.Text;
            ClsMascotas.Comida_Favorita = TComida_Favorita.Text;

            if (ClsMascotas.ModificarMascotas() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Mascota fue modificada con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Mascota no fue modificada con éxito**");
            }
        }
    }
}