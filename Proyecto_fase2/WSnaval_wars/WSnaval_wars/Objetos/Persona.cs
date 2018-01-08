using WSnaval_wars.Estructuras;
namespace WSnaval_wars.Objetos
{
    [System.Serializable]
    public class Persona
    {
        public string password;
        public string mail;
        private bool conectado;
        public ListaD<Juego> juegos;
        public AVL<Persona> contactos;//este va a dar lio
       // public Lista<Juego> juegos;

        #region GyS
        public bool Conectado
        {
            get
            {
                return conectado;
            }

            set
            {
                conectado = value;
            }
        }

        public void setConectado(string valor)
        {
            if (valor.Equals("0"))
            {
                Conectado = false;
            }
            else
                Conectado = true;
        }
        #endregion

        public Persona()
        {

        }

        public Persona(string password, string mail, string conectado="1")
        {
            this.password = password;
            this.mail = mail;
            if (conectado.Equals("1"))
                this.conectado = true;
            else
                this.conectado = false;
            juegos = new ListaD<Juego> ();
            contactos = new AVL<Persona>();
            //juegos = new Lista<Juego>();
        }

        public Persona(string password, string mail, bool conectado=true)
        {
            this.password = password;
            this.mail = mail;
            this.conectado = conectado;
            juegos = new ListaD<Juego>();
            contactos = new AVL<Persona>();
            //juegos = new Lista<Juego>();
        }
    }
}