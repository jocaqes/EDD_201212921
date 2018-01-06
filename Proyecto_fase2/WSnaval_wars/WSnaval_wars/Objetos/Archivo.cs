using System;
using WSnaval_wars.Estructuras;
namespace WSnaval_wars.Objetos
{
    public class Archivo
    {

        public Archivo() { }

        public bool cargaUsuarios(string direccion, Binario<Persona> arbol_usuarios)//codigo basico para leer un archivo
        {
            bool todo_bien;
            System.IO.StreamReader archivo = new System.IO.StreamReader(direccion);
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
                        actual = new Persona(split[1], split[2]);
                        actual.setConectado(split[3]);
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
    }
}