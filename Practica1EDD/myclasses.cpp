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
Mantenimiento::Mantenimiento()
{
    lista_estacion=new Lista<Estacion*>();
    aviones_en_espera=new Cola<Avion*>();
    //setEstaciones(no_estaciones);
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

void Mantenimiento::clear()
{
    lista_estacion->clear();
    aviones_en_espera->clear();
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
    if(lista_estacion->isEmpty())
        return;
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




/*Struct Pasajero*/
Pasajero::Pasajero(int nombre)
{
    id=nombre;
    maletas=random(1,4);
    registro=random(1,3);
    documentos=random(1,10);
}

/*Struct Pasajero*/


/*Struct Estcritorio*/
Escritorio::Escritorio(char nombre)
{
    this->nombre=nombre;
    cola_pasajeros=new Cola<Pasajero*>;
    pila_documentos=new Pila<int>;
    en_recepcion=nullptr;
    cantidad_documentos=0;
    turnos_restantes=0;
    estado=false;

}

void Escritorio::clearAll()
{
    cola_pasajeros->clear();
    pila_documentos->clear();
}


void Escritorio::pasarTurno()
{    if(estado==true){
        --turnos_restantes;
        if(turnos_restantes==0){
            en_recepcion=nullptr;//saco al que esta en recepcion
            /*aqui iria por sus maletas*/
            pila_documentos->clear();//limpio la pila de documentos
            estado=false;//reseteo el estado
            pasarPasajero();//si hay pasajero en cola, lo paso
        }
     }else
        pasarPasajero();

}

/*Private*/
void Escritorio::pasarPasajero()
{
    if(!cola_pasajeros->isEmpty()){
       en_recepcion=cola_pasajeros->desEncolar();
       cantidad_documentos=en_recepcion->documentos;
       turnos_restantes=en_recepcion->registro;
       agregarDocumentos(cantidad_documentos);
       estado=true;
    }
}


void Escritorio::agregarDocumentos(int cantidad)
{
    int i;
    for(i=0;i<cantidad;i++){
        pila_documentos->push(i+1);
    }
}

/*Struct Estcritorio*/


/*Struct Lista Ordenada Doble*/
ListaO::ListaO()
{
    raiz=nullptr;
    cant=0;
}

void ListaO::insertar(Escritorio *item)
{
    Nodo<Escritorio*> *nuevo = new Nodo<Escritorio*>(item);
    if(isEmpty())
        raiz=nuevo;
    else{
        if(nuevo->item->nombre>raiz->item->nombre){//el nuevo va antes de la raiz
            nuevo->siguiente=raiz;
            raiz->anterior=nuevo;
            raiz=nuevo;
        }else
            insertar(raiz,raiz->siguiente,nuevo);
    }
    ++cant;
}

Escritorio *ListaO::get(int posicion)
{
    if(posicion>cant||posicion<0)
        return 0;
    Nodo<Escritorio*> *aux = raiz;
    int i;
    for(i=0;i<posicion;i++){
        aux=aux->siguiente;
    }
    return aux->item;
}

void ListaO::clear()
{
    while(!isEmpty()){
        Nodo<Escritorio*> *aux = raiz;
        raiz->item->clearAll();
        raiz=raiz->siguiente;
        delete aux;
        --cant;
    }
}

bool ListaO::isEmpty()
{
    return raiz==nullptr;
}

/*private*/
void ListaO::insertar(Nodo<Escritorio *> *actual, Nodo<Escritorio *> *siguiente, Nodo<Escritorio *> *nuevo)
{
    if(siguiente==nullptr){//llegue al final de la lista
        actual->siguiente=nuevo;
        nuevo->anterior=actual;
    }else if(nuevo->item->nombre>siguiente->item->nombre){//nuevo va antes de siguiente
        actual->siguiente=nuevo;
        nuevo->anterior=actual;
        nuevo->siguiente=siguiente;
        siguiente->anterior=nuevo;
    }else
        insertar(siguiente,siguiente->siguiente,nuevo);

}



/*Struct Lista Ordenada*/


/*Struct Registro*/
Registro::Registro()
{
    lista_escritorios=new ListaO();
}

void Registro::pasarTurno(Cola<Pasajero *> *pasajeros_desabordando)
{
    pasarTurnoEscritorios();
    moverColaPasajeros(pasajeros_desabordando);
}

void Registro::setEscritorios(int cantidad)
{
    int i;
    for(i=0;i<cantidad;i++){
        lista_escritorios->insertar(new Escritorio(i+65));
    }
}

void Registro::clear()
{
    lista_escritorios->clear();
}

/*private*/
void Registro::moverColaPasajeros(Cola<Pasajero*> *pasajeros_desabordando)
{
    Nodo<Escritorio*> *aux=lista_escritorios->raiz;
    Escritorio* actual;
    while(aux!=nullptr){//si hay escritorios disponibles
        actual=aux->item;//escritorio actual
        if(pasajeros_desabordando->isEmpty())//si no hay pasajeros desabordando
            break;
        else if(actual->cola_pasajeros->isFull())//si su cola esta llena
            aux=aux->siguiente;
        else//si la cola esta disponible
            actual->cola_pasajeros->enColar(pasajeros_desabordando->desEncolar());
        /*no meto un ciclo, porque el while puede volver a revisar el mismo escritorio
        las veces necesarias y me ahorro codigo*/
    }
}

void Registro::pasarTurnoEscritorios()
{
    Nodo<Escritorio*> *aux=lista_escritorios->raiz;
    while(aux!=nullptr){//si hay escritorios disponibles
        aux->item->pasarTurno();
        aux=aux->siguiente;
    }
}

/*Struct Registro*/


