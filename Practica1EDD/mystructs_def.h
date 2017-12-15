#include "mystructs.h"


/*Nodo*/
template<class Objeto>
Nodo<Objeto>::Nodo()
{
    siguiente=nullptr;
    anterior=nullptr;
}

template<class Objeto>
Nodo<Objeto>::Nodo(Objeto item)
{
    siguiente=nullptr;
    anterior=nullptr;
    this->item=item;
}

/*Nodo*/




/*Pila*/
template<class Objeto>
Pila<Objeto>::Pila()
{
    raiz=nullptr;
    cant=0;
}

template<class Objeto>
bool Pila<Objeto>::isEmpty()
{
    return raiz==nullptr;
}

template<class Objeto>
void Pila<Objeto>::push(Objeto item)
{
    Nodo<Objeto> *nuevo = new Nodo<Objeto>(item);
    if(isEmpty())
        raiz=nuevo;
    else
    {
        nuevo->siguiente=raiz;
        raiz=nuevo;
    }
    ++cant;
}

template<class Objeto>
void Pila<Objeto>::clear()
{
    while(!isEmpty()){
        Nodo<Objeto> *aux = raiz;
        raiz=raiz->siguiente;
        delete aux;
        --cant;
    }
}

template<class Objeto>
Objeto Pila<Objeto>::pop()
{
    if(isEmpty())
        return 0;
    Nodo<Objeto> *aux = raiz;
    Objeto item = aux->item;
    raiz=raiz->siguiente;
    delete aux;
    --cant;
    return item;
}
/*Pila*/



/*Cola*/
template<class Objeto>
Cola<Objeto>::Cola()
{
    raiz=nullptr;
    fin=nullptr;
    cant=0;
}

template<class Objeto>
bool Cola<Objeto>::isEmpty()
{
    return raiz==nullptr;
}

template<class Objeto>
void Cola<Objeto>::enColar(Objeto item)
{
    Nodo<Objeto> *nuevo = new Nodo<Objeto>(item);
    if(isEmpty()){
        raiz=nuevo;
        fin=raiz;
    }
    else{
        fin->siguiente=nuevo;
        fin=fin->siguiente;
    }
    ++cant;
}

template<class Objeto>
void Cola<Objeto>::clear(){
    while(!isEmpty()){
        Nodo<Objeto> *aux = raiz;
        raiz=raiz->siguiente;
        delete aux;
        --cant;
    }
}

template<class Objeto>
Objeto Cola<Objeto>::desEncolar()
{
    if(isEmpty())
        return 0;
    Nodo<Objeto> *aux=raiz;
    Objeto item = aux->item;
    raiz=raiz->siguiente;
    delete aux;
    --cant;
    return item;
}

template<class Objeto>
bool Cola<Objeto>::isFull()
{
    return cant==limite_pasajeros;
}
/*Cola*/


/*Cola doblemente enlazada*/

template<class Objeto>
ColaD<Objeto>::ColaD()
{
    raiz=nullptr;
    fin=nullptr;
    cant=0;
}

template<class Objeto>
bool ColaD<Objeto>::isEmpty()
{
    return raiz==nullptr;
}

template<class Objeto>
void ColaD<Objeto>::enColar(Objeto item)
{
    Nodo<Objeto> *nuevo = new Nodo<Objeto>(item);
    if(isEmpty()){
        raiz=nuevo;
        fin=raiz;
    }
    else{
        fin->siguiente=nuevo;
        nuevo->anterior=fin;
        fin=fin->siguiente;
    }
    ++cant;
}

template<class Objeto>
void ColaD<Objeto>::clear(){
    while(!isEmpty()){
        Nodo<Objeto> *aux = raiz;
        raiz=raiz->siguiente;
        delete aux;
        --cant;
    }
}

template<class Objeto>
Objeto ColaD<Objeto>::desEncolar()
{
    if(isEmpty())
        return 0;
    Nodo<Objeto> *aux=raiz;
    Objeto item = aux->item;
    raiz=raiz->siguiente;
    if(!isEmpty())//Si la raiz existe
        raiz->anterior=nullptr;//su anterior se hace null; si no verifico entonces da error pues intento llamar el anterior de la raiz que es nula
    delete aux;
    --cant;
    return item;
}

template<class Objeto>
Objeto ColaD<Objeto>::top(){
    if(isEmpty())
        return 0;
    return raiz->item;
}
/*Cola doblemente enlazada*/


/*Lista*/
template<class Objeto>
Lista<Objeto>::Lista()
{
    raiz=nullptr;
    fin=nullptr;
    cant=0;
}

template<class Objeto>
void Lista<Objeto>::insertar(Objeto item)
{
    Nodo<Objeto> *nuevo = new Nodo<Objeto>(item);
    if(isEmpty()){
        raiz=nuevo;
        fin=raiz;
    }
    else{
        fin->siguiente=nuevo;
        fin=fin->siguiente;
    }
    ++cant;
}

template<class Objeto>
void Lista<Objeto>::clear(){
    while(!isEmpty()){
        Nodo<Objeto> *aux = raiz;
        raiz=raiz->siguiente;
        delete aux;
        --cant;
    }
}

template<class Objeto>
Objeto Lista<Objeto>::get(int posicion)
{
    if(posicion>cant||posicion<0)
        return 0;
    Nodo<Objeto> *aux = raiz;
    int i;
    for(i=0;i<posicion;i++){
        aux=aux->siguiente;
    }
    return aux->item;
}

template<class Objeto>
bool Lista<Objeto>::isEmpty()
{
    return raiz==nullptr;
}

template<class Objeto>
void Lista<Objeto>::eliminar(int posicion)
{
    if(posicion>cant||posicion<0)
        return;
    if(posicion==0){//eliminar la raiz
        Nodo<Objeto> *aux=raiz;
        raiz=raiz->siguiente;
        delete aux;
        if(isEmpty())
            fin=nullptr;
        --cant;
        return;
    }
    if(posicion==cant-1){//eliminar el fin
        Nodo<Objeto> *actual=raiz;
        for(int i=1;i<posicion;i++){//comienzo en 1 para hacerlo posicion -1 veces
            actual=actual->siguiente;
        }
        Nodo<Objeto> *aux=fin;
        fin=actual;
        delete aux;
        --cant;
        return;
    }
    Nodo<Objeto> *actual=raiz;
    Nodo<Objeto> *aux=raiz->siguiente;//si llega a este punto ya se reviso que posicion es mayor de 0, en ese caso como minimo hay 2 elementos (0,1)
    int i;
    for(i=1;i<posicion;i++){//ya no reviso el elemento 0
        actual=actual->siguiente;
        aux=aux->siguiente;
    }
    actual->siguiente=aux->siguiente;
    delete aux;
    --cant;
}
/*Lista*/


/*Lista doblemente enlazada circular*/
template<class Objeto>
ListaDC<Objeto>::ListaDC()
{
    raiz=nullptr;
    fin=nullptr;
    cant=0;
}

template<class Objeto>
void ListaDC<Objeto>::insertar(Objeto item)
{
    Nodo<Objeto> *nuevo = new Nodo<Objeto>(item);
    if(isEmpty()){
        raiz=nuevo;
        raiz->siguiente=raiz;
        raiz->anterior=raiz;
    }else{
        Nodo<Objeto> *aux=raiz;
        while(aux->siguiente!=raiz){
            aux=aux->siguiente;
        }
        aux->siguiente=nuevo;
        nuevo->anterior=aux;
        nuevo->siguiente=raiz;
        raiz->anterior=nuevo;
    }
    ++cant;
}

template<class Objeto>
Objeto ListaDC<Objeto>::get(int posicion)
{
    if(posicion>cant||posicion<0)
        return 0;
    Nodo<Objeto> *aux = raiz;
    int i;
    for(i=0;i<posicion;i++){
        aux=aux->siguiente;
    }
    return aux->item;
}

template<class Objeto>
Objeto ListaDC<Objeto>::removeTop(){
    if(isEmpty())
        return 0;
    Nodo<Objeto> *aux=raiz;
    if(raiz->anterior!=raiz){
        raiz->anterior->siguiente=raiz->siguiente;
        raiz->siguiente->anterior=raiz->anterior;
        raiz=aux->siguiente;
        Objeto item=aux->item;
        --cant;
        delete aux;
        return item;
    }else{
        Objeto item=raiz->item;
        delete raiz;
        raiz=nullptr;
        --cant;
        return item;
    }
}

template<class Objeto>
bool ListaDC<Objeto>::isEmpty()
{
    return raiz==nullptr;
}

template<class Objeto>
void ListaDC<Objeto>::eliminar(int posicion)
{

}

/*Lista doblemente enlazada circular*/



