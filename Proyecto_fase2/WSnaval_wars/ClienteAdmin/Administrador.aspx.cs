using System;
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
        #endregion

        #region Buscar
        protected void boton_ABin_buscar_Click(object sender, EventArgs e)
        {
            string aux = drop_ABin_usuarios.SelectedValue;
            if (!string.IsNullOrEmpty(aux))
            {
                NodoOfPersona nodo_aux = servicio.binarioBuscar(aux);
                if (nodo_aux != null)
                {
                    text_ABin_Mmail.Text = nodo_aux.Item.mail;
                    text_ABin_Mpass.Text = nodo_aux.Item.password;
                    radio_ABin_Mconectado.Checked = nodo_aux.Item.Conectado;
                }else
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
                if (servicio.binarioModificar(drop_ABin_usuarios.SelectedValue, text_ABin_Mmail.Text, text_ABin_Mpass.Text,radio_ABin_Mconectado.Checked))
                {
                    msj_ABin_modificar.Text = "Modificacion exitosa";
                }else
                {
                    msj_ABin_modificar.Text = "Error al modificar";
                }
            }else
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
            }else
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


    }
}