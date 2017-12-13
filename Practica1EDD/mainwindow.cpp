
#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    srand(time(0));//seed para el random
    //setEstructuras();//inicializo las estructuras
    turno=1;
    //debug();

}

MainWindow::~MainWindow()
{
    delete ui;
}



/*Private Slots*/
void MainWindow::on_boton_inicio_clicked()
{
    setEstructuras();//inicio las estructuras
    setAviones();
    debug();
}

void MainWindow::on_boton_siguiente_clicked()
{
    ++turno;
    turnoAvion();
    estacion_mantenimiento->pasarTurno();
    qDebug("antes de debug en siguiente");
    debug();
}



/*Private Slots*/

/*Clases*/
void MainWindow::printInfoEstacion()
{
    Nodo<Estacion*> *aux=estacion_mantenimiento->lista_estacion->raiz;
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

}

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
    int no_estaciones=ui->text_estaciones->text().toInt();
    conPrint("setEstructuras:"+QString::number(no_estaciones));
    estacion_mantenimiento=new Mantenimiento(no_estaciones);
}
/*Estructuras*/


/*print functions*/
void MainWindow::conPrint(QString texto)
{
    QString texto_anterior=ui->textedit_consola->toPlainText();
    QString texto_nuevo = texto_anterior+texto+'\n';
    ui->textedit_consola->setPlainText(texto_nuevo);
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
    if(cola_aviones->top()->desabordaje==0)
        estacion_mantenimiento->encolarAvion(cola_aviones->desEncolar());

}

/*Turno*/


/*Debug functions*/
void MainWindow::debug()
{
   /* Cola<int> *prueba=new Cola<int>();
    for(int i=0;i<15;i++){
        if(prueba->isFull()){
            conPrint("se lleno la cola en:"+QString::number(i));
            break;
        }
        prueba->enColar(i);
    }
    while(!prueba->isEmpty()){
        conPrint(QString::number(prueba->desEncolar()));
    }*/
    conPrint("------------info Aviones-----------");
    conPrint(QString::number(cola_aviones->cant));
    /*while(!cola_aviones->isEmpty()){
        Avion *actual=cola_aviones->desEncolar();
        QString salida="Avion:"+QString::number(actual->nombre)+" Tipo:"+actual->tipo+" No.Pasajeros"+QString::number(actual->pasajeros)+" Desabordaje"+
                QString::number(actual->desabordaje)+" Mantenimiento:"+QString::number(actual->mantenimiento);
        conPrint(salida);
    }*/
    conPrint("------------info Aviones-----------");
    conPrint("******Turno "+QString::number(turno)+"******");
    if(!cola_aviones->isEmpty())
        conPrint("arribo avión"+QString::number(cola_aviones->top()->nombre));
    conPrint("-----------------------------");
    conPrint("++++++Estaciones de servicio++++++");
    conPrint("No. estaciones: "+QString::number(estacion_mantenimiento->lista_estacion->cant));
    printInfoEstacion();
    conPrint("******Fin Turno "+QString::number(turno)+"*****");

}




