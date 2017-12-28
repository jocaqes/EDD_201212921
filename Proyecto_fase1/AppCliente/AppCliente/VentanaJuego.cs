using System.Windows.Forms;

namespace AppCliente
{
    public partial class VentanaJuego : Form
    {


        public VentanaJuego()
        {
            InitializeComponent();
        }



        private void VentanaJuego_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
