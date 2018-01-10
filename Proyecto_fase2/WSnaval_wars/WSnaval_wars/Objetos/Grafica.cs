using System;
using System.Diagnostics;
using System.IO;
using WSnaval_wars.Estructuras;
using WSnaval_wars.Nodos;

namespace WSnaval_wars.Objetos
{
    public static class Grafica
    {

        #region Dots
        private static bool guardarDot(string text, string nombre)//guarda los dots
        {
            string path_principal = string.Format(@"{0}Dots\", AppDomain.CurrentDomain.BaseDirectory);//path donde se instale el coso
            string ruta_completa = Path.Combine(path_principal, nombre);//aqui viene el nombre que le doy al dot
            StreamWriter sw;
            try
            {
                sw = new StreamWriter(ruta_completa);
                sw.Write(text);
                sw.Close();
                return true;
            }catch (Exception e)
            {
                return false;
            }
        }
        #endregion

        #region Codigo Arbol Binario
        private static string codigoArbol(Binario<Persona> mi_arbol)//funcion para generar el codigo del arbol binario de busqueda
        {
            string salida = "digraph g{\n";
            Nodo<Persona> aux = mi_arbol.raiz;
            salida += codigoNodos(aux);
            salida += "}";
            return salida;
        }

        private static string codigoNodos(Nodo<Persona> padre, int cont = 0)//funcion para generar codigo de nodos de arboles de max dos hijos
        {
            if (padre == null)
                return "";

            Persona actual = padre.Item;
            string nombre = padre.Key;
            string codigo = nombre + "[label=\"Nick:\t" + nombre + "\n"
                + "Password:\t" + actual.password + "\n"
                + "Mail:\t" + actual.mail + "\n"
                + "Estado:\t" + actual.Conectado.ToString() + "\";shape=box]\n";
            NodoD<Juego> partidas = actual.juegos.raiz;
            Juego juego_actual;
            //int cont = 0;
            if (partidas != null)
            {
                codigo += nombre + "->juego" + cont + ";\n";
            }
            while (partidas != null)//codigo para las partidas del jugador
            {
                juego_actual = partidas.Item;
                codigo += "juego" + cont + "[label=\"Partida" + cont + "\nOponente:" + juego_actual.Oponente
                    + "\nDesplegados:" + juego_actual.Unidades_desplegadas + "\nSobrevivientes:"
                    + juego_actual.Unidades_sobrevivientes + "\nCaidos:" + juego_actual.Unidades_destruidas_por_mi + "\nGane:"
                    + juego_actual.Gane.ToString() + "\";shape=box];\n";
                if (partidas.anterior != null)
                {
                    codigo += "juego" + cont + "->juego" + (cont - 1) + ";\n";
                    codigo += "juego" + (cont - 1) + "->juego" + cont + ";\n";
                }
                cont++;
                partidas = partidas.siguiente;
            }
            if (padre.izq != null)
                codigo += nombre + ":sw->" + padre.izq.Key + "\n";//la sw es para que el hijo quede a la izq del padre, sin importar si padre tine un solo hijo
            if (padre.der != null)
                codigo += nombre + ":se->" + padre.der.Key + "\n";//la se es para que el hijo quede a la der del padre, sin importar si padre tine un solo hijo

            codigo += codigoNodos(padre.izq, cont);
            codigo += codigoNodos(padre.der, cont);
            return codigo;

        }
        #endregion

        #region Graficar Binario
        public static bool graficarArbolBinario(Binario<Persona> mi_arbol, string ruta_destino, string nombre_dot, string nombre_png)
        {
            string path_principal = string.Format(@"{0}Dots\", AppDomain.CurrentDomain.BaseDirectory);//path donde se instale el coso
            string ruta_dot = Path.Combine(path_principal, nombre_dot);
            string ruta_png = Path.Combine(ruta_destino, nombre_png);
            limpiarFiles(ruta_dot, ruta_png);
            bool bandera;

            if (guardarDot(codigoArbol(mi_arbol), nombre_dot))//1.guardamos el codigo
            {
                string comando;
                comando = "dot " + "-Tpng \"" + ruta_dot + "\" -o \"" + ruta_png + "\"";
                if (llamarCMD(comando))
                {

                    bandera = true;
                }
                else
                    bandera = false;
            }
            else
                bandera = false;
            return bandera;
        }
        #endregion

        #region Codigo Tablero
        #region Tablero Disperso
        private static string codigoDisperso(MatrizOrtogonal tablero, int nivel, bool vivos)
        {
            string salida = "digraph g{\n";
            NodoAux<Orto<Unidad>> fila = tablero.cabezera_fila;
            NodoAux<Orto<Unidad>> columna = tablero.cabezera_columna;
            //Node<NodoO> aux = tablero.esquina;
            salida += "{rank=same;\n esquina[color=white,label=\"\"];\n";
            salida += codigoColumna(columna);
            salida += codigoFila(fila);
            salida += codigoNodos(fila, nivel,vivos);//aqui veo que nivel quiero graficar
            salida += "}";
            return salida;
        }
        private static string codigoColumna(NodoAux<Orto<Unidad>> columna)
        {
            string salida = "subgraph cluster_columna{\n";
            NodoAux<Orto<Unidad>> aux = columna;
            while (aux != null)
            {
                salida += "col" + aux.Key_ + "[label=\"" + aux.Key_ + "\";shape=box;height=.7;width=.7;fixedsize=true];\n";
                if (aux.anterior != null)
                {
                    salida += "col" + aux.Key_ + "->col" + aux.anterior.Key_ + ";\n";
                    salida += "col" + aux.anterior.Key_ + "->col" + aux.Key_ + ";\n";
                }
                aux = aux.siguiente;
            }
            if (columna != null)
            {
                salida += "esquina->col" + columna.Key_ + "[color=transparent];\n";
            }
            salida += "}\n}\n";
            return salida;
        }
        private static string codigoFila(NodoAux<Orto<Unidad>> fila)
        {
            string salida = "subgraph cluster_fila{\n";
            NodoAux<Orto<Unidad>> aux = fila;
            while (aux != null)
            {
                salida += "row" + aux.Key + "[label=\"" + aux.Key + "\";shape=box;height=.7;width=.7;fixedsize=true];\n";
                if (aux.anterior != null)
                {
                    salida += "row" + aux.Key + "->row" + aux.anterior.Key + ";\n";
                    salida += "row" + aux.anterior.Key + "->row" + aux.Key + ";\n";
                }
                aux = aux.siguiente;
            }
            if (fila != null)
            {
                salida += "esquina->row" + fila.Key + "[color=transparent];\n";
            }
            salida += "}\n";
            return salida;
        }
        private static Orto<Unidad> buscarZ(int z, Orto<Unidad> raiz)
        {
            if (raiz == null)
                return null;
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
            return aux;
        }
        private static string codigoNodos(NodoAux<Orto<Unidad>> fila, int nivel,bool vivo)
        {
            string salida = "";
            NodoAux<Orto<Unidad>> aux = fila;
            Orto<Unidad> actual;
            Orto<Unidad> actual_Z;
            while (aux != null)
            {
                actual = aux.item;
                actual = actual.der;//el primero es la raiz y ese no tiene nada
                salida += "{rank=same;\n";

                while (actual != null)
                {
                    actual_Z = buscarZ(nivel, actual);//este seria el nodo en el nivel que estoy buscando
                    if (actual_Z != null&&actual_Z.Item.Vivo==vivo)//si hay algo en ese nivel, y es el estado que quiero
                    {
                        Unidad coso = actual_Z.Item;
                        salida += "orto" + coso.Fila_y + "_" + coso.Col_x
                           + "[label=\"" + coso.Tipo + "\nVida:" + coso.Hp + "\nMov:" + coso.Movimiento
                           + "\nRango:" + coso.Alcance + "\";shape=box;height=.7;width=.7;fixedsize=true;fontsize=8];\n";
                        if (actual.izq.Item == null)//apunta a la raiz que esta dentro de la fila, necesito usar a nodo raiz, no a nodo Z
                        {
                            salida += "row" + aux.Key + "->orto" + coso.Fila_y + "_" + coso.Col_x + "[dir=both;weight=0];\n";
                        }
                        if (actual.izq.Item != null)//apunta a una unidad
                        {
                            Orto<Unidad> companyero_izq = buscarZ(nivel, actual.izq);//busco a ver si tiene un compañero
                            if (companyero_izq != null&&companyero_izq.Item.Vivo==vivo)//el codigo no necesita que lo haga con actual Z o companyero, eso da igual
                            {
                                salida += "orto" + actual.izq.Item.Fila_y + "_" + actual.izq.Item.Col_x + "->orto" + coso.Fila_y + "_" + coso.Col_x + "[dir=both;weight=0];\n";
                            }
                        }
                    }
                    actual = actual.der;
                }
                salida += "}\n";
                actual = aux.item;
                actual = actual.der;//el primero es la raiz y ese no tiene nada
                while (actual != null)//columnas
                {
                    actual_Z = buscarZ(nivel, actual);//para terminar, con las columnas
                    if (actual_Z != null)
                    {
                        Unidad coso = actual_Z.Item;
                        if (actual.up.Item != null)//no es la raiz
                        {
                            Orto<Unidad> companyero_izq = buscarZ(nivel, actual.up);//busco a ver si tiene un compañero
                            salida += "orto" + actual.up.Item.Fila_y + "_" + actual.up.Item.Col_x + "->orto" + actual.Item.Fila_y + "_" + actual.Item.Col_x + "[dir=both];\n";
                        }
                        else// (actual.up.item == null)
                            salida += "col" + actual.Item.Col_x + "->orto" + actual.Item.Fila_y + "_" + actual.Item.Col_x + "[dir=both];\n";
                    }
                    actual = actual.der;
                }
                salida += "\n";
                aux = aux.siguiente;
            }
            return salida;
        }
        #endregion
        #region Tablero Completo
        private static string codigoTableroCompleto(MatrizOrtogonal tablero, int nivel)//siempre muestra solo los vivos, este es solo para clientes
        {
            string salida = "digraph g{\n"
                         + "node[shape=plaintext];\n";
            salida += "matriz[label=<<TABLE border=\"0\" cellspacing=\"0\" cellborder=\"1\">\n";
            NodoAux<Orto<Unidad>> fila = tablero.cabezera_fila;
            char char_1 = (char)65;
            char char_2 = (char)64;
            //char char_3;

            #region Encabezados columnas
            salida += "<TR>";
            salida += "<TD width=\"100\" height=\"100\" fixedsize=\"true\"></TD>\n";//esta es la esquina
            for (int i = 0; i < tablero.Max_columnas; i++)//headers
            {
                if (i < 26)//una letra
                {
                    salida += "<TD width=\"100\" height=\"100\" fixedsize=\"true\">" + char_1 + "</TD>\n";
                    char_1++;
                }
                else if (i >= 26 && i < 702)//dos letras
                {
                    if (char_1 > 90)
                    {
                        char_1 = (char)65;//regresa a ser A
                        char_2++;
                    }
                    salida += "<TD width=\"100\" height=\"100\" fixedsize=\"true\">" + char_2 + char_1 + "</TD>\n";
                    char_1++;
                }//que ganas hacer mas letras
            }
            salida += "</TR>\n";
            #endregion
            #region Filas y todo lo demas
            for (int i = 1; i <= tablero.Max_filas; i++)
            {
                salida += "<TR>\n";
                if (i < 10)
                    salida += "<TD width=\"100\" height=\"100\" fixedsize=\"true\">" + i + "</TD>\n";//cabezera de fila
                else
                    salida += "<TD width=\"100\" height=\"100\" fixedsize=\"true\">" + i + "</TD>\n";//cabezera de fila
                NodoAux<Orto<Unidad>> aux = tablero.buscarRow(i);
                char_1 = (char)65;//reseteamos las columnas
                char_2 = (char)64;//de busqueda
                if (aux != null)//si la fila existe
                {
                    for (int j = 1; j <= tablero.Max_columnas; j++, char_1++)//reviso todos los espacios
                    {
                        if (char_1 > 90)//si me paso de z
                        {
                            char_1 = (char)65;
                            char_2++;//uso otra letra
                        }
                        Unidad actual;//busco a la unidad
                        if (j < 26)
                        {
                            actual = tablero.buscarPorPosicion(i, char_1.ToString(), nivel);
                        }
                        else
                        {
                            string row = char_2.ToString() + char_1.ToString();
                            actual = tablero.buscarPorPosicion(i, row, nivel);
                        }
                        if (actual != null && actual.Vivo==true)//si encuentro algo y esta vivo(no es necesario el true pero por si acaso)
                        {
                            salida += "<TD width=\"100\" height=\"100\" fixedsize=\"true\">" + actual.Nombre + "<br/>HP:" + actual.Hp + "<br/>" + actual.Duenyo + "</TD>\n";//agrego su info
                        }
                        else
                        {
                            salida += "<TD width=\"100\" height=\"100\" fixedsize=\"true\"></TD>\n";
                        }

                    }
                }
                else//si la fila no existe
                {
                    for (int j = 0; j < tablero.Max_columnas; j++)
                    {
                        salida += "<TD width=\"100\" height=\"100\" fixedsize=\"true\"></TD>\n";
                    }
                }
                salida += "</TR>";
            }
            #endregion


            salida += "</TABLE>>];\n"
                + "}";
            return salida;


        }
        #endregion
        #endregion

        #region Graficar Tablero Disperso
        public static bool graficarTableroDisperso(MatrizOrtogonal tablero, string nombre_dot,string ruta_destino, string nombre_png, int nivel, bool vivo=true)
        {
            bool bandera = true;
            string path_principal = string.Format(@"{0}Dots\", AppDomain.CurrentDomain.BaseDirectory);//path donde se instale el coso
            string ruta_dot = Path.Combine(path_principal, nombre_dot);
            string ruta_png = Path.Combine(ruta_destino, nombre_png);
            limpiarFiles(ruta_dot, ruta_png);//nuevo
            if (guardarDot(codigoDisperso(tablero, nivel,vivo), nombre_dot))//1.guardamos el codigo
            {
                string comando;
                comando = "dot " + "-Tpng \"" + ruta_dot + "\" -o \"" + ruta_png + "\"";
                if (llamarCMD(comando))
                {
                    bandera = true;
                }
                else
                    bandera = false;
            }
            return bandera;
        }
        #endregion

        #region Graficar Tablero Completo
        public static bool graficarTableroCompleto(MatrizOrtogonal tablero, string nombre_dot, string ruta_destino, string nombre_png, int nivel)
        {
            bool bandera = true;
            string path_principal = string.Format(@"{0}Dots\", AppDomain.CurrentDomain.BaseDirectory);//path donde se instale el coso
            string ruta_dot = Path.Combine(path_principal, nombre_dot);
            string ruta_png = Path.Combine(ruta_destino, nombre_png);
            limpiarFiles(ruta_dot, ruta_png);//nuevo
            if (guardarDot(codigoTableroCompleto(tablero, nivel), nombre_dot))//1.guardamos el codigo
            {
                string comando;
                comando = "dot " + "-Tpng \"" + ruta_dot + "\" -o \"" + ruta_png + "\"";
                if (llamarCMD(comando))
                {
                    bandera = true;
                }
                else
                    bandera = false;
            }
            return bandera;
        }
        #endregion

        #region CMD
        private static bool llamarCMD(string comando)//aqui se maneja el cmd
        {
            try
            {
                ProcessStartInfo cmd = new ProcessStartInfo("cmd", "/c" + comando);//agrego el comando
                cmd.RedirectStandardOutput = true;
                cmd.UseShellExecute = false;
                cmd.CreateNoWindow = true;
                Process proceso = new Process();
                proceso.StartInfo = cmd;
                proceso.Start();
                return true;
            }
            catch (Exception e)
            {
                return false;//no hago nada porque no tengo ganas
            }
        }
        #endregion

        #region Limpiar
        private static void limpiarFiles(string path_dot, string path_png)
        {
            if (File.Exists(path_dot))
                File.Delete(path_dot);
            if (File.Exists(path_png))
                File.Delete(path_png);
        }
        #endregion
    }
}