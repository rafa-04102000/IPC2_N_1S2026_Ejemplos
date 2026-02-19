using System;

namespace EjemploP1;

public class Tablero
{
    public string Nombre;

    public int NumeroPeriodos;

    public int TamanoRejilla;
    // esto es una matriz, la rejilla es una matriz
    public Rejilla PatronInicial;

    public Tablero Siguiente;

    public Tablero Anterior;

    public Tablero(string nombre, int numeroPeriodos, int tamanoRejilla)
    {
        Nombre = nombre;
        NumeroPeriodos = numeroPeriodos;
        TamanoRejilla = tamanoRejilla;
        PatronInicial = null;
        Siguiente = null;
        Anterior = null;
    }
}
