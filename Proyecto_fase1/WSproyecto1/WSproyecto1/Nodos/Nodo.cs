using WSproyecto1.Objetos;

namespace WSproyecto1.Nodos
{
    [System.Serializable]
    public class Nodo//nodo para arbol binario
    {
        public Nodo izq;
        public Nodo der;
        public string key;//llave para la busqueda de items, no se repite dentro del ojeto item
        private Persona item;//item generico



        public Nodo()//constructor vacio
        {
            izq = der = null;
        }


        public Nodo(Persona item, string key)
        {
            this.item = item;
            izq = der = null;
            this.key = key;
        }


        #region Getters y setters
        public Persona Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
            }
        }
        #endregion


    }
}