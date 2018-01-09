using WSnaval_wars.Nodos;
using WSnaval_wars.Objetos;
namespace WSnaval_wars.Estructuras
{
    public class MatrizOrtogonal
    {
        public NodoAux<Orto<Unidad>> cabezera_fila;
        public NodoAux<Orto<Unidad>> cabezera_columna;
        private int max_filas=0;
        private int max_columnas=0;
        private int max_unidades = 0;

        #region GyS
        public int Max_filas
        {
            get
            {
                return max_filas;
            }

            set
            {
                max_filas = value;
            }
        }

        public int Max_columnas
        {
            get
            {
                return max_columnas;
            }

            set
            {
                max_columnas = value;
            }
        }

        public int Max_unidades
        {
            get
            {
                return max_unidades;
            }

            set
            {
                max_unidades = value;
            }
        }
        #endregion

        public MatrizOrtogonal()
        {
            cabezera_columna = cabezera_fila = null;
        }

        #region Aux
        public bool areColumnsEmpty()
        {
            return cabezera_columna == null;//ahora las raices cuentan cuantos hijos tienen
        }

        public bool areRowsEmpty()
        {
            return cabezera_fila == null;//ahora las raices cuentan cuantos hijos tienen
        }
        public int columnaAentero(string columna)
        {
            int lenght = columna.Length;
            char[] aux = columna.ToCharArray();
            switch (lenght)
            {
                case 1:
                    return aux[0] - 64;
                case 2:
                    return (aux[0] - 64) * 26 + aux[1] - 64;
                case 3:
                    return (aux[0] - 64) * 26 * 2 + (aux[1] - 64) * 26 + aux[2] - 64;//max 2054
                default:
                    return 0;
            }
        }

        private Orto<Unidad> ordenarNodo(Orto<Unidad> nodo_base)
        {
            Orto<Unidad> aux = nodo_base;
            while (aux.bottom != null)
            {
                aux = aux.bottom;
            }//ahora trabajo con el nodo mas bajo
            //y me voy de regreso para arreglar
            while (aux.top != null)
            {
                if (aux.Item.Nivel_z == 1)//si es un barco, ese se queda como el principal
                    break;
                else if (aux.Item.Nivel_z == 2)
                    break;
                aux = aux.top;
            }//si al final no habia barco, por defecto el nivel de avion, luego el de satelite, si solo hay submarino ese queda
            aux.up = nodo_base.up;
            nodo_base.up.down = aux;
            aux.izq = nodo_base.izq;
            nodo_base.izq.der = aux;
            return aux;
        }
        public bool outOfBounds(string columna_nueva, int fila_nueva)//si el movimiento se sale del tablero
        {
            int col_nueva = columnaAentero(columna_nueva);
            return col_nueva > max_columnas || fila_nueva > max_filas;
        }
        #endregion

        #region Add Columna
        private void addColumn(string key_)
        {
            if (areColumnsEmpty())
            {
                cabezera_columna = new NodoAux<Orto<Unidad>>(new Orto<Unidad>());//lo hago vacio porque los nodos columnas tienen un ortogonal de raiz que solo apunta a los verdaderos nodos, pero el no lleva nada dentro
                cabezera_columna.Key_ = key_;//le agrego el titulo a la nueva columna
            }
            else
            {
                if (key_.CompareTo(cabezera_columna.Key_) < 0)
                {
                    cabezera_columna.anterior = new NodoAux<Orto<Unidad>>(new Orto<Unidad>());//raiz apunta al nuevo, que va antes
                    cabezera_columna.anterior.siguiente = cabezera_columna;//el nuevo apunta a la raiz
                    cabezera_columna = cabezera_columna.anterior;//se actualiza la raiz
                    cabezera_columna.Key_ = key_;
                }
                else
                {
                    addColumn(cabezera_columna, cabezera_columna.siguiente, key_);
                }
            }

        }

        private void addColumn(NodoAux<Orto<Unidad>> actual, NodoAux<Orto<Unidad>> siguiente, string key_)
        {
            if (siguiente == null)
            {
                actual.siguiente = new NodoAux<Orto<Unidad>>(new Orto<Unidad>());
                actual.siguiente.anterior = actual;
                actual.siguiente.Key_ = key_;
            }
            else if (siguiente.Key_.CompareTo(key_) < 0)//el nuevo va mas a la derecha
            {
                addColumn(siguiente, siguiente.siguiente, key_);
            }
            else if (siguiente.Key_.CompareTo(key_) > 0)//el nuevo va despues de actual, pero antes de siguiente
            {
                actual.siguiente = new NodoAux<Orto<Unidad>>(new Orto<Unidad>());//actual apunta al nuevo
                actual.siguiente.anterior = actual;//el nuevo apunta a actual
                actual.siguiente.siguiente = siguiente;//nuevo apunta al siguiente
                siguiente.anterior = actual.siguiente;//siguiente apunta al nuevo
                actual.siguiente.Key_ = key_;//nuevo
            }
            //si el valor es repetido se descarta
        }
        #endregion

        #region Add Fila
        private void addRow(int key)
        {
            if (areRowsEmpty())
            {
                cabezera_fila = new NodoAux<Orto<Unidad>>(new Orto<Unidad>());//lo hago vacio porque los nodos columnas tienen un ortogonal de raiz que solo apunta a los verdaderos nodos, pero el no lleva nada dentro
                cabezera_fila.Key = key;//le agrego el titulo a la nueva columna
            }
            else
            {
                if (key < cabezera_fila.Key)
                {
                    cabezera_fila.anterior = new NodoAux<Orto<Unidad>>(new Orto<Unidad>());//raiz apunta al nuevo, que va antes
                    cabezera_fila.anterior.siguiente = cabezera_fila;//el nuevo apunta a la raiz
                    cabezera_fila = cabezera_fila.anterior;//se actualiza la raiz
                    cabezera_fila.Key = key;

                }
                else
                {
                    addRow(cabezera_fila, cabezera_fila.siguiente, key);
                }
            }

        }

        private void addRow(NodoAux<Orto<Unidad>> actual, NodoAux<Orto<Unidad>> siguiente, int key)
        {
            if (siguiente == null)
            {
                actual.siguiente = new NodoAux<Orto<Unidad>>(new Orto<Unidad>());
                actual.siguiente.anterior = actual;
                actual.siguiente.Key = key;
            }
            else if (siguiente.Key < key)//el nuevo va mas a la derecha
            {
                addRow(siguiente, siguiente.siguiente, key);
            }
            else if (siguiente.Key > key)//el nuevo va despues de actual, pero antes de siguiente
            {
                actual.siguiente = new NodoAux<Orto<Unidad>>(new Orto<Unidad>());//actual apunta al nuevo
                actual.siguiente.Key = key;
                actual.siguiente.anterior = actual;//el nuevo apunta a actual
                actual.siguiente.siguiente = siguiente;//nuevo apunta al siguiente
                siguiente.anterior = actual.siguiente;//siguiente apunta al nuevo
            }
            //si el valor es repetido se descarta
        }
        #endregion

        #region Aux Buscar
        private NodoAux<Orto<Unidad>> buscarCol(string columna)
        {
            NodoAux<Orto<Unidad>> aux = cabezera_columna;
            while (aux != null)
            {
                if (aux.Key_.Equals(columna))
                    break;
                else if (aux.Key_.CompareTo(columna) > 0)//ya se paso
                    return null;
                aux = aux.siguiente;
            }
            return aux;
        }
        public NodoAux<Orto<Unidad>> buscarRow(int fila)
        {
            NodoAux<Orto<Unidad>> aux = cabezera_fila;
            while (aux != null)
            {
                if (aux.Key == fila)
                    break;
                else if (aux.Key > fila)//ya se paso
                    return null;
                aux = aux.siguiente;
            }
            return aux;
        }
        private Orto<Unidad> buscarZ(int z, Orto<Unidad> raiz)
        {
            Orto<Unidad> aux = raiz;
            while (aux.bottom != null)
            {
                aux = aux.bottom;
            }
            while (aux != null)
            {
                if (aux.Item.Nivel_z == z)
                    break;
                aux = aux.top;
            }
            if (aux == null)
                return null;
            if (aux.Item.Nivel_z == z)
                return aux;
            return null;//si no lo encuentra
        }

        private Orto<Unidad> buscarNodoUnidad(Orto<Unidad> actual, Orto<Unidad> siguiente, int fila, string columna)
        {
            if (actual == null)//si llegue al final sin encotrarlo
            {
                return null;
            }
            else if (actual.Item.Col_x.CompareTo(columna) < 0)//si el valor en el que voy es menor que el que me piden
            {
                if (siguiente == null)
                    return null;
                return buscarNodoUnidad(siguiente, siguiente.der, fila, columna);//sigo buscando
            }
            else if (actual.Item.Col_x.Equals(columna))//si es igual
            {
                return actual;//lo retorno
            }
            else//si es mayor, ya me pase, no existe
            {
                return null;//retorno null
            }
            //return null;
        }

        #endregion

        #region Insertar
        private void insertarEnFila(Orto<Unidad> actual, Orto<Unidad> der, Orto<Unidad> nuevo)
        {
        if (der == null)
            {
                actual.der = nuevo;
                nuevo.izq = actual;
            }
            else if (nuevo.Item.Fila_y < der.Item.Fila_y)//va izq de der y der de actual
            {
                actual.der = nuevo;//actual apunta a nuevo
                nuevo.izq = actual;//nuevo apunta a actual
                nuevo.der = der;//nuevo apunta a down
                der.izq = nuevo;//down apunta a nuevo
            }
            else if (nuevo.Item.Fila_y > der.Item.Fila_y)
            {
                insertarEnFila(der, der.der, nuevo);
            }
            else
            {
                if (nuevo.Item.Col_x.CompareTo(der.Item.Col_x) < 0)
                {
                    actual.der = nuevo;//actual apunta a nuevo
                    nuevo.izq = actual;//nuevo apunta a actual
                    nuevo.der = der;//nuevo apunta a down
                    der.izq = nuevo;//down apunta a nuevo
                }
                else if (nuevo.Item.Col_x.CompareTo(der.Item.Col_x) > 0)
                {
                    insertarEnFila(der, der.der, nuevo);
                }
                else
                {
                    //insertar columna se encarga de Z
                }
            }

        }

        private Orto<Unidad> insertarEnColumna(Orto<Unidad> actual, Orto<Unidad> down, Unidad item, int fila, string columna)
        {
            if (down == null)
            {
                actual.down = new Orto<Unidad>(item);
                actual.down.up = actual;
                return actual.down;
            }
            else if (columna.CompareTo(down.Item.Col_x) < 0)//va arriba de down y abajo de actual
            {
                actual.down = new Orto<Unidad>(item);//actual apunta a nuevo
                actual.down.up = actual;//nuevo apunta a actual
                actual.down.down = down;//nuevo apunta a down
                down.up = actual.down;//down apunta a nuevo
                return actual.down;
            }
            else if (columna.CompareTo(down.Item.Col_x) > 0)
            {
                return insertarEnColumna(down, down.down, item, fila, columna);//sigo buscando donde va
            }
            else
            {
                if (fila < down.Item.Fila_y)
                {
                    actual.down = new Orto<Unidad>(item);//actual apunta a nuevo
                    actual.down.up = actual;//nuevo apunta a actual
                    actual.down.down = down;//nuevo apunta a down
                    down.up = actual.down;//down apunta a nuevo
                    return actual.down;
                }
                else if (fila > down.Item.Fila_y)
                {
                    return insertarEnColumna(down, down.down, item, fila, columna);//sigo buscando donde
                }
                else//codigo para insertar en diferente nivel
                {
                    if (down.Item.Nivel_z > item.Nivel_z)//si el que esta actualmente en el nodo, va arriba del nuevo
                    {
                        down.bottom = new Orto<Unidad>(item);
                        down.bottom.top = down;
                        return ordenarNodo(down);

                    }
                    else if (down.Item.Nivel_z < item.Nivel_z)//el que esta actualmente en el nodo, va debajo del nuevo
                    {
                        down.top = new Orto<Unidad>(item);
                        down.top.bottom = down;
                        return ordenarNodo(down);
                    }
                    else
                    {
                        return null;//el espacio esta ocupado por otra unidad
                    }
                }

            }
        }

        public bool insertar(Unidad item)//insertar principal
        {
            Unidad auxiliar = buscarPorPosicion(item.Fila_y, item.Col_x, item.Nivel_z);
            if (auxiliar != null)//si ya hay algo en ese espacio
                return false;//regreso false y no hago nada mas
            NodoAux<Orto<Unidad>> row = buscarRow(item.Fila_y);
            NodoAux<Orto<Unidad>> col = buscarCol(item.Col_x);
            if (row == null)
            {
                addRow(item.Fila_y);
                row = buscarRow(item.Fila_y);//en teoria ya no deberia ser null en este punto
            }
            if (col == null)
            {
                addColumn(item.Col_x);
                col = buscarCol(item.Col_x);//en teoria ya no deberia ser null en este punto
            }
            Orto<Unidad> aux = insertarEnColumna(col.item, col.item.down, item, item.Fila_y, item.Col_x);
            if (aux == null)//el espacio esta ocupado
            {
                return false;//esto ya no deberia ocurrir gracias a la inclusion de buscar, pero de todas formas
            }//en caso de un error podria llegar aqui y es mejor que regrese false a que tire una excepcion
            insertarEnFila(row.item, row.item.der, aux);
            return true;
        }

        #endregion

        #region Buscar
        public Unidad buscarPorPosicion(int fila, string columna, int z)
        {
            NodoAux<Orto<Unidad>> row = buscarRow(fila);
            if (row != null)//si la fila existe es porque mínimo hay un nodo en esa fila
            {
                //NodoO aux = buscarUnidad(row.item, row.item.der, fila, columna);
                Orto<Unidad> aux = buscarNodoUnidad(row.item.der, row.item.der.der, fila, columna);
                if (aux == null)//si no se encontro algo en fila,columna
                    return null;
                aux = buscarZ(z, aux);
                if (aux != null)//si se encontro algo en fila, columna, z
                    return aux.Item;
            }
            return null;//si no encontro el valor
        }

        public Unidad buscarPorNombre(string duenyo, string nombre, bool sacar=false)
        {
            if (areColumnsEmpty() && areRowsEmpty())
                return null;
            NodoAux<Orto<Unidad>> pivote = cabezera_fila;
            Orto<Unidad> actual;
            Unidad encontrado;
            while (pivote != null)//reviso hasta que ya no tenga mas filas
            {
                actual = pivote.Item.der;//el primer item solo es la raiz, el primer nodo es item.der
                while (actual != null)//reviso los nodos en la fila actual
                {
                    encontrado = buscarEnZ(duenyo, nombre, actual,sacar);
                    if (encontrado != null)//si encontre la unidad
                    {
                        return encontrado;
                    }
                    actual = actual.der;
                }
                pivote = pivote.siguiente;
            }
            return null;
        }
        private Unidad buscarEnZ(string duenyo, string nombre_unidad, Orto<Unidad> pivote, bool sacar)
        {
            Orto<Unidad> aux = pivote;
            while (aux.bottom != null)//voy hasta el fondo
            {
                aux = aux.bottom;
            }
            while (aux != null)//y busco hacia arriva
            {
                if (aux.Item.Duenyo.Equals(duenyo) && aux.Item.Nombre.Equals(nombre_unidad))
                {
                    if (!sacar)//si no lo quiero sacar solo muestro el item, sin sacarlo del nodo
                    {
                        return aux.Item;
                    }else
                    {
                        break;
                    }
                }
                    //return aux.Item;
                aux = aux.top;
            }
            if (aux == null)
                return null;
            else//si aux no es null, significa que en este punto yo quiero quitar la unidad de ahi
            {
                Unidad item = aux.Item;//recupero el item
                if (aux.der == null && aux.izq == null && aux.up == null && aux.down == null)//si no es el nodo raiz en Z
                {
                    if (aux.bottom == null)//si es el ultimo de abajo a arriba
                    {
                        //item = aux.Item;
                        aux.top.bottom = null;
                        return item;
                    }else if (aux.top == null)//es el ultimo de arriba a abajo
                    {
                       // item = aux.Item;
                        aux.bottom.top = null;
                        return item;
                    }else//esta en medio
                    {
                        //item = aux.Item;
                        aux.bottom.top = aux.top;//bottom apunta al top de aux
                        aux.top.bottom = aux.bottom;//top apunta al bottom de aux
                        return item;
                    }
                }else if (aux.top != null || aux.bottom != null)//el nodo no queda vacio luego de la extraccion
                {
                    if (aux.top != null)//como prioridad establecemos a top como la nueva raiz en Z
                    {
                        //item = aux.Item;//recupero el item
                        if (aux.top.top == null)//si ya no hay nada mas arriba
                        {
                            aux.Item = aux.top.Item;//muevo el item de arriba hacia aqui, asi no tengo que reacomodar los punteros
                            aux.top = null;//elimino el nodo vacio
                        }else
                        {
                            aux.Item = aux.top.Item;//muevo el item de arriba aqui
                            aux.top.Item = aux.top.top.Item;//muevo el item de arriba arriba aqui
                            aux.top.top = null;//elimino el nodo vacio
                        }
                    }else
                    {
                        //item = aux.Item;//recupero el item
                        if (aux.bottom.bottom == null)//si no hay nada mas abajo
                        {
                            aux.Item = aux.bottom.Item;//muevo el item de abajo aqui
                            aux.bottom = null;//elimino el nodo de abajo
                        }else
                        {
                            aux.Item = aux.bottom.Item;//muevo el item de abajo aqui
                            aux.bottom.Item = aux.bottom.bottom.Item;//muevo el item de abajo abajo aqui
                            aux.bottom.bottom = null;//elimino el nodo vacio
                        }
                    }
                }else//si no queda nada despues de la extraccion
                {
                    if (aux.up.Item == null && aux.down == null)//si la columna queda vacia(aux.up.item==null es porque la raiz siempre tiene item nulo)
                    {
                        eliminarColumna(item.Col_x);//elimino la columna
                    }
                    if (aux.izq.Item == null && aux.der == null)//si la fila queda vacia(aux.izq.item==null es porque la raiz siempre tiene item nulo)
                    {
                        eliminarFila(item.Fila_y);
                    }
                    aux.up.down = aux.down;//recupero los punteros de arriba y abajo
                    if (aux.down != null)
                    {
                        aux.down.up = aux.up;
                    }//termino de recuperar los punteros de arriba y abajo
                    aux.izq.der = aux.der;//recupero los punteros de izq y derecha
                    if (aux.der != null)
                    {
                        aux.der.izq = aux.izq;
                    }//termino de recuperar los punteros de izq y derecha
                }
                return item;
            }
        }
        #endregion

        #region Aux Eliminar
        private void eliminarColumna(string columna)
        {
            NodoAux<Orto<Unidad>> aux = buscarCol(columna);
            if (aux.anterior == null && aux.siguiente == null)//es la unica columna
            {
                cabezera_columna = null;
            }else if (aux.anterior == null)//es la raiz
            {
                aux.siguiente.anterior = null;//elimio el puntero a este
                cabezera_columna = aux.siguiente;//muevo la raiz
            }else if (aux.siguiente == null)//es el ultimio
            {
                aux.anterior.siguiente = null;//simplemente elimino el puntero a este
            }else//esta en medio
            {
                aux.anterior.siguiente = aux.siguiente;//anterior apunta a siguiente de aux
                aux.siguiente.anterior = aux.anterior;//siguiente apunta a anterior de aux
            }
        }
        private void eliminarFila(int fila)
        {
            NodoAux<Orto<Unidad>> aux = buscarRow(fila);
            if (aux.anterior == null && aux.siguiente == null)//es la unica fila
            {
                cabezera_fila = null;
            }
            else if (aux.anterior == null)//es la raiz
            {
                aux.siguiente.anterior = null;//elimio el puntero a este
                cabezera_fila = aux.siguiente;//muevo la raiz
            }
            else if (aux.siguiente == null)//es el ultimio
            {
                aux.anterior.siguiente = null;//simplemente elimino el puntero a este
            }
            else//esta en medio
            {
                aux.anterior.siguiente = aux.siguiente;//anterior apunta a siguiente de aux
                aux.siguiente.anterior = aux.anterior;//siguiente apunta a anterior de aux
            }
        }

        private bool eliminarUnidad(string duenyo, string nombre_unidad)
        {
            return buscarPorNombre(duenyo, nombre_unidad, true) != null;
        }
        #endregion

        #region Mover
        public bool mover(string duenyo, string nombre_unidad, int y, string x)
        {
            Unidad aux = buscarPorNombre(duenyo, nombre_unidad, false);//primero tengo que ver si el movimiento es valido
            if (aux == null)
                return false;
            if (!aux.puedoMover(columnaAentero(x), y))
                return false;
            Unidad posible_ocupante = buscarPorPosicion(y, x, aux.Nivel_z);
            if (posible_ocupante != null)
                return false;
            aux = buscarPorNombre(duenyo, nombre_unidad, true);//ahora que se que el movimiento es valido, saco a la unidad de esa posicion
            if (insertar(aux))
                return true;
            return false;
        }
        #endregion

        #region Atacar
        public bool atacar(string duenyo, string nombre_unidad, int y, string x, int z)
        {
            Unidad aux = buscarPorNombre(duenyo, nombre_unidad, false);
            if (aux == null)//si no existe la unidad con la que quiero atacar
                return false;
            if (!aux.puedoAtacar(columnaAentero(x), y))//si el alcance no entra en el rango
                return false;
            Unidad victima = buscarPorPosicion(y, x, z);
            if (victima == null)//si no hay nada ahi
                return false;
            if (!victima.Vivo)//si hay algo pero ya esta muerto
                return false;
            victima.recibirDanyo(aux.Danyo);//aun si muere, no elimino la unidad del tablero porque esa posicion sirve para los reportes
            return true;
        }
        #endregion

    }
}