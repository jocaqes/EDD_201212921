namespace WSproyecto1.Nodos
{
    [System.Serializable]
    public class Node<T>
    {
        public Node<T> siguiente;
        public Node<T> anterior;
        private T item;

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
    }
}