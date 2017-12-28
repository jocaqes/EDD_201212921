
namespace WSproyecto1.Objetos
{
    [System.Serializable]
    public class Juego
    {
        private string usuario;
        private string oponente;
        private int unidades_desplegadas;
        private int sobrevivientes;
        private int destruidos;
        private bool gano;

        #region GyS
        public string Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public string Oponente
        {
            get
            {
                return oponente;
            }

            set
            {
                oponente = value;
            }
        }

        public int Unidades_desplegadas
        {
            get
            {
                return unidades_desplegadas;
            }

            set
            {
                unidades_desplegadas = value;
            }
        }

        public int Sobrevivientes
        {
            get
            {
                return sobrevivientes;
            }

            set
            {
                sobrevivientes = value;
            }
        }

        public int Destruidos
        {
            get
            {
                return destruidos;
            }

            set
            {
                destruidos = value;
            }
        }

        public bool Gano
        {
            get
            {
                return gano;
            }

            set
            {
                gano = value;
            }
        }
        #endregion

        public Juego(string usuario, string oponente, int unidades_desplegadas, int sobrevivientes, int destruidos, int gano)
        {
            this.usuario = usuario;
            this.oponente = oponente;
            this.unidades_desplegadas = unidades_desplegadas;
            this.sobrevivientes = sobrevivientes;
            this.destruidos = destruidos;
            if (gano == 1)
                this.gano = true;
            else
                this.gano = false;
        }
    }
}