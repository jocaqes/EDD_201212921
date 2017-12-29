using System;
using System.Diagnostics;
using System.IO;
using WSproyecto1.Arbol;
using WSproyecto1.Nodos;
using WSproyecto1.Objetos;

namespace WSproyecto1.Reporte
{
    public class Grafica
    {
        private string path;
        public Grafica()
        {
            //path = @"C:\Users\Luis Quinonez\Documents\ProgramasJoseTemporal\Imagenes\";//path para guardar las cosas
            path = string.Format(@"{0}Imagen\", AppDomain.CurrentDomain.BaseDirectory);
        }


        private bool guardar(string text, string nombre)//funcion para guardar los archivos
        {
            string ruta_completa = Path.Combine(path, nombre);//path + nombre;
            try
            {
                StreamWriter sw = new StreamWriter(ruta_completa);
                sw.Write(text);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void copiarImagen(string source, string destiny)
        {
            File.Copy(source, destiny,true);
        }

        #region Arbol binario
        private string codigoArbol(ArbolBinario mi_arbol)//funcion para generar el codigo del arbol binario de busqueda
        {
            string salida = "digraph g{\n";
            Nodo aux = mi_arbol.raiz;
            salida += codigoNodos(aux);
            salida += "}";
            return salida;
        }
        private string codigoNodos(Nodo padre, int cont=0)//funcion para generar codigo de nodos de arboles de max dos hijos
        {
            if (padre == null)
                return "";

            Persona actual = padre.Item;
            string nombre = padre.key;
            string codigo = nombre + "[label=\"Nick:\t" + nombre + "\n"
                + "Password:\t" + actual.Password + "\n"
                + "Mail:\t" + actual.Mail +"\n"
                + "Estado:\t"+actual.getConectado().ToString()+"\";shape=box]\n";
            Node<Juego> partidas = actual.mis_partidas.raiz;
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
                    + juego_actual.Sobrevivientes + "\nCaidos:" + juego_actual.Destruidos + "\nGane:"
                    + juego_actual.Gano.ToString() + "\";shape=box];\n";
                if (partidas.anterior != null)
                {
                    codigo += "juego" + cont + "->juego" + (cont - 1)+";\n";
                    codigo += "juego" + (cont - 1) + "->juego" + cont+";\n";
                }
                cont++;
                partidas = partidas.siguiente;
            }
            if (padre.izq != null)
                codigo += nombre + ":sw->" + padre.izq.key + "\n";//la sw es para que el hijo quede a la izq del padre, sin importar si padre tine un solo hijo
            if (padre.der != null)
                codigo += nombre + ":se->" + padre.der.key + "\n";//la se es para que el hijo quede a la der del padre, sin importar si padre tine un solo hijo

            codigo += codigoNodos(padre.izq,cont);
            codigo += codigoNodos(padre.der,cont);
            return codigo;

        }

        public bool graficarArbolBinario(ArbolBinario mi_arbol, string ruta_destino="",string nombre_dot="arbolBin.dot",string nombre_png="arbolBin.png")
        {
           // string nombre_dot = "arbolBin.dot";//nombre del dot
           // string nombre_png = "arbolBin.png";//nombre de la grafica
            string ruta_dot = Path.Combine(path, nombre_dot);
            string ruta_png = Path.Combine(path, nombre_png);
            bool bandera;

            //if (guardar(codigoArbol(mi_arbol), Path.Combine(ruta, nombre_dot)))//1.guardamos el codigo
            if (guardar(codigoArbol(mi_arbol), nombre_dot))//1.guardamos el codigo
            {
                string comando;
                if(!string.IsNullOrEmpty(ruta_destino))
                    comando= "dot " + "-Tpng \"" + ruta_dot + "\" -o \"" + Path.Combine(ruta_destino, nombre_png) + "\"";
                else
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
            if (bandera)
            {
                if (!string.IsNullOrEmpty(ruta_destino))
                {
                    string destino_final = Path.Combine(ruta_destino, nombre_png);
                    if (File.Exists(destino_final))//elimino la imagen anterior
                    {
                        File.Delete(destino_final);
                    }
                    if (File.Exists(ruta_png))
                    {
                        copiarImagen(ruta_png, destino_final);
                    }
                }
            }
            return bandera;
        }
        #endregion

        #region matriz
        private string codigoMatriz(Matriz tablero, int nivel = 1)
        {
            string salida = "digraph g{\n";
            Node<NodoO> fila = tablero.raiz_row;
            Node<NodoO> columna = tablero.raiz_col;
            Node<NodoO> aux = tablero.esquina;
            salida += "{rank=same;\n esquina[color=white,label=\"\"];\n";
            salida += codigoColumna(columna);
            salida += codigoFila(fila);
            salida += codigoNodos(fila, nivel);//aqui veo que nivel quiero graficar
            salida += "}";
            return salida;
        }
        private string codigoColumna(Node<NodoO> columna)
        {
            string salida = "subgraph cluster_columna{\n";
            Node<NodoO> aux = columna;
            while (aux != null)
            {
                salida += "col" + aux.key_ + "[label=\"" + aux.key_ + "\";shape=box;height=.7;width=.7;fixedsize=true];\n";
                if (aux.anterior != null)
                {
                    salida += "col" + aux.key_ + "->col" + aux.anterior.key_ + ";\n";
                    salida += "col" + aux.anterior.key_ + "->col" + aux.key_ + ";\n";
                }
                aux = aux.siguiente;
            }
            if (columna != null)
            {
                salida += "esquina->col" + columna.key_ + "[color=transparent];\n";
            }
            salida += "}\n}\n";
            return salida;
        }
        private string codigoFila(Node<NodoO> fila)
        {
            string salida = "subgraph cluster_fila{\n";
            Node<NodoO> aux = fila;
            while (aux != null)
            {
                salida += "row" + aux.key + "[label=\"" + aux.key + "\";shape=box;height=.7;width=.7;fixedsize=true];\n";
                if (aux.anterior != null)
                {
                    salida += "row" + aux.key + "->row" + aux.anterior.key + ";\n";
                    salida += "row" + aux.anterior.key + "->row" + aux.key + ";\n";
                }
                aux = aux.siguiente;
            }
            if (fila != null)
            {
                salida += "esquina->row" + fila.key + "[color=transparent];\n";
            }
            salida += "}\n";
            return salida;
        }
        private NodoO buscarZ(int z, NodoO raiz)
        {
            if (raiz == null)
                return null;
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
        private string codigoNodos(Node<NodoO> fila, int nivel = 1)
        {
            string salida = "";
            Node<NodoO> aux = fila;
            NodoO actual;
            NodoO actual_Z;
            while (aux != null)
            {
                actual = aux.item;
                actual = actual.der;//el primero es la raiz i ese no tiene nada
                salida += "{rank=same;\n";

                while (actual != null)
                {
                    actual_Z = buscarZ(nivel, actual);//este seria el nodo en el nivel que estoy buscando
                    if (actual_Z != null)//si hay algo en ese nivel
                    {
                        Unidad coso = actual_Z.item;
                        salida += "orto" + actual_Z.fila + "_" + actual_Z.columna
                           + "[label=\"" + coso.Tipo + "\nVida:" + coso.Hp + "\nMov:" + coso.Movimiento
                           + "\nRango:" + coso.Alcance + "\";shape=box;height=.7;width=.7;fixedsize=true;fontsize=8];\n";
                        if (actual.izq.item == null)//apunta a la raiz que esta dentro de la fila, necesito usar a nodo raiz, no a nodo Z
                        {
                            salida += "row" + aux.key + "->orto" + actual_Z.fila + "_" + actual_Z.columna + "[dir=both;weight=0];\n";
                        }
                        if (actual.izq.item != null)//apunta a una unidad
                        {
                            NodoO companyero_izq = buscarZ(nivel, actual.izq);//busco a ver si tiene un compañero
                            if (companyero_izq != null)//el codigo no necesita que lo haga con actual Z o companyero, eso da igual
                            {
                                salida += "orto" + actual.izq.fila + "_" + actual.izq.columna + "->orto" + actual.fila + "_" + actual.columna + "[dir=both;weight=0];\n";
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
                        Unidad coso = actual_Z.item;
                        if (actual.up.item != null)
                        {
                            NodoO companyero_izq = buscarZ(nivel, actual.up);//busco a ver si tiene un compañero
                            salida += "orto" + actual.up.fila + "_" + actual.up.columna + "->orto" + actual.fila + "_" + actual.columna + "[dir=both];\n";
                        }
                        else// (actual.up.item == null)
                            salida += "col" + actual.columna + "->orto" + actual.fila + "_" + actual.columna + "[dir=both];\n";
                    }
                    actual = actual.der;
                }
                salida += "\n";
                aux = aux.siguiente;
            }
            return salida;
        }

        public bool graficarTablero(Matriz tablero,string nombre_dot, string nombre_png , int nivel = 1)
        {
            bool bandera = true;
            string ruta_dot = Path.Combine(path, nombre_dot);
            string ruta_png = Path.Combine(path, nombre_png);
            if (guardar(codigoMatriz(tablero, nivel), nombre_dot))//1.guardamos el codigo
            {
                string comando;
                /*if (!string.IsNullOrEmpty(ruta_destino))
                    comando = "dot " + "-Tpng \"" + ruta_dot + "\" -o \"" + Path.Combine(ruta_destino, nombre_png) + "\"";
                else*/
                    comando = "dot " + "-Tpng \"" + ruta_dot + "\" -o \"" + ruta_png + "\"";
                if (llamarCMD(comando))
                {
                    bandera= true;
                }
                else
                    bandera= false;
            }
           /* if (bandera)
            {
                if (!string.IsNullOrEmpty(ruta_destino))
                {
                    string destino_final = Path.Combine(ruta_destino, nombre_png);
                    if (File.Exists(destino_final))//elimino la imagen anterior
                    {
                        File.Delete(destino_final);
                    }
                    if (File.Exists(ruta_png))
                    {
                        copiarImagen(ruta_png, destino_final);
                    }
                }
            }*/
            return bandera;
        }

        #endregion



        public bool llamarCMD(string comando)//aqui se maneja el cmd
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
                return false;
                //no hago nada porque no tengo ganas de hacer nada
            }
        }

    }
}