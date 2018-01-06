using System.Web.Services;
using WSnaval_wars.Estructuras;
using WSnaval_wars.Objetos;
using WSnaval_wars.Nodos;

namespace WSnaval_wars
{
    /// <summary>
    /// Summary description for NavalWarsWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NavalWarsWS : WebService
    {


        public static Binario<Persona> arbol_binario = new Binario<Persona>();
        public static AVL<Persona> arbol_avl = new AVL<Persona>();

        #region Binario
        [WebMethod]
        public bool binarioInsertar(string nick, string mail, string password)
        {
            return arbol_binario.insertar(new Persona(password, mail), nick);
        }

        [WebMethod]
        public Nodo<Persona> binarioBuscar(string nick)
        {
            return arbol_binario.buscar(nick);
        }

        [WebMethod]
        public bool binarioModificar(string nick,string mail, string password, bool conectado)
        {
            return arbol_binario.modificar(new Persona(password, mail,conectado), nick);
        }

        [WebMethod]
        public bool binarioEliminar(string nick)
        {
            return arbol_binario.eliminar(nick);
        }

        [WebMethod]
        public bool binarioCargaMasiva(string url)
        {
            return new Archivo().cargaUsuarios(url, arbol_binario);
        }

        [WebMethod]
        public string listarUsuarios()
        {
            return arbol_binario.listarUsuarios(arbol_binario.raiz);
        }
        #endregion

        #region Arbol Avl
        [WebMethod]
        public void avlInsertar(string nick, string mail, string password)
        {
            arbol_avl.insertar(new Persona(password, mail), nick);
        }
        #endregion

    }
}
