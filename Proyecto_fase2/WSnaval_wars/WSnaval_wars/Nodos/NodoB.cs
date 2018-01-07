using WSnaval_wars.Estructuras;
using WSnaval_wars.Objetos;
namespace WSnaval_wars.Nodos
{
    public class NodoB
    {
        public Lista<Ataque> valores;
        public Lista<NodoB> paginas;

        public NodoB()
        {
            valores = null;//el null me ayuda a controlar ciertas cosas
            paginas = null;//en lugar de preguntar si estas listas estan vacias, pregunto si son null
        }
    }
}