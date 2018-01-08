using System;
using ClienteAdmin.NWwervice;

namespace ClienteAdmin
{
    public partial class Usuario : System.Web.UI.Page
    {
        private NavalWarsWSSoapClient servicio;
        private string mi_nick;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!hayUsuario())
                Response.Redirect("Home.aspx?msj=mty");
            else
            {
                mi_nick = Session["user"].ToString();
                servicio = new NavalWarsWSSoapClient();
                msj_nombre_usuario.Text = "<h2>" + mi_nick + "</h2>";
            }
        }


        #region Contactos

        #endregion

        #region aux
        private bool hayUsuario()
        {
            if (Session["user"] == null|| string.IsNullOrEmpty(Session["user"].ToString()))
                return false;
            return true;
        }
        #endregion
    }
}