#ifndef MYCLASSES_H
#define MYCLASSES_H
#include <cstdlib>
#include <ctime>
#include "mystructs.h"

int random(int min, int max);

struct Avion
{
    Avion(int nombre);
    char tipo;
    int nombre;
    int pasajeros;
    int desabordaje;
    int mantenimiento;
private:
    void setTipo();
    void setTurnos(char tipo);
};

struct Estacion
{
    Estacion(int nombre);
    int nombre;
    Avion *en_mantenimiento;
    bool estado;
    int turnos_restantes;
    void ingresarAvion(Avion *nuevo);
    void pasarTurno();
};

struct Mantenimiento
{
    Mantenimiento();
    Lista<Estacion*> *lista_estacion;
    Cola<Avion*> *aviones_en_espera;
    void encolarAvion(Avion *nuevo);
    void pasarTurno();
    void clear();
    void setEstaciones(int no_estaciones);
private:
    void turnosEstaciones();
    void movilizarAvion();
};

struct Pasajero
{
    Pasajero(int nombre);
    int id;
    int maletas;
    int registro;
    int documentos;

};

struct Escritorio
{
    Escritorio(char nombre);
    char nombre;
    Cola<Pasajero*> *cola_pasajeros;
    Pila<int> *pila_documentos;
    Pasajero *en_recepcion;
    int cantidad_documentos;
    int turnos_restantes;
    bool estado;
    void clearAll();
    void pasarTurno(ListaDC<int> *maletas);
private:
    void pasarPasajero();
    void agregarDocumentos(int cantidad);
    void recogerMaletas(int cantidad,ListaDC<int> *maletas);

};


struct ListaO
{
    ListaO();
    Nodo<Escritorio*> *raiz;
    int cant;
    void insertar(Escritorio* item);
    Escritorio *get(int posicion);
    //Objeto removeTop();
    void clear();
    bool isEmpty();
    //void eliminar(int posicion);
private:
    void insertar(Nodo<Escritorio*> *actual,Nodo<Escritorio*> *siguiente,Nodo<Escritorio*> *nuevo);
};

struct Registro
{
    Registro();
    ListaO *lista_escritorios;
    void pasarTurno(Cola<Pasajero*> *pasajeros_desabordando,ListaDC<int> *maletas);//maletas nuevas
    void setEscritorios(int cantidad);
    void clear();
private:
    void moverColaPasajeros(Cola<Pasajero*> *pasajeros_desabordando);
    void pasarTurnoEscritorios(ListaDC<int> *maletas);//nuevo
};

#endif // MYCLASSES_H
