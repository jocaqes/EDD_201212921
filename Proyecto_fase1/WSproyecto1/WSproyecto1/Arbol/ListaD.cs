namespace WSproyecto1.Arbol
{
    [System.Serializable]
    public class ListaD<T>
    {
        public Nodos.Node<T> raiz;
        public Nodos.Node<T> fin;
        int count;

        public ListaD()
        {
            raiz = fin = null;
            count = 0;
        }

        public bool isEmpty()
        {
            return raiz == null;
        }

        public void insertar(T item)
        {
            if (isEmpty())
            {
                raiz = fin = new Nodos.Node<T>(item);
            }else
            {
                fin.siguiente = new Nodos.Node<T>(item);
                fin.siguiente.anterior = fin;
                fin = fin.siguiente;
            }
            count++;
        }

        public Nodos.Node<T> sacar()
        {
            if (isEmpty())
            {
                return null;
            }
            else
            {
                Nodos.Node<T> aux = raiz;
                raiz = raiz.siguiente;
                if (!isEmpty())
                    raiz.anterior = null;
                count--;
                return aux;
            }

        }

    }
}