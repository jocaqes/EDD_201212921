using System;
using ClienteAdmin.NWwervice;

namespace ClienteAdmin
{
    public partial class ReporteBinario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        #region Cargar Reportes Extra
        private void cargarDatos()
        {
            NavalWarsWSSoapClient servicio = new NavalWarsWSSoapClient();
            label_altura.Text = servicio.binarioAltura().ToString();
            label_hojas.Text = servicio.binarioHojas().ToString();
            label_ramas.Text = servicio.binarioRamas().ToString();
        }
        #endregion
    }
}