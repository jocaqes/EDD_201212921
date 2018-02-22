#include "factura.h"



Factura::Factura()
{
    productos=new Pila<Item>();
}

Factura::Factura(QString serie, int correlativo, QString fecha, QString *nit)
{
    productos=new Pila<Item>();
    this->serie=serie;
    this->correlativo=correlativo;
    this->fecha=QDate::fromString(fecha,"dd/MM/yyyy");
    this->nit=nit;
}

float Factura::total()
{
    Nodo_S<Item> *aux = productos->raiz;
    float suma=0.00;
    while(aux!=nullptr){
        suma+=aux->item.producto->precio*aux->item.cantidad*aux->item.descuento;
        aux=aux->siguiente;
    }
    return suma;
}

void Factura::cleanProductos()
{
    productos->clean();
}
