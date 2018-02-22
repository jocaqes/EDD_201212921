#ifndef LISTA_H
#define LISTA_H
#include "Nodos/nodo_s.h"

template <class T>
class Lista
{
public:
    int count;
    Nodo_S<T> *raiz;
    bool eliminate(QString llave);
    Nodo_S<T> *eliminateButCF(QString llave);
    bool isEmpty();
    T get(int index=-1);
    Lista();
    bool modify(T item, QString llave_nueva, QString llave_vieja);
    bool push(T item);
    bool push(T item, QString llave);
    Nodo_S<T> *peek(int index=0);
    Nodo_S<T> *search(QString llave);
};
#include "lista_def.h"

#endif // LISTA_H
