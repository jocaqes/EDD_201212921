using System.ServiceModel;
using WSproyecto1.Arbol;
using WSproyecto1.Nodos;
using WSproyecto1.Objetos;

namespace WSproyecto1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INavalWarsService" in both code and config file together.
    [ServiceContract]
    public interface INavalWarsService
    {

        [OperationContract]
        Persona newPersona(string password, string mail);

        #region Arbol Binario
        [OperationContract]
        ArbolBinario newArbolBinario();

        [OperationContract]
        bool isEmpty(ArbolBinario arbol_binario);

        [OperationContract]
        ArbolBinario insertar(string nick, Persona persona, ArbolBinario arbol_binario);

        [OperationContract]
        Nodo buscar(string nick, ArbolBinario arbol_binario);

        [OperationContract]
        ArbolBinario eliminar(string nick, ArbolBinario arbol_binario);

        [OperationContract]
        ArbolBinario modificar(string nick, Persona persona, ArbolBinario arbol_binario);
        #endregion

        #region Juego
        [OperationContract]
        Juego newJuego(string usuario, string oponente, int unidades_desplegadas, int sobrevivientes, int destruidos, int gano);

        [OperationContract]
        ArbolBinario agregarJuego(Juego nuevo, string usuario,ArbolBinario arbol_usuarios);//este es una prueba para algo jejeje
        #endregion

        #region Grafica
        [OperationContract]
        bool graficarArbolBinario(ArbolBinario arbol_binario);
        #endregion

        #region CargaMasiva
        [OperationContract]
        ArbolBinario cargaUsuarios(string direccion, ArbolBinario arbol_usuarios);

        [OperationContract]
        ArbolBinario cargaJuegos(string direccion, ArbolBinario arbol_usuarios);
        #endregion


    }
}
