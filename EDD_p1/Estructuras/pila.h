#ifndef PILA_H
#define PILA_H
#include "Nodos/nodo_s.h"

template <class T>
class Pila
{
public:
    int count;
    Nodo_S<T> *raiz;
    void clean();
    bool isEmpty();
    Pila();
    bool push(T item);
    T pop();
};
#include "pila_def.h"

#endif // PILA_H
