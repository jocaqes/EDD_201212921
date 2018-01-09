using System;
using ClienteAdmin.NWwervice;

namespace ClienteAdmin.Usuarios
{
    public partial class AgregarUnidades : System.Web.UI.Page
    {
        NavalWarsWSSoapClient servicio;
        private int max_columnas;
        private int max_unidades;
        private int satelites;
        private int caza, helicopteros, bombarderos;
        private int cruceros, fragata;
        private int submarinos;

        protected void Page_Load(object sender, EventArgs e)
        {
            servicio = new NavalWarsWSSoapClient();
            hayReglasSeteadas();
            cargarTableros();
        }

        #region Cargar Tableros
        private void cargarTableros()
        {
            label_tablero_satelites.Text = "<img alt=\"Intente Recargar\" src=\"../Imagenes/tablero_satelite.png\" heigh=\"500\" width=\"500\"/>";
            label_tablero_aviones.Text = "<img alt=\"Intente Recargar\" src=\"../Imagenes/tablero_aviones.png\" heigh=\"500\" width=\"500\"/>";
            label_tablero_barcos.Text = "<img alt=\"Intente Recargar\" src=\"../Imagenes/tablero_barcos.png\" heigh=\"500\" width=\"500\"/>";
            label_tablero_submarinos.Text = "<img alt=\"Intente Recargar\" src=\"../Imagenes/tablero_submarinos.png\" heigh=\"500\" width=\"500\"/>";
        }
        #endregion

        #region Revisar Reglas
        private void hayReglasSeteadas()
        {
            if (!servicio.ortogonalAreRulesSet())
            {
                Response.Write("<script>window.alert('No hay reglas de juego seteadas, contactese con el Administrador');window.location='../Usuario.aspx';</script>");
            }
        }
        #endregion
    }
}