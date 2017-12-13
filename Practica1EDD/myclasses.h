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
    Mantenimiento(int no_estaciones);
    Lista<Estacion*> *lista_estacion;
    Cola<Avion*> *aviones_en_espera;
    void encolarAvion(Avion *nuevo);
    void pasarTurno();
private:
    void setEstaciones(int no_estaciones);
    void turnosEstaciones();
    void movilizarAvion();
};



#endif // MYCLASSES_H
