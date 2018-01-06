using WSnaval_wars.Nodos;

namespace WSnaval_wars.Estructuras
{
    public class AVL<T>
    {
        public Nodo<T> raiz;
        public int count;

        public AVL()
        {
            raiz = null;
            count = 0;
        }


        #region Rotaciones
        private Nodo<T> simpleIzq(Nodo<T> raiz)
        {
            Nodo<T> n_1 = null;//esto solo es por precaucion
            if (raiz == null)
                return null;
            n_1 = raiz.izq;
            if (n_1 == null)
                return raiz;//hasta aqui es solo por precaucion
            Nodo<T> aux = n_1.der;//recupero lo que esta a derecha de n_1
            n_1.der = raiz;
            raiz.izq = aux;
            actualizarAltura(raiz);
            actualizarAltura(n_1);
            return n_1;
        }
        private Nodo<T> simpleDer(Nodo<T> raiz)
        {
            Nodo<T> n_1 = null;
            if (raiz == null)
                return raiz;
            n_1 = raiz.der;
            if (n_1 == null)
                return null;
            Nodo<T> aux = n_1.izq;//recupero lo que esta a izq de n_1
            n_1.izq = raiz;
            raiz.der = aux;
            actualizarAltura(raiz);
            actualizarAltura(n_1);
            return n_1;
        }
        #endregion

        #region Altura
        private int altura(Nodo<T> nodo)
        {
            if (nodo == null)
                return -1;
            else
                return nodo.Altura;
        }
        private void actualizarAltura(Nodo<T> raiz)
        {
            if (raiz == null)
            {
                //do nothing, es solo por proteccion
            }
            else if (raiz.izq != null || raiz.der != null)
            {
                if (altura(raiz.izq) > altura(raiz.der))
                {
                    raiz.Altura = altura(raiz.izq) + 1;
                }
                else
                {
                    raiz.Altura = altura(raiz.der) + 1;
                }
            }
            else
            {
                raiz.Altura = 0;
            }

        }

        private Nodo<T> balancear(Nodo<T> raiz)
        {
            if (raiz != null)
            {
                if (altura(raiz.izq) - altura(raiz.der) == 2)//desbalanceo izq
                {
                    if (altura(raiz.izq.izq) >= altura(raiz.izq.der))//simple izq
                    {
                        raiz = simpleIzq(raiz);//cuidado
                    }
                    else//doble izq
                    {
                        raiz.izq = simpleDer(raiz.izq);//cuidado
                        raiz = simpleIzq(raiz);//cuidado

                    }
                }
                else if (altura(raiz.der) - altura(raiz.izq) == 2)//desbalanceo der
                {
                    if (altura(raiz.der.der) >= altura(raiz.der.izq))//simple der
                    {
                        raiz = simpleDer(raiz);//cuidado
                    }
                    else
                    {
                        raiz.der = simpleIzq(raiz.der);//cuiddo
                        raiz = simpleDer(raiz);//cuidado
                    }
                }
            }
            return raiz;
        }

        private bool isEmpty()
        {
            return raiz == null;
        }
        #endregion

        #region Insertar
        public void insertar(T item, string key)
        {
            if (isEmpty())
            {
                raiz = new Nodo<T>(item, key);
                //raiz.F_e = factorEquilibrio(raiz);
            }
            else
            {
                raiz = insertar(item, key, raiz);
                //actualizarAltura(raiz);
            }
        }
        private Nodo<T> insertar(T item, string key, Nodo<T> raiz, Nodo<T> padre = null, bool izq = true)
        {

            if (key.CompareTo(raiz.Key) < 0)//si la llave va a la izq de raiz
            {
                if (raiz.izq == null)
                {
                    raiz.izq = new Nodo<T>(item, key);
                }
                else
                {
                    insertar(item, key, raiz.izq, raiz);//agregue al padre
                }

            }
            else if (key.CompareTo(raiz.Key) > 0)//es mayor que la raiz
            {
                if (raiz.der == null)//si el derecho es null
                {
                    raiz.der = new Nodo<T>(item, key);//inserto inmediatamente
                }
                else
                    insertar(item, key, raiz.der, raiz, false);//contrario ingreso a la rama der; agregue al padre; agregue izq
            }
            raiz = balancear(raiz);
            if (padre != null)//efectivo
            {
                if (izq)
                    padre.izq = raiz;//esto es para que padre de la rotación siga apuntando a su hijo ya rotado
                else
                    padre.der = raiz;
            }

            actualizarAltura(raiz);//nuevo
            return raiz;
        }
        #endregion
    }
}