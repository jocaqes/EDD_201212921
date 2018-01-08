namespace WSnaval_wars.Nodos
{
    [System.Serializable]
    public class NodoD<T>
    {
        [System.Xml.Serialization.XmlIgnore]
        public NodoD<T> anterior;//ignoro a anterior, por ahora
        public NodoD<T> siguiente;
        private T item;

        public NodoD(T item)
        {
            this.item = item;
            anterior = siguiente = null;
        }

        public NodoD()
        {
            anterior = siguiente = null;
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