namespace WSproyecto1.Nodos
{
    [System.Serializable]
    public class NodoO
    {
        static int niveles = 4;
        public NodoO izq, der, up, down, top, bottom;
        public Objetos.Unidad item;
        public int fila;
        public string columna;

        public NodoO()
        {
            item = null;
            izq = der = up = down = top = bottom = null;
            fila = 0;
            columna = "";
        }

        public NodoO(Objetos.Unidad item, int fila, string columna)
        {
            this.item = item;
            izq = der = up = down = top = bottom = null;
            this.fila = fila;
            this.columna = columna;
        }
    }
}