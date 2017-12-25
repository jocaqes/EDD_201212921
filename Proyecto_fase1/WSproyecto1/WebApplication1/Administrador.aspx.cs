using System;
using WebApplication1.NavalWarsWS;

namespace WebApplication1
{
    public partial class Administrador : System.Web.UI.Page
    {
        NavalWarsServiceClient servicio;
        protected void Page_Load(object sender, EventArgs e)
        {
            verificarUsuario();
            servicio = new NavalWarsServiceClient();

        }

        private void verificarUsuario()
        {
            if (Session["Usuario"] == null||Session["Usuario"].ToString().Equals(""))
            {
                Response.Redirect("Home.aspx?err=mty");
            }

        }

        protected void boton_aceptar_Click(object sender, EventArgs e)
        {
            if(!verificarCampos())
                Response.Write("<script>alert('" + "No pueden Haber campos vacios" + "')</script>");
            else
            {
                if (Application["arbol_usuarios"] != null)
                {
                    ArbolBinario arbol = (ArbolBinario)Application["arbol_usuarios"];
                    Persona nueva = servicio.newPersona(text_passuser.Text, text_mailuser.Text);
                    arbol=servicio.insertar(text_nickuser.Text,nueva,arbol);
                    Application["arbol_usuarios"] = arbol;
                }
  
            }

        }

        private bool verificarCampos()
        {
            if (string.IsNullOrEmpty(text_mailuser.Text) || string.IsNullOrEmpty(text_nickuser.Text) || string.IsNullOrEmpty(text_passuser.Text))
                return false;
            return true;
        }

        private void cargaMasiva(string pseudo_direccion)
        {
            string direccion = @pseudo_direccion;
        }

        #region Debug
        protected void boton_graficar_Click(object sender, EventArgs e)
        {
            if (Application["arbol_usuarios"] != null)
                servicio.graficarArbolBinario((ArbolBinario)Application["arbol_usuarios"]);
        }

        protected void boton_carga_masiva_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(text_carga_masiva.Text)&& Application["arbol_usuarios"] != null)
            {
                ArbolBinario aux = (ArbolBinario)Application["arbol_usuarios"];
                Application["arbol_usuarios"] = servicio.cargaUsuarios(@text_carga_masiva.Text, aux);

            }
        }
        #endregion


    }
}