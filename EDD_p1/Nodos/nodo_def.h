#include "nodo.h"

template<class T, class K>
Nodo<T,K>::Nodo()
{
    siguiente=anterior=nullptr;
}

template<class T, class K>
Nodo<T,K>::Nodo(T item){
    siguiente=anterior=nullptr;
    this->item=item;
}

template<class T, class K>
Nodo<T,K>::Nodo(T item, K llave)
{
    this->item=item;
    this->llave=llave;
    siguiente=anterior=nullptr;
}
