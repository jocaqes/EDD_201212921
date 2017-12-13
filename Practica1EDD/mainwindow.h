#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
//#include "mystructs.h"
#include "myclasses.h"
#include <QString>

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
    /*Global*/

    /*Clases*/
    Mantenimiento *estacion_mantenimiento;
    void printInfoEstacion();
    QString getEstado(bool estado);
    /*Clases*/

    /*Estructuras*/
    ColaD<Avion*> *cola_aviones;
    void setEstructuras();
    /*Estructuras*/

    /*print functions*/
    void conPrint(QString texto);
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



};

#endif // MAINWINDOW_H
