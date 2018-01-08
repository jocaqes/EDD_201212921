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
        public static ArbolB arbol_b = new ArbolB();
        public static int usuarios_conectados = 0;
        public static string usuario_en_turno = "admin";

        #region Binario
        [WebMethod]
        public bool binarioInsertar(string nick, string mail, string password)
        {
            return arbol_binario.insertar(new Persona(password, mail,false), nick);
        }

        [WebMethod]
        public Persona binarioBuscar(string nick)
        {
            Nodo<Persona> aux = arbol_binario.buscar(nick);
            if (aux != null)
                return aux.Item;
            return null;
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
        public bool binarioCargaJuegos(string url)
        {
            return new Archivo().cargaJuegos(url, ref arbol_binario);
        }

        [WebMethod]
        public string listarUsuarios()
        {
            return arbol_binario.listarUsuarios(arbol_binario.raiz);
        }
        #endregion

        #region Arbol B
        [WebMethod]
        public void bSetGrado(int grado)
        {
            arbol_b.Grado = grado;
        }
        [WebMethod]
        public void bSetPatron(string patron)
        {
            arbol_b.Patron = patron;
        }
        [WebMethod]
        public bool bCargaMasiva(string url)
        {
            return new Archivo().cargaHistorial(url, arbol_b);
        }
        #endregion

        #region AVL
        [WebMethod]
        public bool avlInsertar(string nick, string nick_contacto, string mail_contacto)
        {
            //usuario.contactos.insertar(contacto, nick_contacto);//agrego
            Persona yo = binarioBuscar(nick);
            if (yo != null)
            {
                yo.contactos.insertar(new Persona("0000", mail_contacto, false), nick_contacto);
                return arbol_binario.modificar(yo, nick);//modifico el arbol de aqui
            }
            return false;
        }


        #endregion

    }
}
