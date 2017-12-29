using System.Windows.Forms;
using AppCliente.NavalService;

namespace AppCliente
{
    public partial class VentanaJuego : Form
    {
        NavalWarsServiceClient servicio;

        public VentanaJuego(NavalWarsServiceClient servicio)
        {
            this.servicio = servicio;
            InitializeComponent();
        }



        private void VentanaJuego_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
