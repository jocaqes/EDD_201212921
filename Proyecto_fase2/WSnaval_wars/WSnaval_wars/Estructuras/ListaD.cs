using WSnaval_wars.Nodos;
namespace WSnaval_wars.Estructuras
{
    [System.Serializable]
    public class ListaD<T>
    {
        public NodoD<T> raiz;
        public NodoD<T> fin;
        public int count;

        public ListaD()
        {
            raiz = fin = null;
            count = 0;
        }

        #region Aux
        public bool isEmpty()
        {
            return raiz == null;
        }
        #endregion

        #region Insertar
        public void push(T item)
        {
            if (isEmpty())
            {
                raiz = fin = new NodoD<T>(item);
            }
            else
            {
                fin.siguiente = new NodoD<T>(item);
                fin.siguiente.anterior = fin;
                fin = fin.siguiente;

            }
            count++;
        }

        public void pushTop(T item)
        {
            if (isEmpty())
            {
                raiz = fin = new NodoD<T>(item);
            }
            else
            {
                NodoD<T> aux = raiz;
                raiz = new NodoD<T>(item);
                raiz.siguiente = aux;
                aux.anterior = raiz;
            }
            count++;
        }
        #endregion

        #region Buscar
        public T pop()//retira de la cima
        {
            if (isEmpty())
            {
                return default(T);
            }
            else
            {
                NodoD<T> aux = raiz;
                raiz = raiz.siguiente;
                if (isEmpty())
                {
                    fin = null;
                }
                T item = aux.Item;
                count--;
                return item;
            }
        }
        public T peekAt(int index)
        {
            if (isEmpty())
                return default(T);
            if (index < 0 || index >= count)
                return default(T);
            NodoD<T> aux = raiz;
            for (int i = 0; i < index; i++)
                aux = aux.siguiente;
            return aux.Item;
        }

        #endregion


    }
}