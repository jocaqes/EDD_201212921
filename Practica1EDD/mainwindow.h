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
    void setGraphicView();
    /*Global*/

    /*Clases*/
    Mantenimiento *estacion_mantenimiento;
    QGraphicsPixmapItem *imagen;
    QGraphicsScene *escenario;
    QString getEstado(bool estado);
    /*Clases*/

    /*Estructuras*/
    ColaD<Avion*> *cola_aviones;
    Cola<Pasajero*> *cola_pasajeros;
    void setEstructuras();
    void clearEstructuras();
    void setPasajeros(int cantidad, int base);
    /*Estructuras*/

    /*print functions*/
    void conPrint(QString texto);
    void printInfoEstacion();
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
    QString codigoPasajeros();
    QString codigoMantenimiento();
    void recargarImagen();
    /*Codigo grafica*/

    /*Funciones Auxiliares*/
    QString datosEstacion(Estacion *actual);
    /*Funciones Auxiliares*/



};

#endif // MAINWINDOW_H
