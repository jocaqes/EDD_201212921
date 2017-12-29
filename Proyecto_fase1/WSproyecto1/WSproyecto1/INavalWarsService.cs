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
        Nodo logIn(string nick, string password);

        [OperationContract]
        bool eliminar(string nick);

        [OperationContract]
        bool modificar(string nick, Persona persona);

        [OperationContract]
        void cleanBinario();

        [OperationContract]
        int alturaBinario();

        [OperationContract]
        int hojasBinario();

        [OperationContract]
        int ramasBinario();
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
        bool graficarArbolBinarioEspejo(string ruta_destino = "");

        [OperationContract]
        string debug();
        #endregion

        #region CargaMasiva
        [OperationContract]
        bool cargaUsuarios(string direccion);

        [OperationContract]
        bool cargaJuegos(string direccion);
        #endregion

        #region Matriz
        [OperationContract]
        void setParametrosJuego(int filas, int columnas, int unidades);

        [OperationContract]
        void clearMatriz();

        [OperationContract]
        int getNoFilas();

        [OperationContract]
        int getNoColumnas();

        [OperationContract]
        int getNoUnidades();

        [OperationContract]
        int getNoJugador();

        [OperationContract]
        void setNoJugador(int jugador);

        [OperationContract]
        bool insertarUnidad(Unidad item, int fila, string columna);

        [OperationContract]
        Unidad newUnidad(string nombre, string x, int y, string duenyo, int vivo = 1);

        [OperationContract]
        bool graficarTablero(int nivel);
        #endregion
    }
}
