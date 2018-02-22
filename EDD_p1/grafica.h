#ifndef GRAFICA_H
#define GRAFICA_H
#include <QString>
#include <QCoreApplication>
#include "Estructuras/listac.h"
#include "Objetos/producto.h"
#include <fstream>

void guardarDot(QString dot_name, QString codigo);
bool graficarDot(QString dot_name, QString img_name);
void abrirImagen(QString img_name);

#endif // GRAFICA_H
