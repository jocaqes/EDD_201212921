#ifndef NODO_S_H
#define NODO_S_H
#include <QString>

template <class T>
class Nodo_S
{
public:
    T item;
    QString llave;
    Nodo_S<T> *siguiente;
    Nodo_S(T item);
    Nodo_S(T item, QString llave);
    Nodo_S();

};
#include "nodo_s_def.h"

#endif // NODO_S_H
