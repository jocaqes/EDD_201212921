using System;
using System.Windows.Forms;

namespace AppCliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void boton_login_Click(object sender, EventArgs e)
        {
            VentanaJuego nueva = new VentanaJuego();
            nueva.Show();
            this.Hide();
        }
    }
}
