
#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    id_pasajero=1;
    srand(time(0));//seed para el random
    setEstructuras();//inicializo las estructuras
    setGraphicView();//arreglo lo necesario para mostrar la grafica
    setTextMask();
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
    if(!checkMask()){
        QMessageBox msgBox;
        msgBox.setText("Algun valor Ingresado no es Valido,\nrevise que no tenga letras\no valores vacios");
        msgBox.exec();
        return;
    }
    turno=1;//0. Reseteo el conteo de turnos
    id_pasajero=1;//0. Reseteo el nombre de los pasajeros
    id_maleta=1;//0. Reseteo el nombre de las maletas
    clearEstructuras();//1. limpio las estructuras
    ui->textedit_consola->setPlainText("");//2. limpio consola
    setAviones();//3. agrego los aviones
    int cant_estaciones = ui->text_estaciones->text().toInt();
    estacion_mantenimiento->setEstaciones(cant_estaciones);//4. agrego las estaciones de mantenimiento
    cant_estaciones=ui->text_escritorios->text().toInt();
    estacion_registro->setEscritorios(cant_estaciones);//5. agrego los escritorios de registro
    debug();//6. temp imprimo informacion inicial
    recargarImagen();//7. muestro la grafica
    ui->label_turno->setText(QString::number(turno));//8.agrego el turno por molestar
    ui->boton_siguiente->setEnabled(true);//9.habilito el boton siguiente
    //escenario->addItem(imagen);
    //ui->graphic_view->show();
}

void MainWindow::on_boton_siguiente_clicked()
{
    ++turno;
    turnoAvion();
    estacion_mantenimiento->pasarTurno();
    estacion_registro->pasarTurno(cola_pasajeros,lista_maletas);
    debug();
    recargarImagen();
    ui->label_turno->setText(QString::number(turno));
    finSimulacion();//nuevo
    //ui->graphic_view->show();
}





/*Private Slots*/

/*Clases*/

QString MainWindow::getEstado(bool estado)
{
    if(estado)
        return "ocupado";
    return "libre";
}

/*Clases*/

/*Estructuras*/
void MainWindow::setEstructuras()
{
    cola_aviones=new ColaD<Avion*>();
    lista_maletas=new ListaDC<int>();//nuevo
    estacion_registro=new Registro();
    cola_pasajeros=new Cola<Pasajero*>();
    estacion_mantenimiento=new Mantenimiento();

}

void MainWindow::clearEstructuras()
{
    cola_aviones->clear();
    lista_maletas->clear();
    cola_pasajeros->clear();
    estacion_registro->clear();
    estacion_mantenimiento->clear();
}

void MainWindow::setMaletas(int cantidad)
{
    int i;
    for(i=0;i<cantidad;i++,id_maleta++)
        lista_maletas->insertar(id_maleta);

}

void MainWindow::setPasajeros(int cantidad)
{
    int i;
    for(i=0;i<cantidad;i++,id_pasajero++){
        cola_pasajeros->enColar(new Pasajero(id_pasajero));
        setMaletas(cola_pasajeros->fin->item->maletas);
    }

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
        mensaje = "Avión desabordando "+QString::number(cola_aviones->top()->nombre);
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

void MainWindow::printInfoRegistro()
{
    Nodo<Escritorio*> *aux=estacion_registro->lista_escritorios->raiz;
    Escritorio *actual;
    conPrint("-------------Escritorios de Registro-------------");
    QString mensaje="";
    QString nombre_escritorio;
    while(aux!=nullptr){
        actual = aux->item;
        nombre_escritorio=actual->nombre;
        mensaje="Escritorio "+nombre_escritorio+":"+getEstado(actual->estado);
        conPrint(mensaje);
        mensaje="\tPasajero atendido:";
        if(actual->en_recepcion!=nullptr)
            mensaje+="Pasajero "+QString::number(actual->en_recepcion->id);
        else
            mensaje+="ninguno";
        conPrint(mensaje);
        mensaje="\tTurnos restantes:"+QString::number(actual->turnos_restantes);
        conPrint(mensaje);
        mensaje="\tCantidad de documentos:"+QString::number(actual->cantidad_documentos);
        conPrint(mensaje);
        aux=aux->siguiente;
    }
    conPrint("-----------------------------------------------------");
}

void MainWindow::printInfoMaletas()
{
    QString mensaje;
    mensaje="Cantidad de maletas actualmente en el sistema:"+QString::number(lista_maletas->cant);
    conPrint(mensaje);
    int turnos_restantes=ui->text_turnos->text().toInt()-turno;
    mensaje="Turnos Restantes:"+QString::number(turnos_restantes);
    conPrint(mensaje);

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
        setPasajeros(cola_aviones->top()->pasajeros);
        estacion_mantenimiento->encolarAvion(cola_aviones->desEncolar());

    }

}

/*Turno*/


/*Debug functions*/
void MainWindow::debug()
{
    conPrint("******Turno "+QString::number(turno)+"******");
    printInfoAvion();
    printInfoRegistro();//nuevo
    printInfoEstacion();
    printInfoMaletas();
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

QString MainWindow::codigoMaletas()
{
    QString codigo="subgraph cluster_maletas{\n"
                   "equipaje[label=\"Equipaje\";fillcolor=\"blue:cyan\";shape=box;fontcolor=white;style=filled;height=.5;width=1.5;fixedsize=true]\n";

    Nodo<int> *aux=lista_maletas->raiz;
    if(aux!=nullptr){
        do{//unico caso en el que se me ocurrio que seria util el do
            int actual=aux->item;
            QString n_maleta=QString::number(actual);
            codigo+="maleta"+n_maleta+
                    "[label=\"Maleta "+n_maleta+"\";shape=box];\n";//Creo nodo actual
            codigo+="maleta"+n_maleta+"->"+"maleta"+QString::number(aux->siguiente->item)+";\n";//actual apunta a siguiente
            codigo+="maleta"+QString::number(aux->siguiente->item)+"->"+"maleta"+n_maleta+";\n";//siguiente apunta a actual
            aux=aux->siguiente;
        }while(aux!=lista_maletas->raiz);
    }
    codigo+= "color=black;\n"
            "}\n"
             "llegada_aviones->equipaje[color=transparent;dir=none]\n";
    return codigo;
}

QString MainWindow::codigoRegistro()
{
    QString codigo="subgraph cluster_registro{\n"
                   "titulo_registro[label=\"Escritorios\nde Registro\";fillcolor=\"blue:cyan\";shape=box;fontcolor=white;style=filled;height=.5;width=1.5;fixedsize=true];\n";
    Nodo<Escritorio*> *aux_escritorio=estacion_registro->lista_escritorios->raiz;
    QString nombre;
    QString nombre_anterior;
    /*if(aux_escritorio!=nullptr){
        nombre=estacion_registro->lista_escritorios->raiz->item->nombre;
        nombre_anterior=estacion_registro->lista_escritorios->get(estacion_registro->lista_escritorios->cant-1)->nombre;
        codigo+="titulo_registro->Rescritorio"+nombre+"[color=transparent;dir=none];\n";
        codigo+="titulo_registro->Rescritorio"+nombre_anterior+"[color=transparent;dir=none];\n";
    }*/
    codigo+= "{rank=same;\n";
    while(aux_escritorio!=nullptr){
        Escritorio *actual=aux_escritorio->item;
        nombre=actual->nombre;
        codigo+="Rescritorio"+nombre+
                "[label=\"Escritorio\n"+nombre+datosEscritorio(actual)+"\";shape=box;];\n";//Creo nodo actual
        if(aux_escritorio->anterior!=nullptr){//si su anterior existe
            nombre_anterior=aux_escritorio->anterior->item->nombre;
            codigo+="Rescritorio"+nombre_anterior+"->"+"Rescritorio"+nombre+"[color=blue];\n";//anterior apunta a actual
            codigo+="Rescritorio"+nombre+"->"+"Rescritorio"+nombre_anterior+"[color=blue];\n";//actual apunta a anterior
        }
        //codigo+=codigoPasajerosColaRegistro(actual);
        aux_escritorio=aux_escritorio->siguiente;
    }

    codigo+="}\n";//para cerrar el rank=same
    aux_escritorio=estacion_registro->lista_escritorios->raiz;//nuevo
    while(aux_escritorio!=nullptr){
        codigo+=codigoPasajerosColaRegistro(aux_escritorio->item);
        aux_escritorio=aux_escritorio->siguiente;
    }
    codigo+="}";//para cerrar cluster
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
    codigo+="color=black;\n"
            "}\n";
    return codigo;
}

QString MainWindow::codigoPasajerosColaRegistro(Escritorio *actual)
{
    QString codigo="";
    Nodo<Pasajero*> *aux=actual->cola_pasajeros->raiz;
    QString nombre_escritorio=actual->nombre;
    if(aux!=nullptr){
        codigo="Rescritorio"+nombre_escritorio+"->"+"Rpasajero"+QString::number(aux->item->id)+"\n";//nombre escritorio;
    }
    while(aux!=nullptr){
        Pasajero *actual=aux->item;
        QString id=QString::number(actual->id);
        codigo+="Rpasajero"+id+
                "[label=\"Pasajero "+id+"\"];\n";//Creo nodo actual
        if(aux->siguiente!=nullptr){//si su siguiente existe
            QString id_siguiente=QString::number(aux->siguiente->item->id);
            codigo+="Rpasajero"+id_siguiente+
                    "[label=\"Pasajero "+id_siguiente+"\"];\n";//Creo nodo siguiente
            codigo+="Rpasajero"+id+"->"+"Rpasajero"+id_siguiente+";\n";//actual apunta a siguiente
        }
        aux=aux->siguiente;
    }
    return codigo;
}



void MainWindow::recargarImagen()
{
    QString codigo="digraph G{\n"
                   +codigoAviones()
            +codigoPasajeros()
            +codigoMantenimiento()
            +codigoRegistro()
            +codigoMaletas()//nuevo
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

QString MainWindow::datosEscritorio(Escritorio *actual)
{
    QString datos_escritorio;
    datos_escritorio="\nAtendiendo:";
    if(actual->en_recepcion!=nullptr)
        datos_escritorio+="Cliente "+QString::number(actual->en_recepcion->id)+"\n";
    else
        datos_escritorio+="ninguno\n";
    datos_escritorio+="Estado:"+getEstado(actual->estado)+"\n";
    datos_escritorio+="Documentos:"+QString::number(actual->cantidad_documentos)+"\n";
    datos_escritorio+="Turnos restantes:"+QString::number(actual->turnos_restantes);
    return datos_escritorio;
}

void MainWindow::setTextMask()
{
    ui->text_aviones->setInputMask("D0000");
    ui->text_estaciones->setInputMask("D0000");
    ui->text_escritorios->setInputMask("D0000");
    ui->text_turnos->setInputMask("D0000");
}

bool MainWindow::checkMask()
{
    if(ui->text_aviones->hasAcceptableInput()&&ui->text_turnos->hasAcceptableInput()&&ui->text_estaciones->hasAcceptableInput()&&ui->text_escritorios->hasAcceptableInput())
        return true;
    return false;
}

void MainWindow::finSimulacion()
{
    if(turno==ui->text_turnos->text().toInt()){
        QMessageBox msgBox;
        msgBox.setText("La simulación ha finalizado");
        msgBox.exec();
        ui->boton_siguiente->setEnabled(false);
    }

}

/*Funciones Auxiliares*/



