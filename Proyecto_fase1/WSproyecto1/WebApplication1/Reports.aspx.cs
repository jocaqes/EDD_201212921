using System;
using WebApplication1.NavalWarsWS;
namespace WebApplication1
{

    public partial class Reports : System.Web.UI.Page
    {
        public NavalWarsServiceClient servicio;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["servicio"] != null)
                servicio = (NavalWarsServiceClient)Session["servicio"];
        }
    }
}