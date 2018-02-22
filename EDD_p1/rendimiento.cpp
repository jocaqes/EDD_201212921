#include "rendimiento.h"



int iniciarPrueba(int cantidad, bool mi_lista)
{
    srand(time(0));//un seed para el random
    if(mi_lista){
        return pruebaQList(cantidad);
    }
    return pruebaMiLista(cantidad);

}

int pruebaQList(int cantidad)
{
    QTime actual;
    actual.start();
    QList<int> *nueva = new QList<int>();
    for(int i=0;i<cantidad;i++){
        nueva->append(0+rand()%cantidad);
    }
    qSort(nueva->begin(),nueva->end(),qGreater<int>());
    return actual.elapsed();
}

int pruebaMiLista(int cantidad)
{
    QTime actual;
    actual.start();
    ListaC<int,int> *nueva = new ListaC<int,int>();
    for(int i=0;i<cantidad;i++){
        nueva->push(i,i);
    }
    return actual.elapsed();
}
