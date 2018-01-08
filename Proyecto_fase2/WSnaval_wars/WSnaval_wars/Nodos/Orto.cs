using WSnaval_wars.Objetos;
namespace WSnaval_wars.Nodos
{

    public class Orto<T>
    {
        public Orto<T> izq, der, up, down, top, bottom;
        private T item;
        //public int fila;
        //public string columna;

        public Orto()
        {
            izq = der = up = down = top = bottom = null;
        }

        public Orto(T item)
        {
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