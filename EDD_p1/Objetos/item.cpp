#include "item.h"

Item::Item()
{
    producto=nullptr;
}

Item::Item(Producto *producto, double cantidad, double descuento)
{
    this->producto=producto;
    this->cantidad=(float)cantidad;
    this->descuento=(float)descuento/100;
}
