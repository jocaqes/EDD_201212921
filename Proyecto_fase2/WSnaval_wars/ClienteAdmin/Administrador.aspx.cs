using System;
using ClienteAdmin.Clases_aux;
using ClienteAdmin.NWwervice;

namespace ClienteAdmin
{
    public partial class Administrador : System.Web.UI.Page
    {
        NavalWarsWSSoapClient servicio;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!esAdmin())
            {
                Response.Redirect("Home.aspx?msj=mty");
            }
            servicio = new NavalWarsWSSoapClient();
        }

        #region Auxiliar
        private void cargarDropList()
        {
            drop_ABin_usuarios.Items.Clear();
            string aux = servicio.listarUsuarios();
            string[] arr = aux.Split(',');
            int limite = arr.Length - 1;
            for (int i = 0; i < limite; i++)
            {
                drop_ABin_usuarios.Items.Add(arr[i]);
            }
        }
        private bool reglasVacias()
        {
            if (string.IsNullOrEmpty(text_matriz_columnas.Text) || string.IsNullOrEmpty(text_matriz_filas.Text)||string.IsNullOrEmpty(text_matriz_unidades.Text))
                return true;
            return false;
        }
        #endregion

        #region Revision de usuario
        private bool esAdmin()
        {
            if (Session["user"]==null||string.IsNullOrEmpty(Session["user"].ToString()))
                return false;
            return true;
        }
        #endregion

        #region Carga Masiva
        protected void boton_ABin_carga_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(text_ABin_carga.Text))
            {
                if (servicio.binarioCargaMasiva(text_ABin_carga.Text))
                {
                    msj_ABin_carga.Text = "Carga exitosa";
                    cargarDropList();
                }
                else
                {
                    msj_ABin_carga.Text = "Carga fallida";

                }
            }
            else
            {
                msj_ABin_carga.Text = "No puede dejar la direccion vacia";
            }
        
        }

        protected void boton_ABin_games_carga_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(text_ABin_games.Text))
            {
                if (servicio.binarioCargaJuegos(text_ABin_games.Text))
                {
                    msj_ABin_carga.Text = "Carga exitosa";
                    //cargarDropList();
                }
                else
                {
                    msj_ABin_carga.Text = "Carga fallida";
                }
            }
            else
            {
                msj_ABin_carga.Text = "No puede dejar la direccion vacia";
            }
        
        }
        #endregion

        #region Buscar
        protected void boton_ABin_buscar_Click(object sender, EventArgs e)
        {
            string aux = drop_ABin_usuarios.SelectedValue;
            if (!string.IsNullOrEmpty(aux))
            {
                Persona user = servicio.binarioBuscar(aux);//modificado
                if (user != null)
                {
                    text_ABin_Mmail.Text = user.mail;//modificado
                    text_ABin_Mpass.Text = user.password;//modificado
                    radio_ABin_Mconectado.Checked = user.Conectado;//modificado
                    label_juegos.Text = Tabla.tablaUsuarios(user);//modificado
                }
                else
                {
                    msj_ABin_modificar.Text = "Usuario no encontrado";
                }
            }
        
        }

        #endregion

        #region Modificar eliminar
        protected void boton_ABin_modificar_Click(object sender, EventArgs e)
        {
            if (hayDatosModificar())
            {
                if (servicio.binarioModificar(drop_ABin_usuarios.SelectedValue, text_ABin_Mmail.Text, text_ABin_Mpass.Text, radio_ABin_Mconectado.Checked))
                {
                    msj_ABin_modificar.Text = "Modificacion exitosa";
                }
                else
                {
                    msj_ABin_modificar.Text = "Error al modificar";
                }
            }
            else
            {
                msj_ABin_modificar.Text = "No puede dejar campos vacios";
            }
        
        }

        protected void boton_ABin_eliminar_Click(object sender, EventArgs e)
        {
            if (servicio.binarioEliminar(drop_ABin_usuarios.SelectedValue))
            {
                cargarDropList();
                limpiarText();
                msj_ABin_modificar.Text = "Usuario eliminado";
            }
            else
            {
                msj_ABin_modificar.Text = "Error al eliminar";
            }
        
        }

        private bool hayDatosModificar()
        {
            if (string.IsNullOrEmpty(text_ABin_Mmail.Text) || string.IsNullOrEmpty(text_ABin_Mpass.Text))
                return false;
            return true;
        }

        private void limpiarText()
        {
            text_ABin_Mmail.Text = "";
            text_ABin_Mpass.Text = "";
        }


        #endregion

        #region Reporte Arbol Binario
        protected void boton_reporte_binario_Click(object sender, EventArgs e)
        {
            if (servicio.graficarBinario(Server.MapPath("Imagenes"), "binario.dot", "binario.png"))
            {
                servicio.graficarEspejo(Server.MapPath("Imagenes"), "espejo.dot", "espejo.png");
                msj_reporte_binario.Text = "Reporte Generado";
            }
            else
                msj_reporte_binario.Text = "Error al Generar el reporte";

        }
        private bool reporteCompletoBinario(ref string mensaje_error)
        {

            return true;
        }
        #endregion

        #region Matriz Ortogonal
        protected void boton_matriz_set_rules_Click(object sender, EventArgs e)
        {
            if (reglasVacias())
            {
                msj_matriz_rules.Text = "No puede dejar campos vacios";
            }
            else
            {
                int filas = int.Parse(text_matriz_filas.Text);
                int columnas = int.Parse(text_matriz_columnas.Text);
                int unidades = int.Parse(text_matriz_unidades.Text);
                if (servicio.ortogonalSetMaxFilasColumnas(filas, columnas))//siempre da true
                {
                    drawTablerosDeJuego();
                    servicio.ortogonalSetMaxUnidades(unidades);
                    msj_matriz_rules.Text = "Reglas actualizadas";
                }
            }
        
        }
        private void drawTablerosDeJuego()
        {
            servicio.ortogonalTableroDeJuego(Server.MapPath("Imagenes"), "tablero_satelite.dot", "tablero_satelite.png", 3);
            servicio.ortogonalTableroDeJuego(Server.MapPath("Imagenes"), "tablero_aviones.dot", "tablero_aviones.png", 2);
            servicio.ortogonalTableroDeJuego(Server.MapPath("Imagenes"), "tablero_barcos.dot", "tablero_barcos.png", 1);
            servicio.ortogonalTableroDeJuego(Server.MapPath("Imagenes"), "tablero_submarinos.dot", "tablero_submarinos.png", 0);
        }
        #endregion
    }
}