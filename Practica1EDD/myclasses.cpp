#include "myclasses.h"


int random(int min, int max)
{
    return min+rand()%(max+1-min);
}


/*Struct Avion*/
Avion::Avion(int nombre)
{
    this->nombre=nombre;
    setTipo();
    setTurnos(tipo);
}

void Avion::setTipo()
{
    int valor_azar=random(1,3);
    switch (valor_azar) {
    case 1:
        tipo='p';
        break;
    case 2:
        tipo='m';
        break;
    case 3:
        tipo='g';
        break;
    default:
        break;
    }
}

void Avion::setTurnos(char tipo)
{
    switch (tipo) {
    case 'p':
        pasajeros=random(5,10);
        desabordaje=1;
        mantenimiento=random(1,3);
        break;
    case 'm':
        pasajeros=random(15,25);
        desabordaje=2;
        mantenimiento=random(2,4);
        break;
    case 'g':
        pasajeros=random(30,40);
        desabordaje=3;
        mantenimiento=random(3,6);
        break;
    default:
        break;
    }
}

/*Struct Avion*/

/*Struct Estacion*/
Estacion::Estacion(int nombre)
{
    this->nombre=nombre;
    en_mantenimiento=nullptr;
    estado=false;
    turnos_restantes=0;

}

void Estacion::ingresarAvion(Avion *nuevo)
{
    en_mantenimiento=nuevo;
    estado=true;
    turnos_restantes=nuevo->mantenimiento;
}

void Estacion::pasarTurno()
{
    if(estado==true){
        --turnos_restantes;
        if(turnos_restantes==0){
            en_mantenimiento=nullptr;
            estado=false;
        }
    }
}
/*Struct Estacion*/


/*Struct Mantenimiento*/
Mantenimiento::Mantenimiento(int no_estaciones)
{
    lista_estacion=new Lista<Estacion*>();
    aviones_en_espera=new Cola<Avion*>();
    setEstaciones(no_estaciones);
}

void Mantenimiento::encolarAvion(Avion *nuevo)
{
    aviones_en_espera->enColar(nuevo);
}

void Mantenimiento::pasarTurno()
{
    turnosEstaciones();//primero pasa el turno de las estaciones
    movilizarAvion();//y luego movemos los aviones
}


/*Private*/
void Mantenimiento::setEstaciones(int no_estaciones)
{
    int i;
    for(i=0;i<no_estaciones;i++){
        lista_estacion->insertar(new Estacion(i+1));
    }
}

void Mantenimiento::turnosEstaciones()
{
    Nodo<Estacion*> *aux = lista_estacion->raiz;
    while(aux!=nullptr){
        aux->item->pasarTurno();
        aux=aux->siguiente;
    }
}

void Mantenimiento::movilizarAvion()
{
    while(!aviones_en_espera->isEmpty()){//mientras haya aviones en cola
        Estacion *aux;
        int fin = lista_estacion->cant;
        int i;
        for(i=0;i<fin;i++){//revisamos por una estacion vacia
            aux=lista_estacion->get(i);
            if(aux->estado==false)//si la encontramos salimos del ciclo
                break;
        }
        if(aux->estado==false)//si obtuvimos una estacion vacia
            aux->ingresarAvion(aviones_en_espera->desEncolar());//ingresamos el avion correspondiente
        else//si al final, no hay estaciones vacias pero aún hay aviones en cola
            break;//terminamos el while, porque ya no hay espacios disponibles
    }
}


/*Private*/


/*Struct Mantenimiento*/




