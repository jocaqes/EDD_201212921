﻿using System;
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