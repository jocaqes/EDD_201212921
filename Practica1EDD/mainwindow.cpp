
#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    srand(time(0));//seed para el random
    setEstructuras();//inicializo las estructuras
    setGraphicView();//arreglo lo necesario para mostrar la grafica
    //turno=1;
    //debug();

}

MainWindow::~MainWindow()
{
    delete ui;
}

/*Global*/
void MainWindow::setGraphicView()
{
    escenario=new QGraphicsScene();
    ui->graphic_view->setScene(escenario);
    imagen=new QGraphicsPixmapItem();
    escenario->addItem(imagen);
}

/*Global*/

/*Private Slots*/
void MainWindow::on_boton_inicio_clicked()
{
    //setEstructuras();//inicio las estructuras
    turno=1;//0. Reseteo el conteo de turnos
    clearEstructuras();//1. limpio las estructuras
    ui->textedit_consola->setPlainText("");//2. limpio consola
    setAviones();//3. agrego los aviones
    int cant_estaciones = ui->text_estaciones->text().toInt();
    estacion_mantenimiento->setEstaciones(cant_estaciones);//4. agrego las estaciones de mantenimiento
    debug();//5. temp imprimo informacion inicial
    recargarImagen();//6. muestro la grafica
    //escenario->addItem(imagen);
    //ui->graphic_view->show();
}

void MainWindow::on_boton_siguiente_clicked()
{
    ++turno;
    turnoAvion();
    estacion_mantenimiento->pasarTurno();
    debug();
    recargarImagen();
    //ui->graphic_view->show();
}





/*Private Slots*/

/*Clases*/

QString MainWindow::getEstado(bool estado)
{
    if(estado)
        return "Ocupado";
    return "libre";
}

/*Clases*/

/*Estructuras*/
void MainWindow::setEstructuras()
{
    cola_aviones=new ColaD<Avion*>();
    cola_pasajeros=new Cola<Pasajero*>();
    estacion_mantenimiento=new Mantenimiento();
}

void MainWindow::clearEstructuras()
{
    cola_aviones->clear();
    cola_pasajeros->clear();
    estacion_mantenimiento->clear();
}

void MainWindow::setPasajeros(int cantidad, int base)
{
    int i;
    for(i=base+1;i<cantidad+base;i++)
        cola_pasajeros->enColar(new Pasajero(i));

}
/*Estructuras*/


/*print functions*/
void MainWindow::conPrint(QString texto)
{
    QString texto_anterior=ui->textedit_consola->toPlainText();
    QString texto_nuevo = texto_anterior+texto+'\n';
    ui->textedit_consola->setPlainText(texto_nuevo);
}

void MainWindow::printInfoAvion()
{
    if(cola_aviones->isEmpty())
        conPrint("No hay mas Aviones en cola");
    else{
        QString mensaje = "Arribó avión:"+QString::number(cola_aviones->top()->nombre);
        conPrint(mensaje);
        mensaje = "Avión desabordando"+QString::number(cola_aviones->top()->nombre);
        conPrint(mensaje);
        mensaje = "debug turnos faltantes avion actual:"+QString::number(cola_aviones->top()->desabordaje);
    }
}

void MainWindow::printInfoEstacion()
{
    Nodo<Estacion*> *aux=estacion_mantenimiento->lista_estacion->raiz;
    conPrint("++++++Estaciones de servicio++++++");
    while(aux!=nullptr){
        Estacion *actual = aux->item;
        QString mensaje="Estación "+QString::number(actual->nombre)+":"+getEstado(actual->estado);
        conPrint(mensaje);
        mensaje="\tTurnos restantes:"+QString::number(actual->turnos_restantes);
        conPrint(mensaje);
        aux=aux->siguiente;
        mensaje="\tAviones en cola:"+QString::number(estacion_mantenimiento->aviones_en_espera->cant);
        conPrint(mensaje);
    }
    conPrint("+++++++++++++++++++++++++");

}

/*print functions*/

/*Start*/
void MainWindow::setAviones()
{
    int cantidad=ui->text_aviones->text().toInt();
    int i;
    for(i=0;i<cantidad;i++){
        cola_aviones->enColar(new Avion(i+1));
    }
}



/*Start*/

/*Turno*/
void MainWindow::turnoAvion()
{
    if(cola_aviones->isEmpty())
        return;
    cola_aviones->top()->desabordaje--;
    if(cola_aviones->top()->desabordaje==0){
        setPasajeros(cola_aviones->top()->pasajeros,cola_pasajeros->cant);
        estacion_mantenimiento->encolarAvion(cola_aviones->desEncolar());

    }

}

/*Turno*/


/*Debug functions*/
void MainWindow::debug()
{
    conPrint("******Turno "+QString::number(turno)+"******");
    printInfoAvion();//nuevo
    printInfoEstacion();//nuevo
    conPrint("******Fin Turno "+QString::number(turno)+"******");

}


/*Codigo grafica*/
QString MainWindow::codigoAviones()
{
    QString codigo="subgraph cluster_aviones{\n"
                   "llegada_aviones[label=\"Llegadas\nde Aviones\";fillcolor=\"blue:cyan\";shape=box;fontcolor=white;style=filled;height=.5;width=1.5;fixedsize=true]\n";

    Nodo<Avion*> *aux=cola_aviones->raiz;
    if(aux!=nullptr)
        codigo+="llegada_aviones->Lavion"+QString::number(aux->item->nombre)+"[color=transparent;dir=none]\n";
    while(aux!=nullptr){
        Avion *actual=aux->item;
        QString n_avion=QString::number(actual->nombre);
        codigo+="Lavion"+n_avion+
                "[label=\"Avion "+n_avion+"\"];\n";//Creo nodo actual
        if(aux->anterior!=nullptr){//si su anterior existe
            codigo+="Lavion"+QString::number(aux->anterior->item->nombre)+"->"+"Lavion"+n_avion+";\n";//anterior apunta a actual
            codigo+="Lavion"+n_avion+"->"+"Lavion"+QString::number(aux->anterior->item->nombre)+";\n";//actual apunta a anterior
        }
        aux=aux->siguiente;
    }
    codigo+= "color=black;\n"
            "}\n";
    return codigo;
}

QString MainWindow::codigoPasajeros()
{
    QString codigo="subgraph cluster_pasajeros{\n"
                   "titulo_desabordaje[label=\"Desabordaje\";fillcolor=\"blue:cyan\";shape=box;fontcolor=white;style=filled;height=.5;width=1.5;fixedsize=true]\n";
    Nodo<Pasajero*> *aux=cola_pasajeros->raiz;
    if(aux!=nullptr)
        codigo+="titulo_desabordaje->Dpasajero"+QString::number(aux->item->id)+"[color=transparent;dir=none]\n";
    while(aux!=nullptr){
        Pasajero *actual=aux->item;
        QString id=QString::number(actual->id);
        codigo+="Dpasajero"+id+
                "[label=\"Pasajero "+id+"\"];\n";//Creo nodo actual
        if(aux->siguiente!=nullptr){//si su siguiente existe
            QString id_siguiente=QString::number(aux->siguiente->item->id);
            codigo+="Dpasajero"+id_siguiente+
                    "[label=\"Pasajero "+id_siguiente+"\"];\n";//Creo nodo siguiente
            codigo+="Dpasajero"+id+"->"+"Dpasajero"+id_siguiente+";\n";//actual apunta a siguiente
        }
        aux=aux->siguiente;
    }
    codigo+="color=black;\n"
            "}\n";
    return codigo;
}

QString MainWindow::codigoMantenimiento()
{
    QString codigo="subgraph cluster_mantenimiento{\n"
                   "titulo_mantenimiento[label=\"Mantenimiento\";fillcolor=\"blue:cyan\";shape=box;fontcolor=white;style=filled;height=.5;width=1.5;fixedsize=true]\n";
    Nodo<Estacion*> *aux_estacion=estacion_mantenimiento->lista_estacion->raiz;
    if(aux_estacion!=nullptr){
        codigo+="titulo_mantenimiento->Sestacion"+QString::number(1)+"[color=transparent;dir=none]\n";
        codigo+="titulo_mantenimiento->Sestacion"+QString::number(estacion_mantenimiento->lista_estacion->cant)+"[color=transparent;dir=none]\n";
    }
    QString nombre;
    QString nombre_siguiente;
    codigo+= "{rank=same;\n";
    while(aux_estacion!=nullptr){
        Estacion *actual=aux_estacion->item;      
        nombre=QString::number(actual->nombre);
        codigo+="Sestacion"+nombre+"[label=\"Estacion "+nombre+datosEstacion(actual)+"\",shape=square];\n";//Creo nodo actual
        if(aux_estacion->siguiente!=nullptr){//si tiene siguiente
            nombre_siguiente=QString::number(aux_estacion->siguiente->item->nombre);
            codigo+="Sestacion"+nombre_siguiente+
                    "[label=\"Estacion "+nombre_siguiente+"\",shape=square];\n";//Creo nodo siguiente
            codigo+="Sestacion"+nombre+"->"+"Sestacion"+nombre_siguiente+"[color=blue;];\n";//actual apunta a siguiente
        }
        aux_estacion=aux_estacion->siguiente;
    }
    codigo+="}\n";//para cerrar el rank=same

    //codigo+="subgraph cluster_cola_mantenimiento{\n";
    Nodo<Avion*> *aux_avion=estacion_mantenimiento->aviones_en_espera->raiz;
    if(aux_avion!=nullptr){
        codigo+="Sestacion"+QString::number(1)+"->Mavion"+QString::number(aux_avion->item->nombre)+"[color=transparent;dir=none]\n";
        codigo+="Sestacion"+QString::number(estacion_mantenimiento->lista_estacion->cant)+"->Mavion"+QString::number(aux_avion->item->nombre)+"[color=transparent;dir=none]\n";
    }
    while(aux_avion!=nullptr){
        Avion *actual=aux_avion->item;
        nombre=QString::number(actual->nombre);
        codigo+="Mavion"+nombre+"[label=\"Avion "+nombre+"\"];\n";//Creo nodo actual
        if(aux_avion->siguiente!=nullptr){//si tiene siguiente
            nombre_siguiente=QString::number(aux_avion->siguiente->item->nombre);
            codigo+="Mavion"+nombre_siguiente+
                    "[label=\"Avion "+nombre_siguiente+"\"];\n";//Creo nodo siguiente
            codigo+="Mavion"+nombre+"->"+"Mavion"+nombre_siguiente+";\n";//actual apunta a siguiente
        }
        aux_avion=aux_avion->siguiente;
    }
    codigo+="}\n"
            "color=black;\n"
            "}\n";
    return codigo;
}



void MainWindow::recargarImagen()
{
    QString codigo="digraph G{\n"
                   +codigoAviones()
            +codigoPasajeros()
            +codigoMantenimiento()
            +"}";
    guardar(codigo);//cuidado
    crearImagen();//cuidado
    imagen->setPixmap(QPixmap(direccion_img));
}


/*Codigo grafica*/


/*Funciones Auxiliares*/
QString MainWindow::datosEstacion(Estacion *actual)
{
    QString datos_estacion;
    datos_estacion="\nRevisando:";
    if(actual->en_mantenimiento!=nullptr)
        datos_estacion+="Avion "+QString::number(actual->en_mantenimiento->nombre)+"\n";
    else
        datos_estacion+="ninguno\n";
    if(actual->estado)
        datos_estacion+="Estado:ocupado\n";
    else
        datos_estacion+="Estado:libre\n";
    datos_estacion+="Turnos restantes:"+QString::number(actual->turnos_restantes);
    return datos_estacion;
}

/*Funciones Auxiliares*/



