using System;
using ClienteAdmin.NWwervice;

namespace ClienteAdmin
{
    public partial class Home : System.Web.UI.Page
    {
        private string admin_nick;
        private string admin_pass;
        private NavalWarsWSSoapClient servicio;

        protected void Page_Load(object sender, EventArgs e)
        {
            msjRequest();
            admin_nick = "admin";
            admin_pass = "admin";
            servicio = new NavalWarsWSSoapClient();
        }

        protected void boton_login_Click(object sender, EventArgs e)
        {
            if (casillasVacias())//si algun campo esta vacio
            {
                msj_error.Text = "No puede dejar campos vacios";
            }else
            {
                if (text_admin_pass.Text.Equals(admin_pass) && text_admin_nick.Text.Equals(admin_nick))//si todo esta correcto
                {
                    Session["user"] = "admin";
                    Response.Redirect("Administrador.aspx");
                }
                else
                {
                    Persona aux = servicio.binarioBuscar(text_admin_nick.Text);//modificado
                    if (aux != null)
                    {
                        if (aux.password.Equals(text_admin_pass.Text))//modificado
                        {
                            Session["user"] = text_admin_nick.Text;
                            //Session["nombre"] = text_admin_nick.Text;//nuevo
                            Response.Redirect("Usuario.aspx");
                        }else
                        {
                            msj_error.Text = "Usuario o contraseña invalidos";
                        }
                    }else
                    {
                        msj_error.Text = "Usuario o contraseña invalidos";
                    }
                }

            }
        }
        



        #region Aux
        private bool casillasVacias()
        {
            if (string.IsNullOrEmpty(text_admin_nick.Text) || string.IsNullOrEmpty(text_admin_pass.Text))
                return true;
            return false;

        }
        private void msjRequest()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["msj"]))
            {
                string aux = Request.QueryString["msj"].ToString();
                switch (aux)
                {
                    case "mty":
                        Response.Redirect("Home.aspx");
                        break;
                    case "close":
                        Session.Abandon();
                        Response.Cookies.Add(new System.Web.HttpCookie("ASP.NET_SessionId", ""));
                        Response.Redirect("Home.aspx");
                        break;
                }
            }
        }
        #endregion
    }
}