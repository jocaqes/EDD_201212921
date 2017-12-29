using WSproyecto1.Objetos;
using WSproyecto1.Nodos;

namespace WSproyecto1.Arbol
{
    [System.Serializable]
    public class Matriz
    {
            public Node<NodoO> raiz_col;
            public Node<NodoO> esquina;
            public Node<NodoO> raiz_row;
        private int limite_columnas;
        private int limite_filas;
        private int limite_unidades;

        #region GyS
        public int Limite_columnas
        {
            get
            {
                return limite_columnas;
            }

            set
            {
                limite_columnas = value;
            }
        }

        public int Limite_filas
        {
            get
            {
                return limite_filas;
            }

            set
            {
                limite_filas = value;
            }
        }

        public int Limite_unidades
        {
            get
            {
                return limite_unidades;
            }

            set
            {
                limite_unidades = value;
            }
        }
        #endregion

        public Matriz()
        {
            raiz_col = null;
            raiz_row = null;
            esquina = new Node<NodoO>();
            esquina.siguiente = raiz_col;
            esquina.anterior = raiz_row;//deberia ser abajo pero mucho problema

        }
        public void clearMatriz()
        {
            raiz_col = null;
            raiz_row = null;
            limite_columnas = 0;
            limite_filas = 0;
            limite_unidades = 0;
        }

        public bool areColumnsEmpty()
        {
            return raiz_col == null;//ahora las raices cuentan cuantos hijos tienen
        }

        public bool areRowsEmpty()
        {
            return raiz_row == null;//ahora las raices cuentan cuantos hijos tienen
        }

        #region Add Columna
        private void addColumn(string key_)
        {
            if (areColumnsEmpty())
            {
                raiz_col = new Node<NodoO>(new NodoO());//lo hago vacio porque los nodos columnas tienen un ortogonal de raiz que solo apunta a los verdaderos nodos, pero el no lleva nada dentro
                raiz_col.key_ = key_;//le agrego el titulo a la nueva columna
            }
            else
            {
                if (key_.CompareTo(raiz_col.key_) < 0)
                {
                    raiz_col.anterior = new Node<NodoO>(new NodoO());//raiz apunta al nuevo, que va antes
                    raiz_col.anterior.siguiente = raiz_col;//el nuevo apunta a la raiz
                    raiz_col = raiz_col.anterior;//se actualiza la raiz
                    raiz_col.key_ = key_;
                }
                else
                {
                    addColumn(raiz_col, raiz_col.siguiente, key_);
                }
            }

        }

        private void addColumn(Node<NodoO> actual, Node<NodoO> siguiente, string key_)
        {
            if (siguiente == null)
            {
                actual.siguiente = new Node<NodoO>(new NodoO());
                actual.siguiente.anterior = actual;
                actual.siguiente.key_ = key_;
            }
            else if (siguiente.key_.CompareTo(key_) < 0)//el nuevo va mas a la derecha
            {
                addColumn(siguiente, siguiente.siguiente, key_);
            }
            else if (siguiente.key_.CompareTo(key_) > 0)//el nuevo va despues de actual, pero antes de siguiente
            {
                actual.siguiente = new Node<NodoO>(new NodoO());//actual apunta al nuevo
                actual.siguiente.anterior = actual;//el nuevo apunta a actual
                actual.siguiente.siguiente = siguiente;//nuevo apunta al siguiente
                siguiente.anterior = actual.siguiente;//siguiente apunta al nuevo
                actual.siguiente.key_ = key_;//nuevo
            }
            //si el valor es repetido se descarta
        }
        #endregion

        #region Add Fila
        private void addRow(int key)
        {
            if (areRowsEmpty())
            {
                raiz_row = new Node<NodoO>(new NodoO());//lo hago vacio porque los nodos columnas tienen un ortogonal de raiz que solo apunta a los verdaderos nodos, pero el no lleva nada dentro
                raiz_row.key = key;//le agrego el titulo a la nueva columna
            }
            else
            {
                if (key < raiz_row.key)
                {
                    raiz_row.anterior = new Node<NodoO>(new NodoO());//raiz apunta al nuevo, que va antes
                    raiz_row.anterior.siguiente = raiz_row;//el nuevo apunta a la raiz
                    raiz_row = raiz_row.anterior;//se actualiza la raiz
                    raiz_row.key = key;

                }
                else
                {
                    addRow(raiz_row, raiz_row.siguiente, key);
                }
            }

        }

        private void addRow(Node<NodoO> actual, Node<NodoO> siguiente, int key)
        {
            if (siguiente == null)
            {
                actual.siguiente = new Node<NodoO>(new NodoO());
                actual.siguiente.anterior = actual;
                actual.siguiente.key = key;
            }
            else if (siguiente.key < key)//el nuevo va mas a la derecha
            {
                addRow(siguiente, siguiente.siguiente, key);
            }
            else if (siguiente.key > key)//el nuevo va despues de actual, pero antes de siguiente
            {
                actual.siguiente = new Node<NodoO>(new NodoO());//actual apunta al nuevo
                actual.siguiente.key = key;
                actual.siguiente.anterior = actual;//el nuevo apunta a actual
                actual.siguiente.siguiente = siguiente;//nuevo apunta al siguiente
                siguiente.anterior = actual.siguiente;//siguiente apunta al nuevo
            }
            //si el valor es repetido se descarta
        }
        #endregion

        #region Insertar
        public bool insertar(Unidad item, int fila, string columna)
        {
            Node<NodoO> row = buscarRow(fila);
            Node<NodoO> col = buscarCol(columna);
            if (row == null)
            {
                addRow(fila);
                row = buscarRow(fila);//en teoria ya no deberia ser null en este punto
            }
            if (col == null)
            {
                addColumn(columna);
                col = buscarCol(columna);//en teoria ya no deberia ser null en este punto
            }
            NodoO aux = insertarEnColumna(col.item, col.item.down, item, fila, columna);
            insertarEnFila(row.item, row.item.der, aux);
            if (aux == null)
                return false;
            else
                return true;
        }

        private NodoO insertarEnColumna(NodoO actual, NodoO down, Unidad item, int fila, string columna)
        {
            if (down == null)
            {
                actual.down = new NodoO(item, fila, columna);
                actual.down.up = actual;
                return actual.down;
            }
            else if (columna.CompareTo(down.columna) < 0)//va arriba de down y abajo de actual
            {
                actual.down = new NodoO(item, fila, columna);//actual apunta a nuevo
                actual.down.up = actual;//nuevo apunta a actual
                actual.down.down = down;//nuevo apunta a down
                down.up = actual.down;//down apunta a nuevo
                return actual.down;
            }
            else if (columna.CompareTo(down.columna) > 0)
            {
                return insertarEnColumna(down, down.down, item, fila, columna);
            }
            else
            {
                if (fila < down.fila)
                {
                    actual.down = new NodoO(item, fila, columna);//actual apunta a nuevo
                    actual.down.up = actual;//nuevo apunta a actual
                    actual.down.down = down;//nuevo apunta a down
                    down.up = actual.down;//down apunta a nuevo
                    return actual.down;
                }
                else if (fila > down.fila)
                {
                    return insertarEnColumna(down, down.down, item, fila, columna);
                }
                else//codigo para insertar en diferente nivel
                {
                    if (down.item.Z > item.Z)//si el que esta actualmente en el Node, va arriba del nuevo
                    {
                        down.bottom = new NodoO(item, fila, columna);
                        down.bottom.top = down;
                        return ordenarNodo(down);

                    }
                    else if (down.item.Z < item.Z)//el que esta actualmente en el Node, va debajo del nuevo
                    {
                        down.top = new NodoO(item, fila, columna);
                        down.top.bottom = down;
                        return ordenarNodo(down);
                    }
                    else
                    {
                        return null;
                    }
                }

            }
        }
        private NodoO ordenarNodo(NodoO nodo_base)
        {
            NodoO aux = nodo_base;
            while (aux.bottom != null)
            {
                aux = aux.bottom;
            }//ahora trabajo con el Node mas bajo
             //y me voy de regreso para arreglar
            while (aux.top != null)
            {
                if (aux.item.Z == 1)//si es un barco, ese se queda como el principal
                    break;
                else if (aux.item.Z == 2)
                    break;
                aux = aux.top;
            }//si al final no habia barco, por defecto el nivel de avion, luego el de satelite, si solo hay submarino ese queda
            aux.up = nodo_base.up;
            nodo_base.up.down = aux;
            aux.izq = nodo_base.izq;
            nodo_base.izq.der = aux;
            return aux;
        }

        private void insertarEnFila(NodoO actual, NodoO siguiente, NodoO nuevo)
        {
            if (nuevo == null)
            {
                //significa que la unidad cayo en un espacio repetido, no hago nada
            }
            else if (siguiente == null)
            {
                actual.der = nuevo;
                nuevo.der = actual;
            }
            else if (nuevo.fila < siguiente.fila)//va anterior de siguiente y siguiente de actual
            {
                actual.der = nuevo;//actual apunta a nuevo
                nuevo.izq = actual;//nuevo apunta a actual
                nuevo.der = siguiente;//nuevo apunta a down
                siguiente.der = nuevo;//down apunta a nuevo
            }
            else if (nuevo.fila > siguiente.fila)
            {
                insertarEnFila(siguiente, siguiente.der, nuevo);
            }
            else
            {
                if (nuevo.columna.CompareTo(siguiente.columna) < 0)
                {
                    actual.der = nuevo;//actual apunta a nuevo
                    nuevo.izq = actual;//nuevo apunta a actual
                    nuevo.der = siguiente;//nuevo apunta a down
                    siguiente.izq = nuevo;//down apunta a nuevo
                }
                else if (nuevo.columna.CompareTo(siguiente.columna) > 0)
                {
                    insertarEnFila(siguiente, siguiente.der, nuevo);
                }
                else
                {

                }
            }

        }
        #endregion
        #region Buscar
        private Node<NodoO> buscarCol(string columna)
        {
            Node<NodoO> aux = raiz_col;
            while (aux != null)
            {
                if (aux.key_ == columna)
                    break;
                aux = aux.siguiente;
            }
            return aux;
        }
        private Node<NodoO> buscarRow(int fila)
        {
            Node<NodoO> aux = raiz_row;
            while (aux != null)
            {
                if (aux.key == fila)
                    break;
                aux = aux.siguiente;
            }
            return aux;
        }
        private NodoO buscarZ(int z, NodoO raiz)
        {
            NodoO aux = raiz;
            while (aux.bottom != null)
            {
                aux = aux.bottom;
            }
            while (aux != null)
            {
                if (aux.item.Z == z)
                    break;
                aux = aux.top;
            }
            return aux;
        }

        public Unidad buscarUnidad(int fila, string columna, int z)
        {
            Node<NodoO> row = buscarRow(fila);
            if (row != null)
            {
                return buscarUnidad(row.item, row.item.der, fila, columna);
            }
            return null;
        }
        private Unidad buscarUnidad(NodoO actual, NodoO siguiente, int fila, string columna)
        {
            if (actual == null)
            {
                return null;
            }
            else if (actual.columna.CompareTo(columna) < 0)
            {
                return buscarUnidad(siguiente, siguiente.der, fila, columna);
            }
            else if (actual.columna.Equals(columna))
            {
                return actual.item;
            }
            return null;
        }
        #endregion

        #region Mover
        public void moverUnidad(Unidad unit, int x, int y)
        {

        }
            #endregion
        }
    
}