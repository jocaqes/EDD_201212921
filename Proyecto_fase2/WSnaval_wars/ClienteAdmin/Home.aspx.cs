using System;

namespace ClienteAdmin
{
    public partial class Home : System.Web.UI.Page
    {
        private string admin_nick;
        private string admin_pass;

        protected void Page_Load(object sender, EventArgs e)
        {
            msjRequest();
            admin_nick = "admin";
            admin_pass = "admin";
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
                }else
                {
                    msj_error.Text = "Usuario o contraseña incorrectos";
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
                }
            }
        }
        #endregion
    }
}