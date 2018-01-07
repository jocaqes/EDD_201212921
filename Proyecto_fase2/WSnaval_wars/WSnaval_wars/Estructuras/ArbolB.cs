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

        #region insertar 
        public void insertar(Ataque valor)
        {
            if (isEmpty())
            {
                raiz = new NodoB();
                raiz.valores = new Lista<Ataque>();
                raiz.valores.push(valor);
            }
            else
            {
                raiz = insertar(raiz, null, valor);
            }
            count++;
        }
        private NodoB insertar(NodoB raiz, NodoB padre, Ataque valor)
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
                    if (frenoEnQuePaginaInserto(valor, pagina_actual, padre_aux))//si valor es menor que el ultimo valor de la pagina actual
                        break;
                   /* if (valor.Y < pagina_actual.Item.valores.fin.Item.Y || valor.Y < padre_aux.Item.Y)//si valor es menor que el ultimo valor de la pagina actual
                        break;*/
                    if (pagina_actual != null)
                        pagina_actual = pagina_actual.siguiente;
                    padre_aux = padre_aux.siguiente;
                }
                insertar(pagina_actual.Item, raiz, valor);//inserto en la pagina 

            }
            quickSort(raiz.valores, 0, raiz.valores.count - 1);//ordeno los valores
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
                        if (frenoDondeInsertoPagina(izq, aux_pp))
                            break;
                        /*if (izq.valores.fin.Item.Y < aux_pp.Item.valores.raiz.Item.Y)//busco entre que paginas va la nueva pagina
                            break;*/
                        aux_pp = aux_pp.siguiente;
                    }
                    //padre.paginas.push(izq);
                    if (i == 0 && aux_pp == padre.paginas.raiz)//si debe ser la primera pagina
                        padre.paginas.pushTop(izq);
                    else
                        padre.paginas.pushAt(izq, i);//si debe ser posicionado en medio

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
        private void quickSort(Lista<Ataque> lista, int izq, int der)//el codigo de quick sort tomado de una base de internet en c++
        {
            int i = izq;
            int j = der;
            Ataque temp;
            Nodus<Ataque> pivote = lista.pull((izq + der) / 2);
            while (i <= j)
            {
                #region Depende de patron
                switch (patron)
                {
                    case "CoordenadaY":
                        while (lista.pull(i).Item.Y < pivote.Item.Y)
                        {
                            i++;
                        }
                        while (lista.pull(j).Item.Y > pivote.Item.Y)
                        {
                            j--;
                        }
                        break;
                    case "CoordenadaX":
                        while (lista.pull(i).Item.X.CompareTo(pivote.Item.X) < 0) 
                        {
                            i++;
                        }
                        while (lista.pull(j).Item.X.CompareTo(pivote.Item.Y) > 0) 
                        {
                            j--;
                        }
                        break;
                    case "Resultado":
                        while (lista.pull(i).Item.Resultado.CompareTo(pivote.Item.Resultado) < 0)
                        {
                            i++;
                        }
                        while (lista.pull(j).Item.Resultado.CompareTo(pivote.Item.Resultado) > 0)
                        {
                            j--;
                        }
                        break;
                    case "Tipo Unidad":
                        while (lista.pull(i).Item.Tipo_unidad_danyada.CompareTo(pivote.Item.Tipo_unidad_danyada) < 0)
                        {
                            i++;
                        }
                        while (lista.pull(j).Item.Tipo_unidad_danyada.CompareTo(pivote.Item.Tipo_unidad_danyada) > 0)
                        {
                            j--;
                        }
                        break;
                    case "Emisor":
                        while (lista.pull(i).Item.Emisor.CompareTo(pivote.Item.Emisor) < 0)
                        {
                            i++;
                        }
                        while (lista.pull(j).Item.Emisor.CompareTo(pivote.Item.Emisor) > 0)
                        {
                            j--;
                        }
                        break;
                    case "Receptor":
                        while (lista.pull(i).Item.Receptor.CompareTo(pivote.Item.Receptor) < 0)
                        {
                            i++;
                        }
                        while (lista.pull(j).Item.Receptor.CompareTo(pivote.Item.Receptor) > 0)
                        {
                            j--;
                        }
                        break;
                    case "Fecha":
                        while (lista.pull(i).Item.Fecha.CompareTo(pivote.Item.Fecha) < 0)
                        {
                            i++;
                        }
                        while (lista.pull(j).Item.Fecha.CompareTo(pivote.Item.Fecha) > 0)
                        {
                            j--;
                        }
                        break;
                    case "Tiempo Restante":
                        while (lista.pull(i).Item.Tiempo_restante.CompareTo(pivote.Item.Tiempo_restante) < 0)
                        {
                            i++;
                        }
                        while (lista.pull(j).Item.Tiempo_restante.CompareTo(pivote.Item.Tiempo_restante) > 0)
                        {
                            j--;
                        }
                        break;
                    case "No. Ataque":
                        while (lista.pull(i).Item.Numero_ataque < pivote.Item.Numero_ataque) 
                        {
                            i++;
                        }
                        while (lista.pull(j).Item.Numero_ataque < pivote.Item.Numero_ataque) 
                        {
                            j--;
                        }
                        break;
                    case "Unidad Atacante":
                        while (lista.pull(i).Item.Atacante.CompareTo(pivote.Item.Atacante) < 0)
                        {
                            i++;
                        }
                        while (lista.pull(j).Item.Atacante.CompareTo(pivote.Item.Atacante) > 0)
                        {
                            j--;
                        }
                        break;
                }
                #endregion
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
                quickSort(lista, izq, j);
            if (i < der)
                quickSort(lista, i, der);
        }
        
        private bool frenoEnQuePaginaInserto(Ataque item, Nodus<NodoB> pagina, Nodus<Ataque> posicion_en_pagina)
        {

            switch (patron)
            {
                case "CoordenadaY":
                    if (item.Y < pagina.Item.valores.fin.Item.Y || item.Y < posicion_en_pagina.Item.Y)
                        return true;
                    return false;
                case "CoordenadaX":
                    if (item.X.CompareTo(pagina.Item.valores.fin.Item.X) < 0 || item.X.CompareTo(posicion_en_pagina.Item.X) < 0)
                        return true;
                    return false;
                case "Resultado":
                    if (item.Resultado.CompareTo(pagina.Item.valores.fin.Item.Resultado) < 0 || item.Resultado.CompareTo(posicion_en_pagina.Item.Resultado) < 0)
                        return true;
                    return false;
                case "Emisor":
                    if (item.Emisor.CompareTo(pagina.Item.valores.fin.Item.Emisor) < 0 || item.Emisor.CompareTo(posicion_en_pagina.Item.Emisor) < 0)
                        return true;
                    return false;
                case "Receptor":
                    if (item.Receptor.CompareTo(pagina.Item.valores.fin.Item.Receptor) < 0 || item.Receptor.CompareTo(posicion_en_pagina.Item.Receptor) < 0)
                        return true;
                    return false;
                case "Fecha":
                    if (item.Fecha.CompareTo(pagina.Item.valores.fin.Item.Fecha) < 0 || item.Fecha.CompareTo(posicion_en_pagina.Item.Fecha) < 0)
                        return true;
                    return false;
                case "Tiempo Restante":
                    if (item.Tiempo_restante.CompareTo(pagina.Item.valores.fin.Item.Tiempo_restante) < 0 || item.Tiempo_restante.CompareTo(posicion_en_pagina.Item.Tiempo_restante) < 0)
                        return true;
                    return false;
                case "No. Ataque":
                    if (item.Numero_ataque < pagina.Item.valores.fin.Item.Numero_ataque || item.Numero_ataque < posicion_en_pagina.Item.Numero_ataque)
                        return true;
                    return false;
                case "Tipo Unidad":
                    if (item.Tipo_unidad_danyada.CompareTo(pagina.Item.valores.fin.Item.Tipo_unidad_danyada) < 0 || item.Tipo_unidad_danyada.CompareTo(posicion_en_pagina.Item.Tipo_unidad_danyada) < 0)
                        return true;
                    return false;
                case "Unidad Atacante":
                    if (item.Atacante.CompareTo(pagina.Item.valores.fin.Item.Atacante) < 0 || item.Atacante.CompareTo(posicion_en_pagina.Item.Atacante) < 0)
                        return true;
                    return false;
                default:
                    return true;
            }

        }

        private bool frenoDondeInsertoPagina(NodoB a_insertar, Nodus<NodoB> paginas)
        {
            /*if (izq.valores.fin.Item.Y < aux_pp.Item.valores.raiz.Item.Y)
                break;*/
            switch (patron)
            {
                case "CoordenadaY":
                    if (a_insertar.valores.fin.Item.Y < paginas.Item.valores.raiz.Item.Y )
                        return true;
                    return false;
                case "CoordenadaX":
                    if (a_insertar.valores.fin.Item.X.CompareTo(paginas.Item.valores.raiz.Item.X) < 0 )
                        return true;
                    return false;
                case "Resultado":
                    if (a_insertar.valores.fin.Item.Resultado.CompareTo(paginas.Item.valores.raiz.Item.Resultado) < 0)
                        return true;
                    return false;
                case "Emisor":
                    if (a_insertar.valores.fin.Item.Emisor.CompareTo(paginas.Item.valores.raiz.Item.Emisor) < 0 )
                        return true;
                    return false;
                case "Receptor":
                    if (a_insertar.valores.fin.Item.Receptor.CompareTo(paginas.Item.valores.raiz.Item.Receptor) < 0)
                        return true;
                    return false;
                case "Fecha":
                    if (a_insertar.valores.fin.Item.Fecha.CompareTo(paginas.Item.valores.raiz.Item.Fecha) < 0)
                        return true;
                    return false;
                case "Tiempo Restante":
                    if (a_insertar.valores.fin.Item.Tiempo_restante.CompareTo(paginas.Item.valores.raiz.Item.Tiempo_restante) < 0)
                        return true;
                    return false;
                case "No. Ataque":
                    if (a_insertar.valores.fin.Item.Numero_ataque < paginas.Item.valores.raiz.Item.Numero_ataque)
                        return true;
                    return false;
                case "Tipo Unidad":
                    if (a_insertar.valores.fin.Item.Tipo_unidad_danyada.CompareTo(paginas.Item.valores.raiz.Item.Tipo_unidad_danyada) < 0 )
                        return true;
                    return false;
                case "Unidad Atacante":
                    if (a_insertar.valores.fin.Item.Atacante.CompareTo(paginas.Item.valores.raiz.Item.Atacante) < 0)
                        return true;
                    return false;
                default:
                    return true;
            }
        }
        #endregion

    }
}