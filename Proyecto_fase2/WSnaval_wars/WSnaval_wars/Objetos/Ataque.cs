using System;

namespace WSnaval_wars.Objetos
{
    public class Ataque
    {
        private string x;
        private int y;
       // private Unidad atacante;
        private bool resultado;
        private string tipo_unidad_danyada;
        private string emisor;
        private string receptor;
        private string fecha;
        private string tiempo_restante;
        private int numero_ataque;

        #region GyS
        public string X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        /*internal Unidad Atacante
        {
            get
            {
                return atacante;
            }

            set
            {
                atacante = value;
            }
        }*/

        public bool Resultado
        {
            get
            {
                return resultado;
            }

            set
            {
                resultado = value;
            }
        }

        public string Tipo_unidad_danyada
        {
            get
            {
                return tipo_unidad_danyada;
            }

            set
            {
                tipo_unidad_danyada = value;
            }
        }

        public string Emisor
        {
            get
            {
                return emisor;
            }

            set
            {
                emisor = value;
            }
        }

        public string Receptor
        {
            get
            {
                return receptor;
            }

            set
            {
                receptor = value;
            }
        }

        public string Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public string Tiempo_restante
        {
            get
            {
                return tiempo_restante;
            }

            set
            {
                tiempo_restante = value;
            }
        }

        public int Numero_ataque
        {
            get
            {
                return numero_ataque;
            }

            set
            {
                numero_ataque = value;
            }
        }
        #endregion

        public Ataque(string x, int y, /*Unidad atacante,*/ bool resultado, string tipo_unidad_danyada, string emisor, string receptor, string tiempo_restante, int numero_ataque)
        {
            this.x = x;
            this.y = y;
            //this.atacante = atacante;
            this.resultado = resultado;
            this.tipo_unidad_danyada = tipo_unidad_danyada;
            this.emisor = emisor;
            this.receptor = receptor;
            fecha = DateTime.Today.ToString("dd-MM-yyyy");
            this.tiempo_restante = tiempo_restante;
            this.numero_ataque = numero_ataque;
        }

        public Ataque(int y)//debug
        {
            this.y = y;
        }

        public Ataque()
        {

        }
    }
}