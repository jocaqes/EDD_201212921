namespace WSnaval_wars.Nodos
{
    [System.Serializable]//nuevo
    public class Nodus<T>
    {
        public Nodus<T> siguiente;
        private T item;

        public Nodus()
        {
            siguiente = null;
        }
        public Nodus(T item)
        {
            siguiente = null;
            this.item = item;
        }

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
    }
}