#ifndef NODO_H
#define NODO_H

template <class T, class K>
class Nodo
{
public:
    Nodo();
    Nodo(T item, K llave);
    Nodo(T item);
    Nodo<T,K> *anterior;
    Nodo<T,K> *siguiente;
    T item;
    K llave;


};
#include "nodo_def.h"

#endif // NODO_H
