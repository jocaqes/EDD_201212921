#ifndef PRODUCTO_H
#define PRODUCTO_H

#include <qstring.h>
class Producto
{
public:
    QString codigo;
    QString nombre;
    float precio;
    QString descripcion;
    Producto();
    Producto(QString codigo, QString nombre, double precio, QString descripcion);
};

#endif // PRODUCTO_H
