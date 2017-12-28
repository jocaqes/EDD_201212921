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
            servicio = (NavalWarsServiceClient)Session["servicio"];

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

        #region Carga Masiva
        /* protected void boton_graficar_Click(object sender, EventArgs e)
         {
             if (Application["arbol_usuarios"] != null)
                 servicio.graficarArbolBinario((ArbolBinario)Application["arbol_usuarios"]);
         }*/
        protected void boton_graficar_Click(object sender, EventArgs e)
        {
            if (servicio.graficarArbolBinario(Server.MapPath("Imagenes")))
            {
                label_msj_carga.Text = "Arbol Graficado";
                servicio.graficarArbolBinarioEspejo(Server.MapPath("Imagenes"));
                Page.ClientScript.RegisterStartupScript(
                GetType(), "OpenWindow", "window.open('Reports.aspx','_newtab');", true);
                //label_msj_carga.Text = Server.MapPath("Imagenes");
            }
            else
                label_msj_carga.Text = "Error al graficar el arbol";
                /*Page.ClientScript.RegisterStartupScript(
                GetType(), "OpenWindow", "window.open('Reports.aspx','_newtab');", true);*/
        }



        protected void boton_carga_masiva_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(text_carga_masiva.Text))
            {

                //label_msj_carga.Text = servicio.cargaUsuarios(@text_carga_masiva.Text);
                if (servicio.cargaUsuarios(@text_carga_masiva.Text))
                    label_msj_carga.Text = "Carga realizada con exito";
                else
                    label_msj_carga.Text = "Error al cargar los datos";

            }
            else
                text_carga_masiva.Text = "No puede dejar la direccion vacia";
        }

        protected void boton_carga_juegos_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(text_carga_juegos.Text))
            {
                if (servicio.cargaJuegos(@text_carga_juegos.Text))
                    text_carga_masiva.Text = "Carga realizada con exito";
                else
                    text_carga_masiva.Text = "Error al cargar los datos";
            }
            else
                text_carga_masiva.Text = "No puede dejar la direccion vacia";
        }

        #endregion

        #region ABC Usuario
        protected void boton_aceptar_Click(object sender, EventArgs e)//A
        {
            if (!verificarCampos())
                label_msj_insertar.Text="No pueden haber campos vacios";
            else
            {
                Persona nueva = servicio.newPersona(text_passuser.Text, text_mailuser.Text);
                if (servicio.insertar(text_nickuser.Text, nueva))
                    label_msj_insertar.Text = "Usuario agregado";
                else
                    label_msj_insertar.Text = "Usuario repetido";
            }
        }


        protected void boton_buscar_Click(object sender, EventArgs e)//B
        {
            if (!string.IsNullOrEmpty(text_busqueda.Text))
            {

               Nodo nueva = servicio.buscar(text_busqueda.Text);//nodo contiene el nick, persona contiene el resto
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

        protected void boton_modificar_Click(object sender, EventArgs e)
        {
            if (Session["usuario_encontrado"]!=null)
            {
                Persona nueva = servicio.newPersona(text_pass_busqueda.Text,text_mail_busqueda.Text);//nodo contiene el nick, persona contiene el resto
                if (servicio.modificar(Session["usuario_encontrado"].ToString(), nueva))
                {
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
                if (servicio.eliminar(Session["usuario_encontrado"].ToString()))
                {
                    label_msj_busqueda.Text = "Usuario eliminado";
                    text_mail_busqueda.Text = "";
                    text_busqueda.Text = "";
                    text_pass_busqueda.Text = "";
                    Session["usuario_encontrado"] = null;
                }else
                {
                    label_msj_busqueda.Text = "El usuario no existe";
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
                if( servicio.agregarJuego(juego, text_jugador_principal.Text))
                    label_msj_juego.Text = "Juego agregado";
                else
                    label_msj_juego.Text = "Error al agregar el juego";


            }
            else
            {
                label_msj_juego.Text = "No puede dejar espacios en blanco";
            }

        }

        #endregion


    }
}