#include "listac.h"
#include <QtDebug>


template<class T, class K>
bool ListaC<T,K>::eliminate(K llave){
    if(isEmpty())
        return false;
    Nodo<T,K> *aux = search(llave);
    if(aux==nullptr)
        return false;
    if(aux==raiz){
        if(count==1){//reviso si es el unico para realmente dejar vacia la lista
            raiz=nullptr;
            --count;
            //delete aux;
            return true;
        }else{
            raiz=raiz->siguiente;
            aux->anterior->siguiente=aux->siguiente;//arreglo los punteros
            aux->siguiente->anterior=aux->anterior;
            --count;
            delete aux;
            return true;
        }
    }
    aux->anterior->siguiente=aux->siguiente;//arreglo los punteros
    aux->siguiente->anterior=aux->anterior;
    --count;
    delete aux;
    return true;

}

template<class T, class K>
bool ListaC<T,K>::isEmpty()
{
    return raiz==nullptr;
}

template<class T, class K>
T ListaC<T,K>::get(int index)
{
    if(isEmpty())
        return 0;
    Nodo<T,K> *aux = raiz;
    T item;
    if(count==1){
        raiz=nullptr;
    }
    else
    {
        Nodo<T,K> *actual=raiz;
        for(int i=1;i<index;i++){//recogo al anterior
            actual=actual->siguiente;
        }
        aux=actual->siguiente;//tomo el aux real
        actual->siguiente=aux->siguiente;//cambio puntero 1
        aux->siguiente->anterior=actual;//cambio puntero 2
        if(aux==raiz){//arreglo la raiz en caso de ser necesario
            raiz=raiz->siguiente;
        }
    }
    item=aux->item;
    delete aux;
    --count;
    return item;

}

template<class T, class K>
ListaC<T,K>::ListaC()
{
    count=0;
    raiz=nullptr;
}

template<class T, class K>
bool ListaC<T,K>::modify(T item, K llave_nueva, K llave_vieja){
    Nodo<T,K> *aux = search(llave_vieja);
    if(aux!=nullptr){
        if(llave_nueva==llave_vieja){
            aux->item=item;//si no cambio la llave, solo cambiamos el contenido del nodo
        }else{//si cambio la llave
            Nodo<T,K> *aux_2=search(llave_nueva);
            if(aux_2!=nullptr){
                return false;
            }
            eliminate(llave_vieja);//eliminamos el viejo nodo
            push(item,llave_nueva);//agregamos el nuevo nodo
        }
        return true;
    }
    return false;
}

template<class T, class K>
bool ListaC<T,K>::push(T item)
{
    if(isEmpty())
    {
        raiz=new Nodo<T,K>(item);
        raiz->anterior=raiz;
        raiz->siguiente=raiz;
    }
    else
    {//raiz->anterior==fin;raiz->anterior->siguiente==nuevo
        raiz->anterior->siguiente=new Nodo<T,K>(item);//inserto al final
        raiz->anterior->siguiente->anterior=raiz->anterior;
        raiz->anterior->siguiente->siguiente=raiz;
        raiz->anterior=raiz->anterior->siguiente;
    }
    ++count;
    return true;
}


template<class T, class K>
bool ListaC<T,K>::push(T item, K llave){
    if(isEmpty()){
        raiz=new Nodo<T,K>(item,llave);
        raiz->anterior=raiz;
        raiz->siguiente=raiz;
    }else if(llave<raiz->llave){
        Nodo<T,K> *aux = raiz->anterior;
        aux->siguiente=new Nodo<T,K>(item,llave);
        aux->siguiente->anterior=aux;
        raiz->anterior=aux->siguiente;
        aux->siguiente->siguiente=raiz;
        raiz=aux->siguiente;
    }
    else{
        //int contador=1;
        Nodo<T,K> *previous = raiz->anterior;
        Nodo<T,K> *actual=raiz;
        do{
            if(llave==actual->llave){
                return false;
            }
            if(llave<actual->llave){
                if(llave>previous->llave){//aqui iria
                    //contador=-1;
                    break;
                }
            }
            actual=actual->siguiente;
            previous=previous->siguiente;
        }while(actual!=raiz);
        previous->siguiente=new Nodo<T,K>(item,llave);
        previous->siguiente->siguiente=actual;
        actual->anterior=previous->siguiente;
        previous->siguiente->anterior=previous;
    }
    ++count;
    return true;
}


template<class T, class K>
Nodo<T, K> *ListaC<T, K>::peek(int index)
{
    if(isEmpty())
        return nullptr;
    Nodo<T,K> *aux = raiz;
    for(int i=0;i<index;i++)
        aux=aux->siguiente;
    return aux;

}

template<class T, class K>
Nodo<T,K> *ListaC<T,K>::search(K llave){
    if(isEmpty())
        return nullptr;
    int min=0;
    int max=count-1;
    int pivote;
    Nodo<T,K> *aux;
    while(min<max+1){//max+1 para que haga la ultima iteracion
        pivote=(min+max)/2;
        aux=peek(pivote);
        if(aux!=nullptr){
            if(aux->llave==llave){
                return aux;
            }else if(aux->llave<llave){
                min=pivote+1;
            }else{
                max=pivote-1;
            }
        }else{
            min=max+1;//por si acaso
        }
    }
    return nullptr;
}
