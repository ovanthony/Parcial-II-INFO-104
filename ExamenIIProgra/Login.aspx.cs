using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenIIProgra
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BIngresar_Click(object sender, EventArgs e)
        {
            if (LoginDB.ValidarUsuario(TUsuario.Text, TPassword.Text) > 0)
            {
                Response.Redirect("Inicio.aspx");
            }
        }
    }
}