using System;

namespace WebApplication1
{
    public partial class Home : System.Web.UI.Page
    {
        private string admin = "admin";
        private string pass = "admin";
        NavalWarsWS.NavalWarsServiceClient servicio;

        protected void Page_Load(object sender, EventArgs e)
        {
            errorLogin();
            servicio = new NavalWarsWS.NavalWarsServiceClient();
            
        }

        protected void boton_aceptar_Click(object sender, EventArgs e)
        {
            if (verificarAdmin())
            {
                Session["Usuario"] = admin;
                setVariablesSesion();//agrego el arbol de usuarios
                Response.Redirect("Administrador.aspx");
            }
            else
            {
                Session["Usuario"] = null;
            }
            
        }

        private bool verificarAdmin()
        {
            if (text_nick.Text.Equals(admin) && text_pass.Text.Equals(pass))
                return true;
            else
                return false;
        }

        private void errorLogin()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["err"]))
            {
                if (Request.QueryString["err"].ToString() == "mty")
                    Response.Write("<script>alert('" + "Nickname o password estan vacios" + "')</script>");
                Session.Abandon();
            }
        }

        private void setVariablesSesion()
        {
            if(Application["arbol_usuarios"]==null)
                Application["arbol_usuarios"] = servicio.newArbolBinario();//Tengo un arbol de usuarios
        }
    }
}