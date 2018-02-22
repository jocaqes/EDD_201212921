#include "grafica.h"


void guardarDot(QString dot_name, QString codigo)
{
    QString main_path="D:/Sistemas/2018/EDD/";
    std::ofstream archivo((main_path+dot_name).toLatin1());
    archivo<<codigo.toStdString();
    archivo.close();
}

bool graficarDot(QString dot_name, QString img_name)
{
    QString main_path="D:/Sistemas/2018/EDD/";
    QString comando = "dot -Tpng "+main_path+dot_name+" -o "+main_path+img_name;
    comando = comando.replace("/","\\");
    QByteArray ba;
    ba=comando.toLatin1();
    char *command = ba.data();
    system(command);
    return true;
}

void abrirImagen(QString img_name)
{
    QString main_path="D:/Sistemas/2018/EDD/";
    QString comando = main_path+img_name;
    comando = comando.replace("/","\\");
    QByteArray ba;
    ba=comando.toLatin1();
    char *command = ba.data();
    system(command);
}
