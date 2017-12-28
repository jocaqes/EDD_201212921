using System;
using WebApplication1.NavalWarsWS;

namespace WebApplication1
{
    public partial class Home : System.Web.UI.Page
    {
        private string admin = "admin";
        private string pass = "admin";
        NavalWarsServiceClient servicio;

        protected void Page_Load(object sender, EventArgs e)
        {
            urlRequest();
            servicio = new NavalWarsServiceClient();
            Session["servicio"] = servicio;
            
        }

        protected void boton_aceptar_Click(object sender, EventArgs e)
        {
            if (verificarCampos()) {
                if (verificarAdmin())
                {
                    Session["Usuario"] = admin;
                    //setVariablesSesion();//agrego el arbol de usuarios
                    Response.Redirect("Administrador.aspx");
                }
                else
                {
                    label_mensaje.Text = "La clave o usuario de administrador son invalidos";
                }
            }else
            {
                label_mensaje.Text = "No puede dejar campos vacios";
            }
            
        }

        private bool verificarAdmin()
        {
            if (text_nick.Text.Equals(admin) && text_pass.Text.Equals(pass))
                return true;
            else
                return false;
        }

        private void urlRequest()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["msj"]))
            {
                switch (Request.QueryString["msj"].ToString())
                {
                    case "mty":
                        Response.Write("<script>alert('" + "Nickname o password estan vacios" + "')</script>");
                        break;
                    case "close":
                        Response.Redirect("Home.aspx");
                        break;
                }


               /* if (Request.QueryString["msj"].ToString() == "mty")
                    Response.Write("<script>alert('" + "Nickname o password estan vacios" + "')</script>");
                else if (Request.QueryString["msj"].ToString())*/
                Session.Abandon();
            }
        }

        /*private void setVariablesSesion()
        {
            if(Session["arbol_usuarios"]==null)
                Session["arbol_usuarios"] = servicio.newArbolBinario();//Tengo un arbol de usuarios
        }*/

        private bool verificarCampos()
        {
            if (string.IsNullOrEmpty(text_nick.Text) || string.IsNullOrEmpty(text_pass.Text))
                return false;
            return true;
        }


    }
}