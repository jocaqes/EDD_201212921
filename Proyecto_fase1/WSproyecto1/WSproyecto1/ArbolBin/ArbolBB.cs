namespace WSproyecto1.ArbolBin
{
    public class ArbolBB
    {
        public int count;
        public Nodo<Persona> raiz;
        public ArbolBB()
        {
            count = 0;
            raiz = null;
        }

        bool isEmpty()
        {
            return raiz == null;
        }

        void insertar(Persona item)
        {
            if (isEmpty())
                raiz = new Nodo<Persona>(item);
            else
                insertar(raiz, item);
            count++;
        }

        Persona buscar(string nick)
        {
            if (isEmpty())
                return null;
            else if (raiz.item.Nick.Equals(nick))
                return raiz.item;
            else
                return buscar(raiz, nick);
        }


        #region privados
        private void insertar(Nodo<Persona> raiz, Persona item)
        {
            if (item.Nick.CompareTo(raiz.item.Nick)<0)//el nick de item va antes que el nick de la raiz, asi que item va a la izq
            {
                if (raiz.izq == null)
                {
                    raiz.izq = new Nodo<Persona>(item);
                }else
                {
                    insertar(raiz.izq, item);
                }

            }else if(item.Nick.CompareTo(raiz.item.Nick)>0){//va despues del nick de la raiz
                if (raiz.der == null)
                {
                    raiz.der = new Nodo<Persona>(item);
                }
                else
                {
                    insertar(raiz.der, item);
                }
            }
            //si es igual no hago nada
        }

        private Persona buscar(Nodo<Persona> raiz, string nick)
        {
            if (raiz == null)
            {
                return null;
            }
            else if (raiz.item.Nick.CompareTo(nick) < 0)//el nick esta a la izq
            {
                return buscar(raiz.izq, nick);
            }
            else if (raiz.item.Nick.CompareTo(nick) > 0)//el nick esta a la der
            {
                return buscar(raiz.der, nick);
            }
            else//es igual
            {
                return raiz.item;
            }
        }
        #endregion privados




    }
}