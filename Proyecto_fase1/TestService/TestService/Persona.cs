
namespace TestService
{
    [System.Serializable]
    public class Persona
    {
        private string nombre;
        private int edad;
        private string mail;

        public Persona()
        {

        }

        public Persona(string nombre, int edad, string mail)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.mail = mail;
        }

        public int factorial(int numero)
        {
            if (numero <= 1)
                return 1;
            else
                return numero * factorial(numero - 1);
        }


        #region GyS
        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public int Edad
        {
            get
            {
                return edad;
            }

            set
            {
                edad = value;
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
        #endregion
    }
}