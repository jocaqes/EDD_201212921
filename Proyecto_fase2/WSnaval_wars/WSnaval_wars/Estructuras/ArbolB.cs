using WSnaval_wars.Nodos;
using WSnaval_wars.Objetos;
namespace WSnaval_wars.Estructuras
{
    public class ArbolB
    {
        private int grado;
        public NodoB raiz;
        private int count;
        //private bool par;
        private string patron;


        #region GyS
        public string Patron
        {
            get
            {
                return patron;
            }

            set
            {
                patron = value;
            }
        }

        public int Grado
        {
            get
            {
                return grado;
            }

            set
            {
                grado = value;
            }
        }
        #endregion

        public ArbolB()
        {
            raiz = null;
            count = 0;
            //par = esPar(grado);
        }

        #region Auxiliar
        public bool isEmpty()
        {
            return raiz == null;
        }
        #endregion

        #region Insertar General
        public void insertar(Ataque valor)
        {
            switch (patron)
            {
                case "CoordenadaY":
                    insertarY(valor);
                    break;
                case "CoordenadaX":
                    break;
                case "Unidad Atacante":
                    break;
                case "Resultado":
                    break;
                case "Tipo Unidad":
                    break;
                case "Emisor":
                    break;
                case "Receptor":
                    break;
                case "Fecha":
                    break;
                case "Tiempo Restante":
                    break;
                case "No. Ataque":
                    break;
            }
        }
        #endregion

        #region insertar CoordenaraY
        private void insertarY(Ataque valor)
        {
            if (isEmpty())
            {
                raiz = new NodoB();
                raiz.valores = new Lista<Ataque>();
                raiz.valores.push(valor);
            }
            else
            {
                raiz = insertarY(raiz, null, valor);
            }
            count++;
        }
        private NodoB insertarY(NodoB raiz, NodoB padre, Ataque valor)
        {
            if (raiz.paginas == null)//si no tiene paginas
            {
                raiz.valores.push(valor);//agrego directamente el valor al nodo
            }
            else//si tiene paginas
            {
                Nodus<NodoB> pagina_actual = raiz.paginas.raiz;
                Nodus<Ataque> padre_aux = raiz.valores.raiz;
                while (pagina_actual.siguiente != null)//mientras no sea la ultima pagina
                {
                    if (valor.Y < pagina_actual.Item.valores.fin.Item.Y || valor.Y < padre_aux.Item.Y)//si valor es menor que el ultimo valor de la pagina actual
                        break;
                    if (pagina_actual != null)
                        pagina_actual = pagina_actual.siguiente;
                    padre_aux = padre_aux.siguiente;
                }
                insertarY(pagina_actual.Item, raiz, valor);//inserto en la pagina 

            }
            quickSortY(raiz.valores, 0, raiz.valores.count - 1);//ordeno los valores
            if (raiz.valores.count == grado)//si tengo un numero valores iguales al grado, mientras deberia ser grado -1
            {
                Nodus<Ataque> aux = raiz.valores.pull((grado / 2) - 1, true);//porque -1? para agarrar el nodo izq para subir, sin -1 toma el der pero aun asi seria correcto
                bool derecha = false;//esta bandera me ayuda a saber si se generan 2 paginas, o 1 al dividir
                if (padre == null)//si no hay un nodo superior a este
                {
                    padre = new NodoB();//creo un nuevo padre
                    padre.valores = new Lista<Ataque>();//inicializo su lista de valores
                    padre.paginas = new Lista<NodoB>();//inicializo su lista de paginas 
                    derecha = true;
                }
                padre.valores.push(aux.Item);//ingreso el nuevo valor
                NodoB izq = new NodoB();//hago un nodo b auxilliar
                izq.valores = new Lista<Ataque>();//inicializo su lista de valores
                int i;
                for (i = 1; i < (grado / 2); i++)
                {
                    izq.valores.push(raiz.valores.pop());//agrego los valores al nuevo nodo
                }
                #region Recuperar paginas izq
                if (raiz.paginas != null && raiz.paginas.count > grado)
                {
                    izq.paginas = new Lista<NodoB>();
                    for (i = 0; i < (grado / 2); i++)
                    {
                        izq.paginas.push(raiz.paginas.pop());
                    }
                }
                #endregion

                #region Posicionar Pagina
                if (!derecha)
                {
                    Nodus<NodoB> aux_pp = padre.paginas.raiz;
                    int limite = padre.paginas.count;

                    for (i = 0; i < limite; i++)
                    {
                        if (izq.valores.fin.Item.Y < aux_pp.Item.valores.raiz.Item.Y)
                            break;
                        aux_pp = aux_pp.siguiente;
                    }
                    //padre.paginas.push(izq);
                    if (i == 0 && aux_pp == padre.paginas.raiz)
                        padre.paginas.pushTop(izq);
                    else
                        padre.paginas.pushAt(izq, i);

                }
                #endregion
                else//si padre empezo como null le agrego 2 paginas nuevas, pero si no lo es solo le agrego 1 y la otra solo pierde n valores
                {
                    padre.paginas.push(izq);

                    NodoB der = new NodoB();
                    #region Recuperar paginas
                    if (raiz.paginas != null && izq.paginas != null)
                    {
                        der.paginas = new Lista<NodoB>();
                        while (raiz.paginas.count != 0)
                        {
                            der.paginas.push(raiz.paginas.pop());
                        }
                    }
                    #endregion
                    der.valores = new Lista<Ataque>();
                    while (raiz.valores.count != 0)
                    {
                        der.valores.push(raiz.valores.pop());
                    }
                    padre.paginas.push(der);

                }
            }

            if (padre == null)
                return raiz;
            else
                return padre;
        }
        #endregion

        #region Sorts
        private void quickSortY(Lista<Ataque> lista, int izq, int der)//el codigo de quick sort tomado de una base de internet en c++
        {
            int i = izq;
            int j = der;
            Ataque temp;
            Nodus<Ataque> pivote = lista.pull((izq + der) / 2);
            while (i <= j)
            {
                while (lista.pull(i).Item.Y < pivote.Item.Y)
                {
                    i++;
                }
                while (lista.pull(j).Item.Y > pivote.Item.Y)
                {
                    j--;
                }
                if (i <= j)
                {
                    Nodus<Ataque> en_i = lista.pull(i);
                    Nodus<Ataque> en_j = lista.pull(j);
                    temp = en_i.Item;
                    en_i.Item = en_j.Item;
                    en_j.Item = temp;
                    i++;
                    j--;
                }
            }
            if (izq < i)
                quickSortY(lista, izq, j);
            if (i < der)
                quickSortY(lista, i, der);
        }
        #endregion

    }
}