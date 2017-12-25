using System;
using WSproyecto1.Arbol;

namespace WSproyecto1.Reporte
{
    public class CargaMasiva
    {
        public CargaMasiva() { }

        public ArbolBinario cargaUsuarios(string direccion, ArbolBinario arbol_usuarios)//codigo basico para leer un archivo
        {
            System.IO.StreamReader archivo = new System.IO.StreamReader(direccion);
            string entrada = "";
            string[] split;
            Objetos.Persona actual;
            try
            {
                if (entrada != null)
                    entrada = archivo.ReadLine();//me como la primera linea porque por lo visto es una cabezera
                while (entrada != null)
                {
                    entrada = archivo.ReadLine();
                    split = entrada.Split(',');
                    actual = new Objetos.Persona(split[1], split[2]);
                    actual.setConectado(split[3]);
                    arbol_usuarios.insertar(actual, split[0]);
                    //salida += entrada + "\n";
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                archivo.Close();
            }
            return arbol_usuarios;
        }
    }
}