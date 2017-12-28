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
                Response.Redirect("Home.aspx?msj=mty");
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
        /* protected void boton_graficar_Click(object sender, EventArgs e)
         {
             if (Application["arbol_usuarios"] != null)
                 servicio.graficarArbolBinario((ArbolBinario)Application["arbol_usuarios"]);
         }*/
        protected void boton_graficar_Click(object sender, EventArgs e)
        {
            if (Session["arbol_usuarios"] != null)
                servicio.graficarArbolBinario((ArbolBinario)Session["arbol_usuarios"]);
        }



        protected void boton_carga_masiva_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(text_carga_masiva.Text)&& Session["arbol_usuarios"] != null)
            {
                ArbolBinario aux = (ArbolBinario)Session["arbol_usuarios"];
                Session["arbol_usuarios"] = servicio.cargaUsuarios(@text_carga_masiva.Text, aux);

            }
        }

        protected void boton_carga_juegos_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(text_carga_juegos.Text) && Session["arbol_usuarios"] != null)
            {
                ArbolBinario aux = (ArbolBinario)Session["arbol_usuarios"];
                Session["arbol_usuarios"]=servicio.cargaJuegos(@text_carga_juegos.Text, aux);
            }
        }

        #endregion

        #region ABC Usuario
        protected void boton_aceptar_Click(object sender, EventArgs e)//A
        {
            if (!verificarCampos())
                label_msj_insertar.Text="No pueden haber campos vacios";
            else
            {
                if (Session["arbol_usuarios"] != null)
                {
                    ArbolBinario arbol = (ArbolBinario)Session["arbol_usuarios"];
                    Persona nueva = servicio.newPersona(text_passuser.Text, text_mailuser.Text);
                    arbol = servicio.insertar(text_nickuser.Text, nueva, arbol);
                    Session["arbol_usuarios"] = arbol;
                    label_msj_insertar.Text = "Usuario ingresado con exito";
                }else
                {
                    label_msj_insertar.Text = "Error al insertar el usuario, intente de nuevo";
                }
            }
        }


        protected void boton_buscar_Click(object sender, EventArgs e)//B
        {
            if (!string.IsNullOrEmpty(text_busqueda.Text))
            {
                if (Session["arbol_usuarios"] != null)
                {
                    ArbolBinario arbol = (ArbolBinario)Session["arbol_usuarios"];
                    Nodo nueva = servicio.buscar(text_busqueda.Text, arbol);//nodo contiene el nick, persona contiene el resto
                    if (nueva != null)
                    {
                        text_pass_busqueda.Text = nueva.item.password;
                        text_mail_busqueda.Text = nueva.item.mail;
                        Session["usuario_encontrado"] = nueva.key;
                        label_msj_busqueda.Text = "Usuario encontrado";
                    }
                    else
                    {
                        label_msj_busqueda.Text = "No existe ese usuario";
                    }

                }
            }
        }

        protected void boton_modificar_Click(object sender, EventArgs e)
        {
            if (Session["usuario_encontrado"]!=null)
            {
                if (Session["arbol_usuarios"] != null)
                {
                    ArbolBinario arbol = (ArbolBinario)Session["arbol_usuarios"];
                    Persona nueva = servicio.newPersona(text_pass_busqueda.Text,text_mail_busqueda.Text);//nodo contiene el nick, persona contiene el resto
                    arbol=servicio.modificar(Session["usuario_encontrado"].ToString(), nueva, arbol);
                    Session["arbol_usuarios"] = arbol;
                    label_msj_busqueda.Text = "Usuario modificado";
                    text_mail_busqueda.Text = "";
                    text_busqueda.Text = "";
                    text_pass_busqueda.Text = "";
                    Session["usuario_encontrado"] = null;
                }
            }
        }

        protected void boton_eliminar_Click(object sender, EventArgs e)
        {
            if (Session["usuario_encontrado"] != null)
            {
                if (Session["arbol_usuarios"] != null)
                {
                    ArbolBinario arbol = (ArbolBinario)Session["arbol_usuarios"];
                    arbol = servicio.eliminar(Session["usuario_encontrado"].ToString(),arbol);
                    Session["arbol_usuarios"] = arbol;
                    label_msj_busqueda.Text = "Usuario eliminado";
                    text_mail_busqueda.Text = "";
                    text_busqueda.Text = "";
                    text_pass_busqueda.Text = "";
                    Session["usuario_encontrado"] = null;
                }
            }

        }



        #endregion

        #region ABC juego
        private bool checkValsJuego()
        {
            if (string.IsNullOrEmpty(text_jugador_principal.Text) || string.IsNullOrEmpty(text_oponente.Text)
                || string.IsNullOrEmpty(text_desplegadas.Text) || string.IsNullOrEmpty(text_sobrevivientes.Text)
                || string.IsNullOrEmpty(text_destruidos.Text))
                return false;
            return true;
        }

        protected void boton_add_juego_Click(object sender, EventArgs e)
        {
            if (checkValsJuego())
            {
                if (Session["arbol_usuarios"] != null)
                {
                    int gano;
                    if (check_victoria.Checked) {
                        gano = 1;
                    }else
                    {
                        gano = 0;
                    }

                    Juego juego = servicio.newJuego(text_jugador_principal.Text, text_oponente.Text,
                        int.Parse(text_desplegadas.Text), int.Parse(text_sobrevivientes.Text),
                        int.Parse(text_destruidos.Text), gano);
                    ArbolBinario arbol = (ArbolBinario)Session["arbol_usuarios"];
                    Session["arbol_usuarios"] = servicio.agregarJuego(juego, text_jugador_principal.Text, arbol);
                    label_msj_juego.Text = "Juego agregado";
                }

            }else
            {
                label_msj_juego.Text = "No puede dejar espacios en blanco";
            }

        }

        #endregion


    }
}