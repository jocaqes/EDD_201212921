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

        #region Arbol Binario
        public Nodo buscar(string nick, ArbolBinario arbol_binario)
        {
            return arbol_binario.buscar(nick);
        }

        public ArbolBinario eliminar(string nick, ArbolBinario arbol_binario)
        {
            arbol_binario.eliminar(nick);
            return arbol_binario;
        }

        public ArbolBinario insertar(string nick, Persona persona, ArbolBinario arbol_binario)
        {
            arbol_binario.insertar(persona, nick);
            return arbol_binario;
        }

        public bool isEmpty(ArbolBinario arbol_binario)
        {
            return arbol_binario.isEmpty();
        }

        public ArbolBinario modificar(string nick, Persona persona, ArbolBinario arbol_binario)
        {
            arbol_binario.modificar(persona, nick);
            return arbol_binario;
        }

        public ArbolBinario newArbolBinario()
        {
            return new ArbolBinario();
        }
        #endregion

        #region Objetos
        public Persona newPersona(string password, string mail)
        {
            return new Persona(password,mail);
        }
        #endregion

        #region Grafica
        public bool graficarArbolBinario(ArbolBinario arbol_binario)
        {
            return new Grafica().graficarArbolBinario(arbol_binario);
        }



        #endregion


        #region CargaMasiva
        public ArbolBinario cargaUsuarios(string direccion, ArbolBinario arbol_usuarios)
        {
            return new Reporte.CargaMasiva().cargaUsuarios(direccion,arbol_usuarios);
        }
        #endregion
    }
}
