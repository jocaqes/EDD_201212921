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

        #region Arbol Binario
        public Nodo buscar(string nick)
        {
            return arbol_binario.buscar(nick);
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
        #endregion

        #region Objetos
        public Persona newPersona(string password, string mail)
        {
            return new Persona(password,mail);
        }
        #endregion

        #region Grafica
        public bool graficarArbolBinario(string ruta)
        {
            return new Grafica().graficarArbolBinario(arbol_binario,ruta);
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
    }
}
