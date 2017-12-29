using System;
using System.Windows.Forms;
using AppCliente.NavalService;

namespace AppCliente
{
    public partial class Form1 : Form
    {
        NavalWarsServiceClient servicio;
        public Form1()
        {
            InitializeComponent();
            servicio = new NavalWarsServiceClient();
        }

        private void boton_login_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(text_nick.Text)||string.IsNullOrEmpty(text_pass.Text))
                MessageBox.Show("No puede dejar valores vacios");
            else
            {
                Nodo respuesta = servicio.logIn(text_nick.Text, text_pass.Text);
                if (respuesta !=null)
                {
                    servicio.setNoJugador(1);
                    AgregarUnidades nueva = new AgregarUnidades(servicio,respuesta);
                    nueva.Show();
                    this.Hide();
                }else
                    MessageBox.Show("Usuario o contraseña invalidos");
            }
            


            
        }
    }
}
