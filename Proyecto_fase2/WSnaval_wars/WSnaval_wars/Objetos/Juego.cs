namespace WSnaval_wars.Objetos
{
    [System.Serializable]
    public class Juego
    {
        private string usuario;
        private string oponente;
        private int unidades_desplegadas;
        private int unidades_sobrevivientes;
        private int unidades_destruidas_por_mi;
        private bool gane;

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

        public int Unidades_sobrevivientes
        {
            get
            {
                return unidades_sobrevivientes;
            }

            set
            {
                unidades_sobrevivientes = value;
            }
        }

        public int Unidades_destruidas_por_mi
        {
            get
            {
                return unidades_destruidas_por_mi;
            }

            set
            {
                unidades_destruidas_por_mi = value;
            }
        }

        public bool Gane
        {
            get
            {
                return gane;
            }

            set
            {
                gane = value;
            }
        }
        #endregion

        public Juego()
        {

        }

        public Juego(string usuario, string oponente, int unidades_desplegadas, int unidades_sobrevivientes, int unidades_destruidas_por_mi, string gane)
        {
            this.usuario = usuario;
            this.oponente = oponente;
            this.unidades_desplegadas = unidades_desplegadas;
            this.unidades_sobrevivientes = unidades_sobrevivientes;
            this.unidades_destruidas_por_mi = unidades_destruidas_por_mi;
            if (gane.Equals("1"))
                this.gane = true;
            else
                this.gane = false;
        }
    }
}