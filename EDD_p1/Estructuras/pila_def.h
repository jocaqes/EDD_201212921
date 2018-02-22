#include "pila.h"

template<class T>
void Pila<T>::clean(){
    Nodo_S<T> *aux;
    while(!isEmpty()){
        aux=raiz;
        raiz=raiz->siguiente;
        delete aux;
        --count;
    }
}

template<class T>
bool Pila<T>::isEmpty()
{
    return raiz==nullptr;
}

template<class T>
Pila<T>::Pila()
{
    raiz=nullptr;
    count=0;
}

template<class T>
bool Pila<T>::push(T item)
{
    if(isEmpty())
        raiz=new Nodo_S<T>(item);
    else
    {
        Nodo_S<T> *aux = raiz;
        raiz=new Nodo_S<T>(item);
        raiz->siguiente=aux;
    }
    ++count;
    return true;
}

template<class T>
T Pila<T>::pop()
{
    if(isEmpty()){
        T temp = T();
        return temp;
    }
    Nodo_S<T> *aux = raiz;
    raiz=raiz->siguiente;
    T item = aux->item;
    delete aux;
    --count;
    return item;
}
