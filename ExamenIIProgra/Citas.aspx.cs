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
    public partial class Citas : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CONTROL_CITAS"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridCitas.DataSource = dt;
                            GridCitas.DataBind();
                        }
                    }
                }
            }
        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TID_Mascota.Text) || string.IsNullOrWhiteSpace(TProxima_Fecha.Text) || string.IsNullOrWhiteSpace(TMedico_Asignado.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            ClsCitas.ID_Mascota = int.Parse(TID_Mascota.Text);
            ClsCitas.Proxima_Fecha = TProxima_Fecha.Text;
            ClsCitas.Medico_Asignado = TMedico_Asignado.Text;

            if (ClsCitas.IngresarCitas() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Cita fue registrada con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Cita no fue registrada con éxito**");
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

            if (ClsCitas.BorrarCitas() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Cita fue borrada con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Cita no fue borrada con éxito**");
            }
        }

        protected void BModificar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TID_Mascota.Text) || string.IsNullOrWhiteSpace(TProxima_Fecha.Text) || string.IsNullOrWhiteSpace(TMedico_Asignado.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            ClsCitas.ID_Mascota = int.Parse(TID_Mascota.Text);
            ClsCitas.Proxima_Fecha = TProxima_Fecha.Text;
            ClsCitas.Medico_Asignado = TMedico_Asignado.Text;

            if (ClsCitas.ModificarCitas() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Cita fue modificada con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Cita no fue modificada con éxito**");
            }
        }
    }
}