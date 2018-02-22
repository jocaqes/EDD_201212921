#include "manejojson.h"


bool jsonProductos(ListaC<Producto, QString> *productos, QString direccion){
    QFile archivo(direccion);//creo un nuevo qfile
    if(!archivo.open(QIODevice::ReadOnly|QIODevice::Text))
        return false;//si no se abrio
    QByteArray json_codigo = archivo.readAll();
    archivo.close();
    if(json_codigo.isEmpty())
        return false;//si no habia nada en el archivo
    QJsonDocument json_documento = QJsonDocument::fromJson(json_codigo);
    if(!json_documento.isArray())
        return false;//si no tiene el formato [{objeto},{objeto}...]
    QJsonArray json_array = json_documento.array();
    if(json_array.count()<1)
        return false;//si no hay nada en el arreglo
    QJsonObject json_producto;
    foreach (const QJsonValue &valor, json_array) {
        json_producto=valor.toObject();
        productos->push(Producto::Producto(json_producto.value("codigo").toString(),json_producto.value("nombre").toString(),
                                     json_producto.value("precio").toDouble(),json_producto.value("descripcion").toString()),
                                        json_producto.value("codigo").toString());

    }
    return true;

}

bool jsonClientes(Lista<Cliente> *clientes, QString direccion, ListaC<Producto, QString> *circular_productos)
{
    QFile archivo(direccion);
    if(!archivo.open(QIODevice::ReadOnly|QIODevice::Text))
        return false;
    QByteArray json_codigo=archivo.readAll();
    archivo.close();
    if(json_codigo.isEmpty())
        return false;
    QJsonDocument json_documento = QJsonDocument::fromJson(json_codigo);
    if(!json_documento.isArray())
        return false;
    QJsonArray array_clientes = json_documento.array();
    QJsonArray array_facturas;
    QJsonArray array_items;
    if(array_clientes.count()<1)
        return false;
    QJsonObject json_cliente;
    QJsonObject json_factura;
    QJsonObject json_item;
    Cliente *cliente_actual;//debe ser puntero aqui, para que pueda guardar correctamente la referencia de su nit en sus facturas
    Factura factura_actual;
    Item item_actual;
    Nodo<Producto,QString> *aux=nullptr;
    foreach(const QJsonValue &valor_cliente,array_clientes){
        json_cliente=valor_cliente.toObject();//reviso el cliente
        //cliente_actual=Cliente::Cliente(json_cliente.value("NIT").toString(),json_cliente.value("nombre").toString());//agrego sus datos
        cliente_actual=new Cliente(json_cliente.value("NIT").toString(),json_cliente.value("nombre").toString());//agrego sus datos
        if(json_cliente.value("facturas").isArray()){//leo las facturas
            array_facturas=json_cliente.value("facturas").toArray();//hago un nuevo array de facturas
            foreach (const QJsonValue &valor_factura, array_facturas) {
                json_factura=valor_factura.toObject();//reviso la factura
                factura_actual=Factura::Factura(json_factura.value("serie").toString(),json_factura.value("correlativo").toString().toInt(),
                                                json_factura.value("fecha").toString(),&(cliente_actual->nit));//genero una nueva factura
                if(json_factura.value("productos").isArray()){//leo los productos
                    array_items=json_factura.value("productos").toArray();//nuevo array de items
                    foreach (const QJsonValue &valor_item, array_items) {
                        json_item=valor_item.toObject();
                        aux=circular_productos->search(json_item.value("codigo").toString());
                        if(aux!=nullptr){//si encontre el producto
                            item_actual=Item::Item(&(aux->item),json_item.value("cantidad").toDouble(),json_item.value("descuento").toDouble());
                            factura_actual.productos->push(item_actual);
                        }
                    }
                }//termino de llenar la factura actual
                cliente_actual->mis_facturas->push(factura_actual,factura_actual.serie+QString::number(factura_actual.correlativo));//para que vayan ordenadas
            }
        }//termino de llenar las facturas del cliente actual
        clientes->push(*cliente_actual,cliente_actual->nit);
    }
    return true;
}
