#ifndef CLIENTE_H
#define CLIENTE_H
#include <QString>
#include "Estructuras/lista.h"
#include "Objetos/factura.h"

class Cliente
{
public:
    QString nit;
    QString nombre;
    Lista<Factura> *mis_facturas;
    Cliente();
    Cliente(QString nit, QString nombre);
};

#endif // CLIENTE_H
