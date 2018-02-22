#ifndef FACTURA_H
#define FACTURA_H
#include "Estructuras/pila.h"
#include "item.h"
#include <QString>
#include <QDate>

class Factura
{
public:
    QString serie;
    int correlativo;
    QDate fecha;
    QString *nit;
    Pila<Item> *productos;
    Factura();
    Factura(QString serie, int correlativo, QString fecha, QString *nit);
    float total();
    void cleanProductos();
};

#endif // FACTURA_H
