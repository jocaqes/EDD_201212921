using System;
using WSproyecto1.Arbol;
using WSproyecto1.Nodos;
using WSproyecto1.Objetos;
using WSproyecto1.Reporte;

namespace WSproyecto1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NavalWarsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NavalWarsService.svc or NavalWarsService.svc.cs at the Solution Explorer and start debugging.
    public class NavalWarsService : INavalWarsService
    {
        public static ArbolBinario arbol_binario = new ArbolBinario();
        public static Matriz matriz_tablero = new Matriz();
        public static int jugadores_conectados = 0;

        #region Arbol Binario
        public Nodo buscar(string nick)
        {
            return arbol_binario.buscar(nick);
        }

        public Nodo logIn(string nick, string password)
        {
            Nodo aux = arbol_binario.buscar(nick);
            if (aux == null)
                return null;
            else
            {
                if (aux.Item.Password.Equals(password))
                    return aux;
                else
                    return null;
            }
        }

        public bool eliminar(string nick)
        {
            return arbol_binario.eliminar(nick);
        }

        public bool insertar(string nick, Persona persona)
        {
            return arbol_binario.insertar(persona, nick);
        }

       /* public bool isEmpty(ArbolBinario arbol_binario)
        {
            return arbol_binario.isEmpty();
        }*/

        public bool modificar(string nick, Persona persona)
        {
            return arbol_binario.modificar(persona, nick);
        }

      /*  public ArbolBinario newArbolBinario()
        {
            return new ArbolBinario();
        }*/
        public void cleanBinario()
        {
            arbol_binario.clean();
        }

        public int alturaBinario()
        {
            return arbol_binario.altura();
        }

        public int hojasBinario()
        {
            return arbol_binario.hojas();
        }

        public int ramasBinario()
        {
            return arbol_binario.ramas();
        }
        #endregion

        #region Objetos
        public Persona newPersona(string password, string mail)
        {
            return new Persona(password,mail);
        }


        #endregion

        #region Grafica
        public bool graficarArbolBinario(string ruta_destino="")
        {
            return new Grafica().graficarArbolBinario(arbol_binario,ruta_destino);
        }

        public string debug()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public bool graficarArbolBinarioEspejo(string ruta_destino = "")
        {
            return new Grafica().graficarArbolBinario(arbol_binario.espejo(),ruta_destino,"espejo.dot","espejo.png");
        }
        #endregion


        #region CargaMasiva
        public bool cargaUsuarios(string direccion )
        {
            return new CargaMasiva().cargaUsuarios(direccion,arbol_binario);
        }

        public bool cargaJuegos(string direccion)
        {
            return new CargaMasiva().cargarJuegos(direccion, arbol_binario);
        }

        #endregion

        #region Juego
        public Juego newJuego(string usuario, string oponente, int unidades_desplegadas, int sobrevivientes, int destruidos, int gano)
        {
            return new Juego(usuario, oponente, unidades_desplegadas, sobrevivientes, destruidos, gano);
        }

        public bool agregarJuego(Juego nuevo, string usuario)
        {
            Nodo aux = arbol_binario.buscar(usuario);
            if (aux != null)
            {
                aux.Item.mis_partidas.insertar(nuevo);
            }
            return  arbol_binario.modificar(aux.Item, usuario);
        }
        #endregion

        #region Matriz
        public void setParametrosJuego(int fila, int columna, int unidades)
        {
            matriz_tablero.Limite_filas = fila;
            matriz_tablero.Limite_columnas = columna;
            matriz_tablero.Limite_unidades = unidades;
        }
        public void clearMatriz()
        {
            matriz_tablero.clearMatriz();
        }

        public int getNoFilas()
        {
            return matriz_tablero.Limite_filas;
        }

        public int getNoColumnas()
        {
            return matriz_tablero.Limite_columnas;
        }

        public int getNoUnidades()
        {
            return matriz_tablero.Limite_unidades;
        }

        public int getNoJugador()
        {
            return jugadores_conectados;
        }

        public void setNoJugador(int jugador)
        {
            jugadores_conectados++;
        }

        public bool insertarUnidad(Unidad item, int fila, string columna)
        {
            return matriz_tablero.insertar(item,fila,columna);
        }

        public Unidad newUnidad(string nombre, string x, int y, string duenyo, int vivo = 1)
        {
            return new Unidad(nombre, x, y, duenyo, vivo);
        }

        public bool graficarTablero(int nivel)
        {
            bool respuesta = new Grafica().graficarTablero(matriz_tablero, "tablero" + nivel + ".dot", "tablero" + nivel + ".png", nivel);
            return respuesta;
        }





        #endregion
    }
}
