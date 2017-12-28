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
                }
            }
            catch (Exception e)
            {
                //e.ToString();
            }
            archivo.Close();
            return arbol_usuarios;
        }

        public ArbolBinario cargarJuegos(string direccion, ArbolBinario arbol_usuarios)
        {
            System.IO.StreamReader archivo = new System.IO.StreamReader(direccion);
            string entrada = "";
            string[] split;
            Nodos.Nodo actual=null;
            try
            {              
                if (entrada != null)
                    entrada = archivo.ReadLine();//me como la primera linea porque por lo visto es una cabezera*/
                while (archivo.Peek()>-1)
                {
                    entrada = archivo.ReadLine();
                    if (!string.IsNullOrEmpty(entrada))
                    {
                        split = entrada.Split(',');
                        actual = arbol_usuarios.buscar(split[0]);//busco al usuario
                        if (actual != null)
                        {
                            actual.Item.mis_partidas.insertar(new Objetos.Juego(split[0], split[1], int.Parse(split[2]),
                                 int.Parse(split[3]), int.Parse(split[4]), int.Parse(split[5])));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //e.ToString();
            }
            finally
            {
                archivo.Close();
            }

            return arbol_usuarios;
        }


    }
}