#ifndef LISTAC_H
#define LISTAC_H
#include "Nodos/nodo.h"

template <class T, class K>
class ListaC
{
public:
    int count;
    Nodo<T,K> *raiz;
    bool eliminate(K llave);
    bool isEmpty();
    T get(int index=0);
    ListaC();
    bool modify(T item, K llave_nueva, K llave_vieja);
    bool push(T item);
    bool push(T item, K llave);
    Nodo<T,K> *peek(int index=0);
    Nodo<T,K> *search(K llave);
};
#include "listac_def.h"

#endif // LISTAC_H
