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
            
        }

        protected void boton_aceptar_Click(object sender, EventArgs e)
        {
            if (verificarCampos()) {
                if (verificarAdmin())
                {
                    Session["Usuario"] = admin;
                    setVariablesSesion();//agrego el arbol de usuarios
                    Response.Redirect("Administrador.aspx");
                }
                else
                {
                    if (Session["arbol_usuarios"] != null)//si existe un arbol de usuarios(aun si esta vacio)
                    {
                        ArbolBinario arbol_aux = (ArbolBinario)Session["arbol_usuarios"];
                        Nodo nodo_usuario = servicio.buscar(text_nick.Text, arbol_aux);
                        if (nodo_usuario != null)//si encontre al usuario
                        {
                            if (nodo_usuario.item.password.Equals(text_pass.Text))//el usuario y password son correctos
                            {
                                Session["Usuario"] = nodo_usuario;
                                Response.Redirect("Usuario.aspx");
                            }else//el password es incorrecto
                            {
                                label_mensaje.Text = "El password es incorrecto";
                            }
                        }else//el usuario no existe, pero obviamente no le voy a decir eso
                        {
                            label_mensaje.Text = "El usuario es incorrecto";
                        }
                    }else//no hay arbol
                    {
                        label_mensaje.Text = "El password o usuario son incorrectos";
                    }
                    //Session["Usuario"] = null;
                }
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

        private void setVariablesSesion()
        {
            if(Session["arbol_usuarios"]==null)
                Session["arbol_usuarios"] = servicio.newArbolBinario();//Tengo un arbol de usuarios
        }

        private bool verificarCampos()
        {
            if (string.IsNullOrEmpty(text_nick.Text) || string.IsNullOrEmpty(text_pass.Text))
                return false;
            return true;
        }


    }
}