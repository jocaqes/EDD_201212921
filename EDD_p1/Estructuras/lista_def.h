#include "lista.h"
#include <QtDebug>

template<class T>
bool Lista<T>::eliminate(QString llave){
    if(isEmpty())
        return false;
    Nodo_S<T> *aux = search(llave);
    Nodo_S<T> *anterior=raiz;
    if(aux==nullptr)
        return false;
    if(aux==raiz){
        if(count==1){
            raiz=nullptr;
            //delete aux;
            --count;
            return true;
        }else{
            raiz=raiz->siguiente;
            delete aux;
            --count;
            return true;
        }
    }
    for(int i=0;i<count;i++){//no me quedo de otra, por ser una lista simple esto
        if(anterior->siguiente->llave==llave)//fue lo mejor que se me ocurrio para
            break;//encontrar el nodo anterior
        anterior=anterior->siguiente;//y reutilizar tanto codigo como fuese posible
    }
    anterior->siguiente=aux->siguiente;//arreglo el puntero
    delete aux;
    --count;
    return true;

}

template<class T>
Nodo_S<T> *Lista<T>::eliminateButCF(QString llave){
    if(count==1)
        return nullptr;
    if(llave=="CF")
        return nullptr;
    Nodo_S<T> *aux = search(llave);
    Nodo_S<T> *anterior=raiz;
    if(aux==nullptr)
        return nullptr;
    if(aux==raiz){
        if(count==1){
            raiz=nullptr;
            //delete aux;
            --count;
            return aux;
        }else{
            raiz=raiz->siguiente;
            //delete aux;
            --count;
            return aux;
        }
    }
    for(int i=0;i<count;i++){//no me quedo de otra, por ser una lista simple esto
        if(anterior->siguiente->llave==llave)//fue lo mejor que se me ocurrio para
            break;//encontrar el nodo anterior
        anterior=anterior->siguiente;//y reutilizar tanto codigo como fuese posible
    }
    anterior->siguiente=aux->siguiente;//arreglo el puntero
    //delete aux;
    --count;
    return aux;
}

template<class T>
bool Lista<T>::isEmpty()
{
    return raiz==nullptr;
}

template<class T>
T Lista<T>::get(int index=-1)
{
    if(isEmpty())//si esta vacio
        return 0;
    if(index>=count)//si se pasa de los limites
        return 0;
    Nodo_S<T> *aux = raiz;
    if(index<0){//quiero el elemento de la cima
        raiz=raiz->siguiente;
    }
    else
    {//quiero un elemento especifico
        if(index==0)
        {//quiero la raiz
            raiz=raiz->siguiente;
        }
        else//cualquier otro elemento
        {
            Nodo_S<T> *anterior=raiz;
            for(int i=1;i<index;i++){//uso i=1 para tomar el nodo anterior al que requiero
                anterior=anterior->siguiente;
            }
            aux=anterior->siguiente;//ahora aux es el nodo en la posicion buscada
            anterior->siguiente=aux->siguiente;//conecto los punteros de anterior con siguiente de aux
            if(index==count-1){//si resulta que quiero el nodo fin
                fin=anterior;//fin es el nodo recuperado "anterior"
            }
        }
    }
    //en este punto ya tengo el aux necesario, hice los arreglos necesarios y puedo proceder a recuperar el item
    T item=aux->item;
    delete aux;
    --count;
    return item;
}

template<class T>
Lista<T>::Lista()
{
    count=0;
    raiz=nullptr;
}

template<class T>
bool Lista<T>::modify(T item, QString llave_nueva, QString llave_vieja){
    Nodo_S<T> *aux = search(llave_vieja);
    if(aux!=nullptr){
        if(llave_nueva==llave_vieja){
            aux->item=item;//si no cambio la llave, solo cambiamos el contenido del nodo
        }else{//si cambio la llave
            Nodo_S<T> *aux_2=search(llave_nueva);
            if(aux_2!=nullptr){
                return false;//si la llave nueva ya existe
            }
            eliminate(llave_vieja);//eliminamos el viejo nodo
            push(item,llave_nueva);//agregamos el nuevo nodo
        }
        return true;
    }
    return false;
}

template<class T>
bool Lista<T>::push(T item)
{
    if(isEmpty())
        raiz=new Nodo_S<T>(item);
    else
    {//push sera siempre al final
        Nodo_S<T> *aux = raiz;
        while(aux->siguiente!=nullptr){
            aux=aux->siguiente;
        }
        aux->siguiente=new Nodo_S<T>(item);
    }
    ++count;
    return true;
}

template<class T>
bool Lista<T>::push(T item, QString llave){
    if(isEmpty()){
        raiz=new Nodo_S<T>(item,llave);
    }else if(llave<raiz->llave){
        Nodo_S<T> *aux = raiz;
        raiz=new Nodo_S<T>(item,llave);
        raiz->siguiente=aux;
    }
    else{
        Nodo_S<T> *actual = raiz;
        Nodo_S<T> *next = raiz->siguiente;
        while(next!=nullptr){
            if(llave==actual->llave){
                return false;
            }
            if(llave<next->llave){
                if(llave>actual->llave){//aqui iria
                    break;
                }
            }
            actual=actual->siguiente;
            next=next->siguiente;
        }
        actual->siguiente=new Nodo_S<T>(item,llave);
        actual->siguiente->siguiente=next;
    }
    ++count;
    return true;
}

template<class T>
Nodo_S<T> *Lista<T>::peek(int index)
{
    if(index<0||index>=count)
        return nullptr;
    Nodo_S<T> *aux = raiz;
    for(int i=0;i<index;i++)
        aux=aux->siguiente;
    return aux;
}

template<class T>
Nodo_S<T> *Lista<T>::search(QString llave){
    if(isEmpty())
        return nullptr;
    int min=0;
    int max=count-1;
    int pivote;
    Nodo_S<T> *aux;
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

