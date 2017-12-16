#ifndef ARCHIVO_H
#define ARCHIVO_H
#include <QString>
#include <fstream>

//const QString graphviz_path="C:/graphviz-2.38/release/bin/dot.exe";
const QString direccion_dot="C:/graphviz-2.38/grafica.dot";
const QString direccion_img="C:/graphviz-2.38/grafica.png";
void guardar(QString texto);
void crearImagen();


#endif // ARCHIVO_H
