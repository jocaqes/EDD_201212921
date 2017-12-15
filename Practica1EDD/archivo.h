#ifndef ARCHIVO_H
#define ARCHIVO_H
#include <QString>
#include <fstream>

const QString graphviz_path="D:/Sistemas/Instaladores/graphviz-2.38/release/bin/dot.exe";
const QString direccion_dot="D:/Sistemas/2017/Vacaciones_de_Diciembre/practica1/grafica.dot";
const QString direccion_img="D:/Sistemas/2017/Vacaciones_de_Diciembre/practica1/grafica.png";
void guardar(QString texto);
void crearImagen();


#endif // ARCHIVO_H
