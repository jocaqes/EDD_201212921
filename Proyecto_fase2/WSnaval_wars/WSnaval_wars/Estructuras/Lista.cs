using WSnaval_wars.Nodos;
namespace WSnaval_wars.Estructuras
{
    public class Lista<T>
    {
        public Nodus<T> raiz;
        public Nodus<T> fin;
        public int count;

        public Lista()
        {
            raiz = null;
            count = 0;
        }

        #region Insertar
        public void push(T item)
        {
            if (isEmpty())
            {
                raiz = fin = new Nodus<T>(item);
            }
            else
            {
                fin.siguiente = new Nodus<T>(item);
                fin = fin.siguiente;

            }
            count++;
        }

        public void pushTop(T item)
        {
            if (isEmpty())
            {
                raiz = fin = new Nodus<T>(item);
            }
            else
            {
                Nodus<T> aux = raiz;
                raiz = new Nodus<T>(item);
                raiz.siguiente = aux;
            }
            count++;
        }

        public void pushAt(T item, int index)//agrega en la posicion solicitada
        {
            if (index > count - 1 || index < 1)
            {
            }
            else
            {
                if (index == 0)
                {
                    Nodus<T> aux = raiz.siguiente;
                    raiz.siguiente = new Nodus<T>(item);
                    raiz.siguiente.siguiente = aux;
                }
                else if (index == count - 1)
                {
                    Nodus<T> aux = raiz;
                    while (aux.siguiente != fin)
                    {
                        aux = aux.siguiente;
                    }
                    aux.siguiente = new Nodus<T>(item);
                    aux.siguiente.siguiente = fin;
                }
                else
                {
                    Nodus<T> aux;
                    Nodus<T> actual = raiz;
                    for (int i = 1; i < index; i++)
                    {
                        actual = actual.siguiente;//anterior
                    }
                    aux = actual.siguiente;//siguiente
                    actual.siguiente = new Nodus<T>(item);
                    actual.siguiente.siguiente = aux;
                }
                count++;
            }
        }

        #endregion

        #region Extraer
        public T pop()//retira de la cima
        {
            if (isEmpty())
            {
                return default(T);
            }
            else
            {
                Nodus<T> aux = raiz;
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

        public Nodus<T> pull(int index, bool eliminar = false)//retira de posicion index, elimina solo si la bandera es verdadera
        {
            if (isEmpty())
            {
                return null;
            }
            else
            {
                if (index >= 0 && index < count)
                {
                    Nodus<T> aux = raiz;
                    if (index == 0)
                    {
                        if (eliminar)//para no tener que hacer dos funciones, si pongo true si elimina, si no solo recupero el valor
                        {
                            raiz = raiz.siguiente;
                            if (isEmpty())
                            {
                                fin = null;
                            }
                            count--;
                        }
                        return aux;
                    }
                    else if (index == count - 1)//el final
                    {
                        Nodus<T> actual = raiz;
                        int i;
                        for (i = 1; i < index; i++)
                        {
                            actual = actual.siguiente;//recupero al anterior
                        }
                        aux = fin;//aux es el ultimo
                        if (eliminar)
                        {
                            fin = actual;//muevo el puntero de fin a actual, que es el anterior
                            fin.siguiente = null;//hago que fin no tenga nada despues
                            count--;
                        }
                        return aux;
                    }
                    else
                    {
                        int i;
                        Nodus<T> actual = raiz;
                        for (i = 1; i < index; i++)
                        {
                            actual = actual.siguiente;//recupero al anterior
                        }
                        aux = actual.siguiente;//guardo a aux
                        //T item = aux.siguiente.item;//ya revise que el index es valido, asi que este siguiente no debería ser null
                        if (eliminar)
                        {
                            actual.siguiente = aux.siguiente;
                            //aux.siguiente = aux.siguiente.siguiente;
                            count--;
                        }
                        return aux;
                    }
                }
                return null;
            }

        }
        #endregion

        #region Aux
        private bool isEmpty()
        {
            return raiz == null;
        }
        #endregion
    }
}