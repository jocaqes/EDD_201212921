namespace WSproyecto1.Objetos
{
    [System.Serializable]
    public class Persona
    {
        private string password;
        private string mail;
        private bool conectado;
        //ListaD<Partidas> mis_partidas;
        /*No tiene su nick porque esa sera su llave, y ya se guarda en su nodo*/


        public Persona(string password, string mail)
        {
            this.password = password;
            this.mail = mail;
            conectado = false;
            //mis_partidas=new ListaD<Partidas>();
        }

        #region Setters y Getters
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Mail
        {
            get
            {
                return mail;
            }

            set
            {
                mail = value;
            }
        }

        public bool getConectado()
        {
            return conectado;
        }
        public void setConectado(string val)
        {
            if (val.Equals("1"))
                conectado = true;
            else
                conectado = false;
        }
        #endregion
    }
}