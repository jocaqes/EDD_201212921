using WSnaval_wars.Nodos;
using WSnaval_wars.Objetos;

namespace WSnaval_wars.Estructuras
{
    public class Binario<T>
    {
        public Nodo<T> raiz;
        public int count;

        public Binario()
        {
            raiz = null;
            count = 0;
        }

        #region Insercion
        public bool insertar(T item, string key)
        {
            bool inserto_correctamente;//bandera para saber si inserto sin problemas, da false si el dato es repetido
            if (isEmpty())
            {
                raiz = new Nodo<T>(item, key);
                inserto_correctamente = true;//la bandera no retorna inmediatamente porque debo actualizar el numero de nodos, pero solo si la insercion fue correcta
            }
            else
                inserto_correctamente = insertar(raiz, item, key);
            if (inserto_correctamente)//verifico que la bandera sea verdadera para aumentar el numero de nodos
                count++;
            return inserto_correctamente;
        }

        private bool insertar(Nodo<T> raiz, T item, string key)//insercion recursiva
        {
            if (key.CompareTo(raiz.Key) < 0)//es menor que la raiz
            {
                if (raiz.izq == null)//si el izquierdo es null
                {
                    raiz.izq = new Nodo<T>(item, key);//inserto inmediatamente
                    return true;
                }
                else
                    return insertar(raiz.izq, item, key);//contrario ingreso a la rama izq
            }
            else if (key.CompareTo(raiz.Key) > 0)//es mayor que la raiz
            {
                if (raiz.der == null)//si el derecho es null
                {
                    raiz.der = new Nodo<T>(item, key);//inserto inmediatamente
                    return true;
                }
                else
                    return insertar(raiz.der, item, key);//contrario ingreso a la rama der
            }
            return false;//si el valor no es mayor ni menor, es una llave repetida, la descarto y retorno false(no hubo insercion)
        }
        #endregion

        #region Busqueda
        public Nodo<T> buscar(string key)
        {
            return buscar(raiz, key);//retorno un nodo porque el nodo tiene el nick, y para no repetir datos, el usuario no contiene el atributo nick
        }
        private Nodo<T> buscar(Nodo<T> padre, string key)
        {
            if (padre == null)
                return null;
            else if (padre.Key.Equals(key))//si el nodo actual corresponde a la llave
                return padre;//lo retorno
            else if (key.CompareTo(padre.Key) < 0)//puede estar a la izquierda
                return buscar(padre.izq, key);
            else//puede estar a la derecha
                return buscar(padre.der, key);

        }

        private Nodo<T> bMayorIzq(Nodo<T> padre, Nodo<T> raiz)//buscar al nodo mayor del lado izq, ingreso como parametro el izq del nodo al que le busco su mayor, raiz es el anterior al padre
        {
            if (padre.der != null)//si tiene un hijo derecho
            {
                if (padre.der.der == null)//y si ese derecho ya es el mayor
                {
                    Nodo<T> aux = padre.der;//protejo al nodo que debo retornar
                    padre.der = aux.izq;//le quito al padre ese derecho y lo reemplazo por los izq del aux
                    return aux;
                }
                return bMayorIzq(padre.der, null);//si no es el mayor me meto mas a la derecha, la raiz solo la necesito cuando solo hay nodos izq
            }
            //si no tiene un hijo derecho, el primer izq es el que debo retornar, esto ocurre en la primer iteracion
            //debo retornar a padre, la raiz es para poder subir los hijos de padre
            raiz.izq = padre.izq;
            return padre;
        }
        #endregion

        #region Eliminacion
        public bool eliminar(string key)
        {
            if (isEmpty())
                return false;
            else if (eliminar(key, raiz, raiz, false))//si la eliminacion es exitosa
            {
                count--;
                return true;
            }
            return false;//si la eliminacion no es exiosa

        }

        private bool eliminar(string key, Nodo<T> padre, Nodo<T> victima, bool izquierda)//victima es a quien voy a eliminar, padre es el nodo padre de victima, izquierda revisa si el nodo a eliminar lo encontre a la izq o der del padre
        {
            if (victima == null)//si no existe
            {
                return false;
            }
            else if (key.CompareTo(victima.Key) < 0)//aqui estoy buscando al nodo que quiero eliminar, al dar <0 podria estar a la izq
            {
                return eliminar(key, victima, victima.izq, true);//me adentro mas a la izq
            }
            else if (key.CompareTo(victima.Key) > 0)//aqui estoy buscando al nodo que quiero eliminar, al dar >0 podria estar a la der
            {
                return eliminar(key, victima, victima.der, false);//me adentro mas a la der
            }
            else //si lo encuentro
            {
                if (victima.izq == null && victima.der == null)/*Caso 1, el nodo no tiene hijos*/
                {
                    if (raiz == victima)//si es raiz
                    {
                        raiz = null;
                    }
                    else//si es nodo cualquiera
                    {
                        if (izquierda)
                        {
                            padre.izq = null;
                        }
                        else
                        {
                            padre.der = null;
                        }

                    }
                }/*Caso 1: el nodo no tiene hijos*/
                else if (victima.izq != null && victima.der != null)/*Caso 3: hijos en ambos lados(parece corto pero llevo mucho trabajo)*/
                {
                    Nodo<T> mayor_izq = bMayorIzq(victima.izq, victima);//recupero el mayor de la rama izq de la victima
                    if (raiz == victima)//si el nodo es la raiz
                    {
                        mayor_izq.der = victima.der;//recupero los hijos a la der de la victima
                        mayor_izq.izq = victima.izq;//recupero los hijos a la der de la victima
                        raiz = mayor_izq;//la raiz es ahora el nodo que encontre
                    }
                    else//si es un nodo cualquiera
                    {
                        mayor_izq.der = victima.der;//recupero los hijos a la der de la victima
                        mayor_izq.izq = victima.izq;//recupero los hijos a la der de la victima
                        if (izquierda)//si el nodo estaba a la izq de padre
                        {
                            padre.izq = mayor_izq;
                        }
                        else//si el nodo estaba a la der de padre
                        {
                            padre.der = mayor_izq;
                        }

                    }
                }/*Caso 3: hijos en ambos lados*/
                else/*Caso 2: si solo tiene hijos de un lado(deberia ser caso 3 pero el 3 suena a mayor dificultad asi que este es el 2)*/
                {
                    if (raiz == victima)//si es la raiz
                    {
                        if (victima.izq != null)//si los hijos estan en la izq
                        {
                            raiz = victima.izq;//subo los hijos a la raiz
                        }
                        else//si los hijos estan en la der
                        {
                            raiz = victima.der;//subo los hijos a la raiz
                        }
                    }
                    else//si es un nodo diferente a la raiz
                    {
                        if (izquierda)//si el hijo es en la izq
                        {
                            if (victima.izq != null)//si los hijos estan en la izq
                            {
                                padre.izq = victima.izq;//subo los hijos al padre
                            }
                            else//si los hijos estan en la der
                            {
                                padre.izq = victima.der;//subo los hijos al padre
                            }
                        }
                        else//si el hijo esta en la der
                        {
                            if (victima.izq != null)//si los hijos estan en la izq
                            {
                                padre.der = victima.izq;//subo los hijos al padre
                            }
                            else//si los hijos estan en la der
                            {
                                padre.der = victima.der;//subo los hijos al padre
                            }
                        }
                    }
                }/*Caso 2: si solo tiene hijos de un lado*/
            }

            return true;
        }
        #endregion

        #region Modificacion
        public bool modificar(T item, string nick)
        {
            if (isEmpty())
                return false;
            Nodo<T> aux = buscar(nick);
            if (aux == null)
                return false;
            aux.Item = item;
            return true;
        }
        #endregion

        #region Espejo
        public Binario<T> espejo()
        {
            Binario<T> arbol_espejo = new Binario<T>();
            arbol_espejo.raiz = reflejar(this.raiz);
            return arbol_espejo;
        }
        private Nodo<T> reflejar(Nodo<T> raiz)
        {
            if (raiz == null)
                return null;
            else
            {
                Nodo<T> nuevo = new Nodo<T>();
                nuevo.Item = raiz.Item;
                nuevo.Key = raiz.Key;
                nuevo.izq = reflejar(raiz.der);
                nuevo.der = reflejar(raiz.izq);
                return nuevo;
            }
        }
        #endregion

        #region Datos
        public int altura()
        {
            return altura(raiz);
        }
        private int altura(Nodo<T> raiz)
        {
            if (raiz == null)
            {
                return 0;
            }
            else if (raiz.izq == null && raiz.der == null)
            {
                return 1;
            }
            else
            {
                int left = 1 + altura(raiz.izq);
                int der = 1 + altura(raiz.der);
                if (left > der)
                    return left;
                else
                    return der;
            }
        }


        public int hojas()
        {
            return hojas(raiz);
        }
        private int hojas(Nodo<T> raiz)
        {
            if (raiz == null)
            {
                return 0;
            }
            else if (raiz.izq == null && raiz.der == null)
            {
                return 1;
            }
            else
            {
                return hojas(raiz.izq) + hojas(raiz.der);
            }
        }

        public int ramas()
        {
            return ramas(raiz);
        }
        private int ramas(Nodo<T> raiz)
        {
            if (raiz == null)
            {
                return 0;
            }
            else if (raiz.izq == null && raiz.der == null)
            {
                return 0;
            }
            else
            {
                return 1 + ramas(raiz.izq) + ramas(raiz.der);
            }
        }
        #endregion

        #region Aux
        public bool isEmpty()
        {
            return raiz == null;
        }

        public string listarUsuarios(Nodo<T> raiz)
        {
            if (raiz == null)
                return "";
            else
                return raiz.Key + "," + listarUsuarios(raiz.izq) + listarUsuarios(raiz.der);
        }
        #endregion


    }
}