using System;
using TestWeb.TestService;

namespace TestWeb
{
    public partial class TestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Persona yo = new Persona();
        }
    }
}