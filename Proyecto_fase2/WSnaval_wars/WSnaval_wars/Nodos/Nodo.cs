namespace WSnaval_wars.Nodos
{
    [System.Serializable]
    public class Nodo<T>
    {
        public Nodo<T> izq;
        public Nodo<T> der;
        private T item;
        private string key;
        private int altura;

        #region GyS
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

        public string Key
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

        public int Altura
        {
            get
            {
                return altura;
            }

            set
            {
                altura = value;
            }
        }
        #endregion

        public Nodo()
        {
            izq = der = null;
        }

        public Nodo(T item)
        {
            this.item = item;
            izq = der = null;
        }

        public Nodo(T item, string key)
        {
            this.item = item;
            this.key = key;
        }
    }
}