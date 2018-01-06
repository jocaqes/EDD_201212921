namespace WSnaval_wars.Objetos
{
    [System.Serializable]
    public class Persona
    {
        public string password;
        public string mail;
        private bool conectado;
        //public ListaD<Juego> juegos;

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

        public Persona(string password, string mail, bool conectado=true)
        {
            this.password = password;
            this.mail = mail;
            conectado = true;
            //juegos = new ListaD<Juego> ();
        }
    }
}