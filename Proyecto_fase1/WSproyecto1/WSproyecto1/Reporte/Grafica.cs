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
            path = @"C:\Users\Luis Quinonez\Documents\ProgramasJoseTemporal\Imagenes\";//path para guardar las cosas
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

        #region Arbol binario
        private string codigoArbol(ArbolBinario mi_arbol)//funcion para generar el codigo del arbol binario de busqueda
        {
            string salida = "digraph g{\n";
            Nodo aux = mi_arbol.raiz;
            salida += codigoNodos(aux);
            salida += "}";
            return salida;
        }
        private string codigoNodos(Nodo padre)//funcion para generar codigo de nodos de arboles de max dos hijos
        {
            if (padre == null)
                return "";

            Persona actual = padre.Item;
            string nombre = padre.key;
            string codigo = nombre + "[label=\"Nick:\t" + nombre + "\n"
                + "Password:\t" + actual.Password + "\n"
                + "Mail:\t" + actual.Mail +"\n"
                + "Estado:\t"+actual.getConectado().ToString()+"\";shape=box]\n";
            if (padre.izq != null)
                codigo += nombre + ":sw->" + padre.izq.key + "\n";//la sw es para que el hijo quede a la izq del padre, sin importar si padre tine un solo hijo
            if (padre.der != null)
                codigo += nombre + ":se->" + padre.der.key + "\n";//la se es para que el hijo quede a la der del padre, sin importar si padre tine un solo hijo

            codigo += codigoNodos(padre.izq);
            codigo += codigoNodos(padre.der);
            return codigo;

        }

        public bool graficarArbolBinario(ArbolBinario mi_arbol)
        {
            string nombre_dot = "arbolBin.dot";//nombre del dot
            string nombre_png = "arbolBin.png";//nombre de la grafica
            if (guardar(codigoArbol(mi_arbol), path + nombre_dot))//1.guardamos el codigo
            {
                string comando = "dot " + "-Tpng \"" + Path.Combine(path, nombre_dot) + "\" -o \"" + Path.Combine(path, nombre_png) + "\"";
                if (llamarCMD(comando))
                    return true;
            }
            return false;

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