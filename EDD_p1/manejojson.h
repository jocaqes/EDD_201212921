#ifndef MANEJOJSON_H
#define MANEJOJSON_H
#include <QJsonArray>
#include <QJsonDocument>
#include <QJsonObject>
#include <QFile>
#include "Estructuras/listac.h"
#include "Estructuras/lista.h"
#include "Objetos/producto.h"
#include "Objetos/cliente.h"
#include "Objetos/item.h"


bool jsonProductos(ListaC<Producto,QString> *productos, QString direccion);
bool jsonClientes(Lista<Cliente> *clientes, QString direccion, ListaC<Producto,QString> *circular_productos);








#endif // MANEJOJSON_H
