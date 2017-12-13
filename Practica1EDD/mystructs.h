#ifndef MYSTRUCTS_H
#define MYSTRUCTS_H
//#define k 10 //limite de pasajeros
const int limite_pasajeros=10;

/*Nodo*/
template <class Objeto>
struct Nodo
{
    Nodo();
    Nodo(Objeto item);
    Nodo<Objeto>* anterior;
    Nodo<Objeto>* siguiente;
    Objeto item;
    char llave;//solo se usa para ordenar los escritorios
    void setKey(char llave);
};
/*Nodo*/

/*Pila*/
template<class Objeto>
struct Pila
{
    Pila();
    Nodo<Objeto> *raiz;
    int cant;
    bool isEmpty();
    void push(Objeto item);
    void clear();
    Objeto pop();
};
/*Pila*/


/*Cola*/
template<class Objeto>
struct Cola
{
    Cola();
    Nodo<Objeto> *raiz;
    Nodo<Objeto> *fin;
    int cant;
    bool isEmpty();
    void enColar(Objeto item);
    Objeto desEncolar();
    bool isFull();
};
/*Cola*/


/*Cola doblemente enlazada*/
template<class Objeto>
struct ColaD
{
    ColaD();
    Nodo<Objeto> *raiz;
    Nodo<Objeto> *fin;
    int cant;
    bool isEmpty();
    void enColar(Objeto item);
    Objeto desEncolar();
    Objeto top();

};
/*Cola doblemente enlazada*/


/*Lista*/
template<class Objeto>
struct Lista
{
    Lista();
    Nodo<Objeto> *raiz;
    Nodo<Objeto> *fin;
    int cant;
    void insertar(Objeto item);
    Objeto get(int posicion);
    bool isEmpty();
    void eliminar(int posicion);
};
/*Lista*/

/*Lista doblemente enlazada circular*/
template<class Objeto>
struct ListaDC
{
    ListaDC();
    Nodo<Objeto> *raiz;
    int cant;
    void insertar(Objeto item);
    Objeto get(int posicion);
    bool isEmpty();
    void eliminar(int posicion);
};
/*Lista doblemente enlazada circular*/

/*Lista doblemente enlazada ordenada*/
template<class Objeto>
struct SLista//S de sorted
{
    SLista();
    Nodo<Objeto> *raiz;
    int cant;
    void insertar(Objeto item);
    void insertar(Nodo<Objeto> *actual, Nodo<Objeto> *siguiente, Nodo<Objeto> *nuevo);
    Objeto get(int posicion);
    bool isEmpty();
    //void eliminar(int posicion);
};
/*Lista doblemente enlazada ordenada*/

#include "mystructs_def.h"
#endif // MYSTRUCTS_H
