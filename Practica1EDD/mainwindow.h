#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "myclasses.h"
#include "archivo.h"
#include <qgraphicsscene.h>
#include <QGraphicsPixmapItem>
#include <QMessageBox>

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
    int id_maleta;
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
    ListaDC<int> *lista_maletas;
    void setEstructuras();
    void clearEstructuras();
    void setMaletas(int cantidad);
    void setPasajeros(int cantidad);

    /*Estructuras*/

    /*print functions*/
    void conPrint(QString texto);
    void printInfoEstacion();
    void printInfoRegistro();
    void printInfoMaletas();
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
    QString codigoMaletas();
    QString codigoRegistro();
    QString codigoPasajeros();
    QString codigoMantenimiento();
    QString codigoPasajerosColaRegistro(Escritorio *actual);
    void recargarImagen();
    /*Codigo grafica*/

    /*Funciones Auxiliares*/
    QString datosEscritorio(Escritorio *actual);
    QString datosEstacion(Estacion *actual);
    void finSimulacion();
    void setTextMask();
    bool checkMask();

    /*Funciones Auxiliares*/



};

#endif // MAINWINDOW_H
