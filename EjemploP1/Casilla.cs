using System;

namespace EjemploP1;

public class Casilla
{
    public int Fila;
    public int Columna;

    public int Condicion;

    public Casilla Siguiente;

    public Casilla Anterior;

    public Casilla(int fila, int columna, int condicion)
    {
        Fila = fila;
        Columna = columna;
        Condicion = condicion;
        Siguiente = null;
        Anterior = null;
    }


}
