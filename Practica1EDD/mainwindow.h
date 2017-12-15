#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
//#include "mystructs.h"
#include "myclasses.h"
//#include <QString>
#include "archivo.h"
#include <qgraphicsscene.h>
#include <QGraphicsPixmapItem>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private slots:
    void on_boton_inicio_clicked();

    void on_boton_siguiente_clicked();

private:
    Ui::MainWindow *ui;
    /*Global*/
    int turno;
    int id_pasajero;
    void setGraphicView();
    /*Global*/

    /*Clases*/
    Mantenimiento *estacion_mantenimiento;
    Registro *estacion_registro;
    QGraphicsPixmapItem *imagen;
    QGraphicsScene *escenario;
    QString getEstado(bool estado);
    /*Clases*/

    /*Estructuras*/
    ColaD<Avion*> *cola_aviones;
    Cola<Pasajero*> *cola_pasajeros;
    void setEstructuras();
    void clearEstructuras();
    void setPasajeros(int cantidad);
    /*Estructuras*/

    /*print functions*/
    void conPrint(QString texto);
    void printInfoEstacion();
    void printInfoRegistro();
    void printInfoAvion();
    /*print functions*/

    /*Start*/
    void setAviones();
    /*Start*/

    /*Turno*/
    void turnoAvion();
    /*Turno*/

    /*debug functions*/
    void debug();
    /*debug functions*/

    /*Codigo grafica*/
    QString codigoAviones();
    QString codigoRegistro();
    QString codigoPasajeros();
    QString codigoMantenimiento();
    QString codigoPasajerosColaRegistro(Escritorio *actual);
    void recargarImagen();
    /*Codigo grafica*/

    /*Funciones Auxiliares*/
    QString datosEstacion(Estacion *actual);
    QString datosEscritorio(Escritorio *actual);
    /*Funciones Auxiliares*/



};

#endif // MAINWINDOW_H
