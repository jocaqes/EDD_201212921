namespace WSproyecto1
{
    public class Nodo<Objeto>
    {
        public Nodo<Objeto> izq;
        public Nodo<Objeto> der;
        public Objeto item;
        public Nodo()
        {
            izq = der = null;
        }
        public Nodo(Objeto item)
        {
            izq = der = null;
            this.item = item;
        }
        
        
    }
}