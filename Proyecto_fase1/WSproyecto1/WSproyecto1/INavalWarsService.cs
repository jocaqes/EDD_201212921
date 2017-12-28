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
        /*[OperationContract]
        ArbolBinario newArbolBinario();*/

        /*[OperationContract]
        bool isEmpty(ArbolBinario arbol_binario);*/

        [OperationContract]
        bool insertar(string nick, Persona persona);

        [OperationContract]
        Nodo buscar(string nick);

        [OperationContract]
        bool eliminar(string nick);

        [OperationContract]
        bool modificar(string nick, Persona persona);
        #endregion

        #region Juego
        [OperationContract]
        Juego newJuego(string usuario, string oponente, int unidades_desplegadas, int sobrevivientes, int destruidos, int gano);

        [OperationContract]
        bool agregarJuego(Juego nuevo, string usuario);//este es una prueba para algo jejeje
        #endregion

        #region Grafica
        [OperationContract]
        bool graficarArbolBinario(string ruta_destino="");

        [OperationContract]
        string debug();
        #endregion

        #region CargaMasiva
        [OperationContract]
        bool cargaUsuarios(string direccion);

        [OperationContract]
        bool cargaJuegos(string direccion);
        #endregion


    }
}
