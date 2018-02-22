#include "principal.h"
#include "ui_principal.h"
#include <iostream>


Principal::Principal(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::Principal)
{
    ui->setupUi(this);
    nva_factura=new Factura();//es vacia por ahora
    instanciarListas();
    setTablaProductos();
    setTablaClientes();
    setTablaFacturas();
    setTablaNvaFactura();
    setTablaItems();
    setTablaRendimiento();
    setBotones(false);//para que no se puedan hacer operaciones en la pestaña de nueva factura
}

Principal::~Principal()
{
    delete ui;
}


/*aux*/
void Principal::instanciarListas()
{
    circular_productos=new ListaC<Producto,QString>();
    lista_clientes=new Lista<Cliente>();
    lista_clientes->push(Cliente::Cliente("CF","N/A"),"CF");//aqui esta el consumidor final, es el primero en entrar a la lista
}

bool Principal::checkValoresProducto()
{
    if(ui->line_codigo_producto->text().isEmpty()||ui->line_nombre_producto->text().isEmpty()
            ||ui->line_precio_producto->text().isEmpty()||ui->plain_descripcion_producto->toPlainText().isEmpty())
        return true;
    return false;
}

bool Principal::checkValoresCliente()
{
    if(ui->line_nit_cliente->text().isEmpty()||ui->line_nombre_cliente->text().isEmpty())
        return true;
    return false;
}

bool Principal::checkValoresNvoProducto()
{
    if(ui->line_nva_cantidad->text().isEmpty()||ui->line_nva_codigo->text().isEmpty()
            ||ui->line_nva_descuento->text().isEmpty())
        return true;
    return false;
}

void Principal::recargarListaProductos()
{
    ui->list_productos->disconnect();
    ui->list_productos->clearContents();
    ui->list_productos->setRowCount(0);
    if(circular_productos->isEmpty())//en caso de estar vacia no hago nada mas
        return;
    int i=0;
    int limite=circular_productos->count;
    Nodo<Producto,QString> *aux=circular_productos->raiz;
    while(i<limite){
        ui->list_productos->insertRow(i);
        ui->list_productos->setItem(i,0,new QTableWidgetItem(aux->llave));
        ui->list_productos->setItem(i,1,new QTableWidgetItem(aux->item.nombre));
        ui->list_productos->setItem(i,2,new QTableWidgetItem(QString::number(aux->item.precio)));
        aux=aux->siguiente;
        ++i;
    }
    connect(ui->list_productos,SIGNAL(currentItemChanged(QTableWidgetItem*,QTableWidgetItem*)),this,SLOT(on_list_productos_currentItemChanged(QTableWidgetItem*,QTableWidgetItem*)));
}

void Principal::recargarTablaClientes()
{
    ui->tabla_admin_clientes->disconnect();
    ui->tabla_admin_clientes->clearContents();
    ui->tabla_admin_clientes->setRowCount(0);
    if(lista_clientes->isEmpty())
        return;
    int i=0;
    int limite=lista_clientes->count;
    Nodo_S<Cliente> *aux = lista_clientes->raiz;
    while(i<limite){
        ui->tabla_admin_clientes->insertRow(i);
        ui->tabla_admin_clientes->setItem(i,0,new QTableWidgetItem(aux->llave));
        ui->tabla_admin_clientes->setItem(i,1,new QTableWidgetItem(aux->item.nombre));
        aux=aux->siguiente;
        ++i;
    }
    connect(ui->tabla_admin_clientes,SIGNAL(currentItemChanged(QTableWidgetItem*,QTableWidgetItem*)),this,SLOT(on_tabla_admin_clientes_currentItemChanged(QTableWidgetItem*,QTableWidgetItem*)));
}

void Principal::recargarTablaFacturas(Cliente actual)
{
    ui->tabla_facturas_cliente->disconnect();
    ui->tabla_facturas_cliente->clearContents();
    ui->tabla_facturas_cliente->setRowCount(0);
    if(lista_clientes->isEmpty()){
        connect(ui->tabla_facturas_cliente,SIGNAL(currentItemChanged(QTableWidgetItem*,QTableWidgetItem*)),this,SLOT(on_tabla_facturas_cliente_currentItemChanged(QTableWidgetItem*,QTableWidgetItem*)));
        return;
    }
    int i=0;
    int limite=actual.mis_facturas->count;
    Nodo_S<Factura> *aux = actual.mis_facturas->raiz;
    while(i<limite){
        ui->tabla_facturas_cliente->insertRow(i);
        ui->tabla_facturas_cliente->setItem(i,0,new QTableWidgetItem(aux->item.serie));
        ui->tabla_facturas_cliente->setItem(i,1,new QTableWidgetItem(QString::number(aux->item.correlativo)));
        ui->tabla_facturas_cliente->setItem(i,2,new QTableWidgetItem(aux->item.fecha.toString("dd/MM/yyyy")));
        aux=aux->siguiente;
        ++i;
    }
    connect(ui->tabla_facturas_cliente,SIGNAL(currentItemChanged(QTableWidgetItem*,QTableWidgetItem*)),this,SLOT(on_tabla_facturas_cliente_currentItemChanged(QTableWidgetItem*,QTableWidgetItem*)));
}

void Principal::recargarTablaItems(Factura actual)
{
    //ui->tabla_items_factura->disconnect();
    ui->tabla_items_factura->clearContents();
    ui->tabla_items_factura->setRowCount(0);
    if(actual.productos->isEmpty()){
        //|connect(ui->tabla_productos_factura,SIGNAL(currentItemChanged(QTableWidgetItem*,QTableWidgetItem*)),this,SLOT(on_tabla_facturas_cliente_currentItemChanged(QTableWidgetItem*,QTableWidgetItem*)));
        return;
    }
    int i=0;
    Nodo_S<Item> *aux = actual.productos->raiz;
    while(aux!=nullptr){
        ui->tabla_items_factura->insertRow(i);
        ui->tabla_items_factura->setItem(i,0,new QTableWidgetItem(aux->item.producto->codigo));
        ui->tabla_items_factura->setItem(i,1,new QTableWidgetItem(aux->item.producto->descripcion));
        ui->tabla_items_factura->setItem(i,2,new QTableWidgetItem(QString::number(aux->item.producto->precio)));
        ui->tabla_items_factura->setItem(i,3,new QTableWidgetItem(QString::number(aux->item.cantidad)));
        ui->tabla_items_factura->setItem(i,4,new QTableWidgetItem(QString::number(aux->item.descuento)));
        aux=aux->siguiente;
        ++i;
    }
    ui->label_correlativo->setText(QString::number(actual.correlativo));
    ui->label_serie->setText(actual.serie);
    ui->label_nit->setText(*actual.nit);
    ui->label_fecha->setText(actual.fecha.toString("dd/MM/yyyy"));
    ui->label_total->setText(QString::number(actual.total()));
}

void Principal::recargarTablaNvaFactura(Factura actual)
{
    ui->tabla_nueva_factura->clearContents();
    ui->tabla_nueva_factura->setRowCount(0);
    if(actual.productos->isEmpty())
        return;
    int i=0;
    Nodo_S<Item> *aux = actual.productos->raiz;
    while(aux!=nullptr){
        ui->tabla_nueva_factura->insertRow(i);
        ui->tabla_nueva_factura->setItem(i,0,new QTableWidgetItem(aux->item.producto->nombre));
        ui->tabla_nueva_factura->setItem(i,1,new QTableWidgetItem(QString::number(aux->item.cantidad)));
        aux=aux->siguiente;
        ++i;
    }
}

void Principal::recargarTablaRendimiento()
{
    ui->tabla_prueba_rendimiento->clearContents();
    ui->tabla_prueba_rendimiento->setRowCount(0);
    //100 registros
    int registros=100;
    for(int i=0;i<4;i++){
        ui->tabla_prueba_rendimiento->insertRow(i);
        ui->tabla_prueba_rendimiento->setItem(i,0,new QTableWidgetItem(QString::number(registros)+" registros"));
        ui->tabla_prueba_rendimiento->setItem(i,1,new QTableWidgetItem(QString::number(iniciarPrueba(registros,true))+"ms"));
        ui->tabla_prueba_rendimiento->setItem(i,2,new QTableWidgetItem(QString::number(iniciarPrueba(registros,true))+"ms"));
        registros=registros*10;
    }
}

void Principal::addLogMessage(QString mensaje)
{
    QString texto_anterior = ui->plain_log->toPlainText();
    ui->plain_log->setPlainText(texto_anterior+mensaje+"\n");
}

void Principal::pruebaRendimiento()
{
    recargarTablaRendimiento();
}
/*aux*/



/*Productos*/
void Principal::cargarProductos(QString direccion)
{
    if(jsonProductos(circular_productos,direccion))
        recargarListaProductos();

}

bool Principal::insertarProducto()
{
    return circular_productos->push(Producto::Producto(ui->line_codigo_producto->text(),ui->line_nombre_producto->text(),
                                                 ui->line_precio_producto->text().toFloat(),ui->plain_descripcion_producto->toPlainText()),
                                    ui->line_codigo_producto->text());
}

void Principal::filtrarProductos(QString patron)
{
    if(ui->line_buscar_producto->text().isEmpty()){
        recargarListaProductos();
    }else{
        ui->list_productos->disconnect();//desconectamos el slot de la tabla
        ui->list_productos->clearContents();//limpiamos la tabla
        ui->list_productos->setRowCount(0);//reseteamos las filas
        int i=0;
        int row_count=0;
        int limite=circular_productos->count;
        Nodo<Producto,QString> *aux = circular_productos->raiz;
        for(i=0;i<limite;i++){
            if(aux->llave.startsWith(patron)){
                row_count=ui->list_productos->rowCount();
                ui->list_productos->insertRow(row_count);//agregamos la nueva fila
                ui->list_productos->setItem(row_count,0,new QTableWidgetItem(aux->llave));
                ui->list_productos->setItem(row_count,1,new QTableWidgetItem(aux->item.nombre));
                ui->list_productos->setItem(row_count,2,new QTableWidgetItem(QString::number(aux->item.precio)));
                //ui->list_productos->addItem(aux->llave);
            }
            aux=aux->siguiente;
        }
        connect(ui->list_productos,SIGNAL(currentItemChanged(QTableWidgetItem*,QTableWidgetItem*)),this,SLOT(on_list_productos_currentItemChanged(QTableWidgetItem*,QTableWidgetItem*)));//reconectamos la tabla
    }

}

void Principal::eliminarProductos()
{
    ui->list_productos->disconnect();
    int inicio=ui->list_productos->currentIndex().row();
    int fin;
    if(inicio>0){
        if(ui->list_productos->item(inicio-1,0)->isSelected()){//si la seleccion fue de arriba hacia abajo
            fin=inicio+1;
            inicio=inicio-ui->list_productos->selectedItems().count()+1;
        }else{
           fin=ui->list_productos->selectedItems().count()+inicio;
        }
    }else{
        fin=ui->list_productos->selectedItems().count()+inicio;
    }
    QString llave;
    for(int i=inicio;i<fin;i++){
        llave=ui->list_productos->item(inicio,0)->text();
        if(revisarFacturas(llave)){//el producto esta en una factura
            addLogMessage("El producto "+llave+" no se pudo eliminar pues es parte de una factura");
            ++inicio;//aumento inicio para intentar eliminar al siguiente en caso de ser seleccion multiple
        }else if(circular_productos->eliminate(llave)){
            ui->list_productos->removeRow(inicio);
        }
    }
    connect(ui->list_productos,SIGNAL(currentItemChanged(QTableWidgetItem*,QTableWidgetItem*)),this,SLOT(on_list_productos_currentItemChanged(QTableWidgetItem*,QTableWidgetItem*)));//reconectamos la tabla
}

void Principal::setTablaProductos()
{
    ui->list_productos->insertColumn(0);
    ui->list_productos->insertColumn(1);
    ui->list_productos->insertColumn(2);
    QStringList aux;//solo se usa para colocar los titulos de la tabla
    aux<<"Codigo"<<"Nombre"<<"Precio";
    ui->list_productos->setHorizontalHeaderLabels(aux);
    ui->list_productos->setColumnWidth(0,100);
    ui->list_productos->setColumnWidth(1,100);
    ui->list_productos->setColumnWidth(1,100);
    ui->list_productos->horizontalHeader()->setVisible(true);
    ui->list_productos->verticalHeader()->setVisible(true);
}

void Principal::modificarProducto()
{
    if(checkValoresProducto())
        return;
    if(circular_productos->modify(Producto::Producto(ui->line_codigo_producto->text(),ui->line_nombre_producto->text()
                                            ,ui->line_precio_producto->text().toDouble(),ui->plain_descripcion_producto->toPlainText()),
                                  ui->line_codigo_producto->text(),codigo_producto_elegido)){
        recargarListaProductos();
    }else{
        addLogMessage("El codigo de producto ya existe");
    }


}
/*Productos*/

/*Clientes*/
void Principal::cargarClientes(QString direccion)
{
    if(jsonClientes(lista_clientes,direccion,circular_productos))
        recargarTablaClientes();
}

bool Principal::insertarCliente()
{
    return lista_clientes->push(Cliente::Cliente(ui->line_nit_cliente->text(),ui->line_nombre_cliente->text()),ui->line_nit_cliente->text());
}

void Principal::eliminarClientes()
{
    ui->tabla_admin_clientes->disconnect();//como molesta esa signal
    int inicio=ui->tabla_admin_clientes->currentIndex().row();
    int fin;
    if(inicio>0){
        if(ui->tabla_admin_clientes->item(inicio-1,0)->isSelected()){//si la seleccion fue de arriba hacia abajo
            fin=inicio+1;
            inicio=inicio-ui->tabla_admin_clientes->selectedItems().count()+1;
        }else{
           fin=ui->tabla_admin_clientes->selectedItems().count()+inicio;
        }
    }else{
        fin=ui->tabla_admin_clientes->selectedItems().count()+inicio;
    }
    QString llave;
    Nodo_S<Cliente> *actual=nullptr;
    for(int i=inicio;i<fin;i++){
        llave=ui->tabla_admin_clientes->item(inicio,0)->text();
        actual=lista_clientes->eliminateButCF(llave);
        if(actual!=nullptr){
            ui->tabla_admin_clientes->removeRow(inicio);
            recuperarFacturas(actual);
        }else{
            ++inicio;
        }
    }
    connect(ui->tabla_admin_clientes,SIGNAL(currentItemChanged(QTableWidgetItem*,QTableWidgetItem*)),this,SLOT(on_tabla_admin_clientes_currentItemChanged(QTableWidgetItem*,QTableWidgetItem*)));
}

bool Principal::modificarCliente()
{
    if(checkValoresCliente())
        return false;

    Cliente modificado(ui->line_nit_cliente->text(),ui->line_nombre_cliente->text());
    modificado.mis_facturas=lista_clientes->search(nit_cliente_elegido)->item.mis_facturas;//necesito que se lleve sus facturas tambien

    if(lista_clientes->modify(modificado,ui->line_nit_cliente->text(),nit_cliente_elegido)){
        recargarTablaClientes();
        return true;
    }else{
        addLogMessage("El NIT del cliente a modificar ya existe");
    }
    return false;
}

bool Principal::revisarFacturas(QString codigo_producto)
{
    Nodo_S<Cliente> *aux = lista_clientes->raiz;
    Nodo_S<Factura>  *aux_factura = nullptr;
    Nodo_S<Item> *aux_item=nullptr;
    Cliente cliente_actual;
    Factura factura_actual;
    while(aux!=nullptr){
        cliente_actual=aux->item;
        aux_factura=cliente_actual.mis_facturas->raiz;
        while(aux_factura!=nullptr){
            factura_actual=aux_factura->item;
            aux_item=factura_actual.productos->raiz;
            while(aux_item!=nullptr){
                if(aux_item->item.producto->codigo==codigo_producto){
                    return true;
                }
                aux_item=aux_item->siguiente;
            }
            aux_factura=aux_factura->siguiente;
        }
        aux=aux->siguiente;
    }
    return false;
}

void Principal::recuperarFacturas(Nodo_S<Cliente> *cliente)
{
    Nodo_S<Cliente> *aux = lista_clientes->search("CF");
    if(aux==nullptr)
        return;
    Nodo_S<Factura> *aux_factura=cliente->item.mis_facturas->raiz;
    Factura actual;
    while(aux_factura!=nullptr){
        actual=aux_factura->item;
        aux->item.mis_facturas->push(Factura::Factura(actual.serie,actual.correlativo,actual.fecha.toString("dd/MM/yyyy"),&aux->item.nit),actual.serie+QString::number(actual.correlativo));
        aux_factura=aux_factura->siguiente;
    }
}




/*Clientes*/

/*Facturas*/
void Principal::buscarCliente()
{
    QString nit_cliente;
    if(ui->line_buscar_cliente->text().isEmpty())
        nit_cliente="CF";
    else
        nit_cliente=ui->line_buscar_cliente->text();
    Nodo_S<Cliente> *aux = lista_clientes->search(nit_cliente);
    if(aux!=nullptr){
        ui->line_nombre_ref->setText(aux->item.nombre);
        ui->line_nit_ref->setText(aux->item.nit);
        recargarTablaFacturas(aux->item);
    }
}

void Principal::detalleFactura(QString llave_factura)
{
    QString nit_cliente;
    if(ui->line_buscar_cliente->text().isEmpty())
        nit_cliente="CF";
    else
        nit_cliente=ui->line_buscar_cliente->text();
    Nodo_S<Cliente> *aux = lista_clientes->search(nit_cliente);
    if(aux==nullptr)
        return;
    Nodo_S<Factura> *actual=aux->item.mis_facturas->search(llave_factura);
    if(actual==nullptr)
        return;
    recargarTablaItems(actual->item);
    ui->tab_main->setCurrentIndex(3);
}
/*Facturas*/

/*Nueva Factura*/
void Principal::iniciarNvaFactura()
{
    QString nit_cliente;
    if(ui->line_nva_nit->text().isEmpty())
        nit_cliente="CF";
    else
        nit_cliente=ui->line_nva_nit->text();
    Nodo_S<Cliente> *aux = lista_clientes->search(nit_cliente);
    if(aux!=nullptr){
        setBotones(true);
        nva_factura->nit=&(aux->item.nit);//nuevo
        addLogMessage("Cliente encontrado:"+aux->item.nombre);
    }else{
        setBotones(false);
        addLogMessage("No se encontro el cliente");
    }
}

void Principal::pushProducto()
{
    if(checkValoresNvoProducto())
        return;
    Nodo<Producto,QString> *aux = circular_productos->search(ui->line_nva_codigo->text());
    if(aux==nullptr)
        return;
    nva_factura->productos->push(Item::Item(&(aux->item),ui->line_nva_cantidad->text().toDouble(),ui->line_nva_descuento->text().toDouble()));
    recargarTablaNvaFactura(*nva_factura);
}

void Principal::popProducto()
{
    nva_factura->productos->pop();
    recargarTablaNvaFactura(*nva_factura);
}

/*Nueva Factura*/


/*Slots*/
void Principal::on_boton_cargar_clicked()
{
    if(!ui->line_carga_producto->text().isEmpty()){
        cargarProductos(ui->line_carga_producto->text());
    }
}

void Principal::on_boton_modificar_clicked()
{
    modificarProducto();
}

void Principal::on_boton_reporte_clicked()
{
    graficarProductos();
    //recargarListaProductos();
}

void Principal::on_boton_buscar_clicked()
{
    filtrarProductos(ui->line_buscar_producto->text());
}

void Principal::on_boton_eliminar_clicked()
{
    eliminarProductos();
}

void Principal::on_boton_insertar_clicked()
{
    if(checkValoresProducto()){
        QMessageBox::warning(this,"Error","No puede dejar valores vacios al insertar producto");
    }else{
        if(!insertarProducto()){//significa que era un producto repetido
             QMessageBox::warning(this,"Repeticion","El codigo de producto ya existe");
        }else{
            recargarListaProductos();
        }
    }
}


void Principal::on_list_productos_currentItemChanged(QTableWidgetItem *current, QTableWidgetItem *previous)
{
    QString codigo_producto = current->text();
    codigo_producto_elegido=codigo_producto;//este se usa para verificar si se cambio el codigo al modificar un producto
    Nodo<Producto,QString> *aux = circular_productos->search(codigo_producto);
    if(aux!=nullptr){
        ui->line_nombre_producto->setText(aux->item.nombre);
        ui->line_codigo_producto->setText(aux->llave);
        ui->line_precio_producto->setText(QString::number(aux->item.precio));
        ui->plain_descripcion_producto->setPlainText(aux->item.descripcion);
        ui->line_buscar_producto->setText(current->text());
    }else{
        ui->line_buscar_producto->clear();
    }
}
//Administracion de clientes
void Principal::on_boton_insertar_cliente_clicked()
{
    if(checkValoresCliente()){
        addLogMessage("No puede dejar campos vacios al insertar nuevo cliente");
    }else{
        if(!insertarCliente()){
            addLogMessage("El NIT del cliente esta repetido, por favor intente otro valor");
        }else{
            //nada
        }
    }
}

void Principal::on_boton_modificar_cliente_clicked()
{
    modificarCliente();
}

void Principal::on_boton_reporte_cliente_clicked()
{
    graficarClientes();
}


void Principal::on_boton_cargar_clientes_clicked()
{
    if(!ui->line_carga_cliente->text().isEmpty()){
        cargarClientes(ui->line_carga_cliente->text());
    }
}

void Principal::on_boton_eliminar_cliente_clicked()
{
    eliminarClientes();
}

void Principal::on_tabla_admin_clientes_currentItemChanged(QTableWidgetItem *current, QTableWidgetItem *previous)
{
    QString nit_cliente = current->text();
    nit_cliente_elegido=nit_cliente;//este se usa para verificar si se cambio el codigo al modificar un cliente
    Nodo_S<Cliente> *aux=lista_clientes->search(nit_cliente);
    if(aux!=nullptr){
        ui->line_nit_cliente->setText(aux->item.nit);
        ui->line_nombre_cliente->setText(aux->item.nombre);
        //addLogMessage("si se encontro el cliente"+aux->item.nit);
    }else{
        //addLogMessage("No se encontro el cliente");
    }
}

//administracion facturas
void Principal::on_boton_buscar_cliente_clicked()
{
    buscarCliente();
}
void Principal::on_tabla_facturas_cliente_currentItemChanged(QTableWidgetItem *current, QTableWidgetItem *previous)
{
    if(current->column()<1)
        detalleFactura(current->text()+ui->tabla_facturas_cliente->item(current->row(),current->column()+1)->text());
}
void Principal::on_boton_eliminar_factura_clicked()
{
    Nodo_S<Cliente> *aux = lista_clientes->search(ui->label_nit->text());
    if(aux!=nullptr){
        aux->item.mis_facturas->eliminate(ui->label_serie->text()+ui->label_correlativo->text());
        addLogMessage("Factura eliminada:"+ui->label_serie->text()+ui->label_correlativo->text());
    }
}

//nueva factura
void Principal::on_line_nva_nit_editingFinished()
{
    iniciarNvaFactura();
}
void Principal::on_boton_push_clicked()
{
    pushProducto();
}
void Principal::on_boton_pop_clicked()
{
    popProducto();
}
void Principal::on_boton_vaciar_clicked()
{
    nva_factura->cleanProductos();
    recargarTablaNvaFactura(*nva_factura);
}
void Principal::on_boton_total_clicked()
{
    if(nva_factura->productos->count>0){
        ui->label_nva_total->setText(QString::number(nva_factura->total()));
    }else{
        ui->label_nva_total->setText("");
        addLogMessage("Debe haber al menos un producto para calcular el total de la factura");
    }
}
void Principal::on_boton_guardar_clicked()
{
    if(nva_factura->productos->count<1){
        addLogMessage("Debe haber al menos un producto para guardar la factura");
        return;
    }
    QString nit_cliente;
    if(ui->line_nva_nit->text().isEmpty())
        nit_cliente="CF";
    else
        nit_cliente=ui->line_nva_nit->text();
    Nodo_S<Cliente> *aux = lista_clientes->search(nit_cliente);
    nva_factura->fecha=QDate::currentDate();
    nva_factura->serie=ui->line_nva_serie->text();
    nva_factura->correlativo=ui->line_nva_correlativo->text().toInt();
    if(aux!=nullptr){
        aux->item.mis_facturas->push(*nva_factura,nva_factura->serie+QString::number(nva_factura->correlativo));
        nva_factura->cleanProductos();
        nva_factura=new Factura();
        recargarTablaNvaFactura(*nva_factura);
        setBotones(false);
    }
}
//rendimiento
void Principal::on_pushButton_clicked()
{
    pruebaRendimiento();
}
/*Slots*/






/*Graficas*/
QString Principal::codigoProductos()
{
    QString codigo="digraph G{\n"
            "rankdir=LR;\n";
    Nodo<Producto,QString> *aux=circular_productos->raiz;
    if(aux!=nullptr){
        do{//unico caso en el que se me ocurrio que seria util el do
            Producto actual=aux->item;
            QString n_producto=actual.codigo;
            codigo+=n_producto+
                    "[label=\"Codigo: "+n_producto+"\nNombre:"+actual.nombre+"\nPrecio: Q."+QString::number(actual.precio)+"\";shape=box];\n";//Creo nodo actual
            codigo+=n_producto+"->"+aux->siguiente->item.codigo+";\n";//actual apunta a siguiente
            codigo+=aux->siguiente->item.codigo+"->"+n_producto+";\n";//siguiente apunta a actual
            aux=aux->siguiente;
        }while(aux!=circular_productos->raiz);
    }
    codigo+= "color=black;\n"
            "}\n";
    return codigo;
}

bool Principal::graficarProductos()
{
    QString dot_name="productos.dot";
    QString img_name="productos.png";
    guardarDot("productos.dot",codigoProductos());
    graficarDot(dot_name,img_name);
    abrirImagen(img_name);
    return true;
}

QString Principal::codigoClientes()
{
    QString codigo="digraph G{\n"
            "rankdir=LR;\n";
    Nodo_S<Cliente> *aux = lista_clientes->raiz;
    Cliente actual;
    QString id_actual;
    while(aux!=nullptr){
        actual=aux->item;
        id_actual=actual.nit.remove(QChar('-'));
        codigo+=id_actual+"[label=\"NIT: "+actual.nit+"\nNombre: "+actual.nombre+"\nFacturas:"+QString::number(actual.mis_facturas->count)+"\";shape=box];\n";
        if(aux->siguiente!=nullptr){
            codigo+=id_actual+"->"+aux->siguiente->item.nit.remove(QChar('-'))+";\n";
        }
        aux=aux->siguiente;
    }
    codigo+="}\n";
    return codigo;
}

bool Principal::graficarClientes()
{
    QString dot_name="clientes.dot";
    QString img_name="clientes.png";
    guardarDot(dot_name,codigoClientes());
    graficarDot(dot_name,img_name);
    abrirImagen(img_name);
    return true;
}




/*Graficas*/

/*Tabla*/
void Principal::setTablaClientes()
{
    //ui->tabla_admin_clientes->setColumnCount(2);
    ui->tabla_admin_clientes->insertColumn(0);
    ui->tabla_admin_clientes->insertColumn(1);
    QStringList aux;//solo se usa para colocar los titulos de la tabla
    aux<<"NIT"<<"Nombre";
    ui->tabla_admin_clientes->setHorizontalHeaderLabels(aux);
    ui->tabla_admin_clientes->setColumnWidth(0,100);
    ui->tabla_admin_clientes->setColumnWidth(1,480);
    ui->tabla_admin_clientes->horizontalHeader()->setVisible(true);
    ui->tabla_admin_clientes->verticalHeader()->setVisible(true);
    recargarTablaClientes();//nuevo
}

void Principal::setTablaFacturas()
{
    for(int i=0;i<3;i++)
        ui->tabla_facturas_cliente->insertColumn(i);
    QStringList aux;//solo se usa para los titulos de la tabla
    aux<<"Serie"<<"Correlativo"<<"Fecha";
    ui->tabla_facturas_cliente->setHorizontalHeaderLabels(aux);
    ui->tabla_facturas_cliente->setColumnWidth(0,100);
    ui->tabla_facturas_cliente->setColumnWidth(1,100);
    ui->tabla_facturas_cliente->setColumnWidth(2,100);

}

void Principal::setTablaItems()
{
    for(int i=0;i<5;i++)
        ui->tabla_items_factura->insertColumn(i);
    QStringList aux;//solo para los titulos de la tabla
    aux<<"Codigo Producto"<<"Descripcion"<<"Precio"<<"Cantidad"<<"Descuento";
    ui->tabla_items_factura->setHorizontalHeaderLabels(aux);
    ui->tabla_items_factura->setColumnWidth(0,100);
    ui->tabla_items_factura->setColumnWidth(1,200);
    ui->tabla_items_factura->setColumnWidth(2,80);
    ui->tabla_items_factura->setColumnWidth(3,60);
    ui->tabla_items_factura->setColumnWidth(4,70);
}

void Principal::setTablaNvaFactura()
{
    for(int i=0;i<2;i++)
        ui->tabla_nueva_factura->insertColumn(i);
    QStringList aux;//solo para los titulos de la tabla
    aux<<"Producto"<<"Cantidad";
    ui->tabla_nueva_factura->setHorizontalHeaderLabels(aux);
    ui->tabla_nueva_factura->setColumnWidth(0,200);
    ui->tabla_nueva_factura->setColumnWidth(1,80);

}

void Principal::setTablaRendimiento()
{
    for(int i=0;i<3;i++)
        ui->tabla_prueba_rendimiento->insertColumn(i);
    QStringList aux;
    aux<<"Enteros"<<"Lista propia"<<"Estructura del lenguaje QList";
    ui->tabla_prueba_rendimiento->setHorizontalHeaderLabels(aux);
    ui->tabla_prueba_rendimiento->setColumnWidth(0,100);
    ui->tabla_prueba_rendimiento->setColumnWidth(1,100);
    ui->tabla_prueba_rendimiento->setColumnWidth(2,200);

}

void Principal::setBotones(bool valor)
{
    ui->boton_pop->setEnabled(valor);
    ui->boton_push->setEnabled(valor);
    ui->boton_guardar->setEnabled(valor);
    ui->boton_vaciar->setEnabled(valor);
}
/*Tabla*/















