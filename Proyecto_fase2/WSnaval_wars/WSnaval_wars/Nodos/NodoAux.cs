namespace WSnaval_wars.Nodos
{
    public class NodoAux<T>//nodo auxiliar para la matriz ortogonal
    {
        public NodoAux<T> anterior;
        public NodoAux<T> siguiente;
        private int key;//llave de filas
        private string key_;//llave de columnas
        public T item;

        #region GyS
        public int Key
        {
            get
            {
                return key;
            }

            set
            {
                key = value;
            }
        }

        public string Key_
        {
            get
            {
                return key_;
            }

            set
            {
                key_ = value;
            }
        }
        public T Item
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

        public NodoAux()
        {
            anterior = siguiente = null;
        }

        public NodoAux(T item, int key)
        {
            this.item = item;
            this.key = key;
        }

        public NodoAux(T item, string key_)
        {
            this.item = item;
            this.key_ = key_;
        }

        public NodoAux(T item)
        {
            this.item = item;
        }
    }
}