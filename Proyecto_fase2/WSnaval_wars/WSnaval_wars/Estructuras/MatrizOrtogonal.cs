using WSnaval_wars.Nodos;
using WSnaval_wars.Objetos;
namespace WSnaval_wars.Estructuras
{
    public class MatrizOrtogonal
    {
        public NodoAux<Orto<Unidad>> cabezera_fila;
        public NodoAux<Orto<Unidad>> cabezera_columna;
        private int max_filas;
        private int max_columnas;

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
            Unidad auxiliar = buscar(item.Fila_y, item.Col_x, item.Nivel_z);
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
        public Unidad buscar(int fila, string columna, int z)
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
        #endregion

    }
}