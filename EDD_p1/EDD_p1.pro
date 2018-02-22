#-------------------------------------------------
#
# Project created by QtCreator 2018-02-09T10:15:14
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = EDD_p1
TEMPLATE = app

# The following define makes your compiler emit warnings if you use
# any feature of Qt which has been marked as deprecated (the exact warnings
# depend on your compiler). Please consult the documentation of the
# deprecated API in order to know how to port your code away from it.
DEFINES += QT_DEPRECATED_WARNINGS

# You can also make your code fail to compile if you use deprecated APIs.
# In order to do so, uncomment the following line.
# You can also select to disable deprecated APIs only up to a certain version of Qt.
#DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0


SOURCES += \
        main.cpp \
        principal.cpp \
    Objetos/producto.cpp \
    manejojson.cpp \
    grafica.cpp \
    Objetos/cliente.cpp \
    Objetos/factura.cpp \
    Objetos/item.cpp \
    rendimiento.cpp

HEADERS += \
        principal.h \
    Estructuras/lista.h \
    Estructuras/listac.h \
    Estructuras/pila.h \
    Nodos/nodo.h \
    Nodos/nodo_def.h \
    Nodos/nodo_s_def.h \
    Nodos/nodo_s.h \
    Estructuras/pila_def.h \
    Estructuras/listac_def.h \
    Estructuras/lista_def.h \
    Objetos/producto.h \
    manejojson.h \
    grafica.h \
    Objetos/cliente.h \
    Objetos/factura.h \
    Objetos/item.h \
    rendimiento.h

FORMS += \
        principal.ui
