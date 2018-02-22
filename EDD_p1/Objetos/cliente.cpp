#include "cliente.h"

Cliente::Cliente()
{
    mis_facturas=new Lista<Factura>();
}

Cliente::Cliente(QString nit, QString nombre)
{
    mis_facturas=new Lista<Factura>();
    this->nit=nit;
    this->nombre=nombre;
}
