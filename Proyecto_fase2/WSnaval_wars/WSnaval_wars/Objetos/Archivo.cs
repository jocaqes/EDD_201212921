using System;
using System.IO;
using WSnaval_wars.Estructuras;
namespace WSnaval_wars.Objetos
{
    public class Archivo
    {

        public Archivo() { }

        #region Arbol Binario
        public bool cargaUsuarios(string direccion, Binario<Persona> arbol_usuarios)//codigo basico para leer un archivo
        {
            bool todo_bien;
            StreamReader archivo = new StreamReader(direccion);
            string entrada = "";
            string[] split;
            Persona actual;
            try
            {
                if (archivo.Peek() > -1)
                    entrada = archivo.ReadLine();//me como la primera linea porque por lo visto es una cabezera
                while (archivo.Peek() > -1)
                {
                    entrada = archivo.ReadLine();
                    if (!string.IsNullOrEmpty(entrada))
                    {
                        split = entrada.Split(',');
                        actual = new Persona(split[1], split[2], split[3]);
                        //actual.setConectado(split[3]);
                        arbol_usuarios.insertar(actual, split[0]);
                    }
                }
                todo_bien = true;
            }
            catch (Exception e)
            {
                todo_bien = false;
            }
            archivo.Close();
            return todo_bien;
        }
        #endregion

        #region Arbol B
        public bool cargaHistorial(string direccion, ArbolB arbol_historial)
        {
            bool todo_bien;
            StreamReader archivo = new StreamReader(direccion);
            string entrada = "";
            string[] split;
            //Persona actual;
            Ataque actual;
            try
            {
                if (archivo.Peek() > -1)
                    entrada = archivo.ReadLine();//me como la primera linea porque por lo visto es una cabezera
                while (archivo.Peek() > -1)
                {
                    entrada = archivo.ReadLine();
                    if (!string.IsNullOrEmpty(entrada))
                    {
                        split = entrada.Split(',');
                        //actual = new Persona(split[1], split[2]);
                        bool resultado;
                        if (split[3].Equals("1"))
                        {
                            resultado = true;
                        }else
                        {
                            resultado = false;
                        }
                        actual = new Ataque(split[0],int.Parse(split[1]),split[2],resultado,split[4],split[5],split[6],split[7],int.Parse(split[9]));
                        actual.Fecha = split[8];
                        //actual.setConectado(split[3]);
                        //arbol_avl.insertar(actual, split[0]);
                        arbol_historial.insertar(actual);
                    }
                }
                todo_bien = true;
            }
            catch (Exception e)
            {
                //mensaje_error = e.ToString();
                todo_bien = false;
            }
            archivo.Close();
            return todo_bien;
        }

        #endregion

        #region Lista Doble de Juegos
        public bool cargaJuegos(string direccion,ref Binario<Persona> arbol_usuarios)
        {
            bool todo_bien;
            StreamReader archivo = new StreamReader(direccion);
            string entrada = "";
            string[] split;
            Juego actual;
            try
            {
                if (archivo.Peek() > -1)
                    entrada = archivo.ReadLine();//me como la primera linea porque por lo visto es una cabezera
                Nodos.Nodo<Persona> aux;
                while (archivo.Peek() > -1)
                {
                    entrada = archivo.ReadLine();
                    if (!string.IsNullOrEmpty(entrada))
                    {
                        split = entrada.Split(',');
                        aux = arbol_usuarios.buscar(split[0]);
                        if (aux != null)
                        {
                            actual = new Juego(split[0], split[1], int.Parse(split[2]), int.Parse(split[3]), int.Parse(split[4]), split[5]);
                            aux.Item.juegos.pushTop(actual);
                            //arbol_usuarios.modificar(aux.Item, aux.Key);//nuevo
                        }

                        //actual.setConectado(split[3]);
                        //arbol_usuarios.insertar(actual, split[0]);
                    }
                }
                todo_bien = true;
            }
            catch (Exception e)
            {
                todo_bien = false;
            }
            archivo.Close();
            return todo_bien;
        }
        #endregion
    }
}