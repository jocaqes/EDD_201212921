#ifndef PRINCIPAL_H
#define PRINCIPAL_H

#include <QMainWindow>
#include <QTableWidgetItem>
#include <QMessageBox>
#include "manejojson.h"
#include "grafica.h"
#include "rendimiento.h"
//#include "Estructuras/listac.h"
//#include "Objetos/producto.h"


namespace Ui {
class Principal;
}

class Principal : public QMainWindow
{
    Q_OBJECT

public:
    explicit Principal(QWidget *parent = 0);
    ~Principal();

private slots:
    void on_boton_cargar_clicked();

    //void on_list_productos_currentItemChanged(QListWidgetItem *current, QListWidgetItem *previous);

    void on_boton_reporte_clicked();

    void on_boton_insertar_clicked();

    void on_boton_buscar_clicked();

    void on_boton_eliminar_clicked();

    void on_boton_reporte_cliente_clicked();

    void on_boton_cargar_clientes_clicked();

    void on_list_productos_currentItemChanged(QTableWidgetItem *current, QTableWidgetItem *previous);

    void on_boton_modificar_clicked();

    void on_boton_insertar_cliente_clicked();

    void on_tabla_admin_clientes_currentItemChanged(QTableWidgetItem *current, QTableWidgetItem *previous);

    void on_boton_modificar_cliente_clicked();

    void on_boton_eliminar_cliente_clicked();

    void on_boton_buscar_cliente_clicked();

    void on_tabla_facturas_cliente_currentItemChanged(QTableWidgetItem *current, QTableWidgetItem *previous);

    void on_boton_eliminar_factura_clicked();

    void on_line_nva_nit_editingFinished();

    void on_boton_push_clicked();

    void on_boton_pop_clicked();

    void on_boton_vaciar_clicked();

    void on_boton_total_clicked();

    void on_boton_guardar_clicked();

    void on_pushButton_clicked();

private:
    ListaC<Producto,QString> *circular_productos;
    Lista<Cliente> *lista_clientes;
    //Factura *factura_actual;
    Ui::Principal *ui;
    QString nit_cliente_elegido;
    QString codigo_producto_elegido;
    Factura *nva_factura;
    /*aux*/
    void instanciarListas();
    bool checkValoresProducto();
    bool checkValoresCliente();
    bool checkValoresNvoProducto();
    void recargarListaProductos();
    void recargarTablaClientes();
    void recargarTablaFacturas(Cliente actual);
    void recargarTablaItems(Factura actual);
    void recargarTablaNvaFactura(Factura actual);
    void recargarTablaRendimiento();
    void addLogMessage(QString mensaje);
    void pruebaRendimiento();
    /*aux*/
    /*Productos*/
    void cargarProductos(QString direccion);
    bool insertarProducto();
    void filtrarProductos(QString patron);
    void eliminarProductos();
    void setTablaProductos();
    void modificarProducto();
    /*Productos*/
    /*Clientes*/
    void cargarClientes(QString direccion);
    bool insertarCliente();
    void eliminarClientes();
    bool modificarCliente();
    bool revisarFacturas(QString codigo_producto);//para ver si un producto se encuentra en tal factura
    void recuperarFacturas(Nodo_S<Cliente> *cliente);
    /*Clientes*/
    /*Factura*/
    void buscarCliente();
    void detalleFactura(QString llave_factura);
    /*Factura*/
    /*Nueva Factura*/
    void iniciarNvaFactura();
    void pushProducto();
    void popProducto();
    /*Nueva Factura*/
    /*Graficas*/
    QString codigoProductos();
    bool graficarProductos();
    QString codigoClientes();
    bool graficarClientes();
    /*Graficas*/
    /*Debug*/
    void setTablaClientes();
    void setTablaFacturas();
    void setTablaItems();//factura
    void setTablaNvaFactura();
    void debugLlenarTabla();
    void setTablaRendimiento();
    void setBotones(bool valor);
    /*Debug*/
};

#endif // PRINCIPAL_H
