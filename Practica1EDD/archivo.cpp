#include "archivo.h"


void guardar(QString texto)
{
    std::ofstream archivo(direccion_dot.toLatin1());
    archivo<<texto.toStdString();
    archivo.close();
}

void crearImagen()
{

    QString comando = graphviz_path+" -Tpng "+direccion_dot+" -o "+direccion_img;
    comando = comando.replace("/","\\");
    QByteArray ba;
    ba=comando.toLatin1();
    char *command = ba.data();
    system(command);


}
