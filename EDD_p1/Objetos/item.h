#ifndef ITEM_H
#define ITEM_H
#include "Objetos/producto.h"

class Item
{
public:
    Producto *producto;
    float cantidad;
    float descuento;
    Item();
    Item(Producto *producto, double cantidad, double descuento);
};

#endif // ITEM_H
