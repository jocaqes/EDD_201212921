namespace WSproyecto1
{
    public class Persona
    {
        private string nick;
        private string contrasenya;
        private string correo;
        private bool conectado;

        

        //Lista de juegos
        public Persona()
        {
            //constructor vacio
        }

        public Persona(string nick, string contrasenya, string correo, bool conectado)
        {
            this.nick = nick;
            this.contrasenya = contrasenya;
            this.correo = correo;
            this.conectado = conectado;
        }


        #region getters y setters
        public string Nick
        {
            get
            {
                return nick;
            }

            set
            {
                nick = value;
            }
        }

        public string Contrasenya
        {
            get
            {
                return contrasenya;
            }

            set
            {
                contrasenya = value;
            }
        }

        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
            }
        }

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
        #endregion getters y setters
    }
}