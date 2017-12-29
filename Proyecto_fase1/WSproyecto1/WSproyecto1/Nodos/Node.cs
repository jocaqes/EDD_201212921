namespace WSproyecto1.Nodos
{
    [System.Serializable]
    public class Node<T>
    {
        public Node<T> siguiente;
        public Node<T> anterior;

        //nuevo para la matriz
        public int key;
        public string key_;
        //nuevo para la matriz

        public T item;

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


        #endregion

        public Node()
        {
            siguiente = null;
            anterior = null;
        }
        public Node(T item)
        {
            this.item = item;
            siguiente = null;
            anterior = null;
        }
        public Node(T item,int key, string key_)
        {
            this.item = item;
            siguiente = null;
            anterior = null;
            this.key = key;
            this.key_ = key_;
        }
    }
}