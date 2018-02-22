#include "producto.h"

Producto::Producto()
{

}

Producto::Producto(QString codigo, QString nombre, double precio, QString descripcion)
{
    this->codigo=codigo;
    this->nombre=nombre;
    this->precio=(float)precio;
    this->descripcion=descripcion;
}
