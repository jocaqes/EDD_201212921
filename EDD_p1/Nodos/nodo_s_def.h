#include "nodo_s.h"

template<class T>
Nodo_S<T>::Nodo_S()
{
    siguiente=nullptr;
}

template<class T>
Nodo_S<T>::Nodo_S(T item)
{
    this->item=item;
    siguiente=nullptr;
}

template<class T>
Nodo_S<T>::Nodo_S(T item, QString llave)
{
    this->item=item;
    this->llave=llave;
    siguiente=nullptr;
}


