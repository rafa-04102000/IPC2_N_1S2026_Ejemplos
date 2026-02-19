using System;

namespace EjemploP1;

public class Tableros
{

    public Tablero Raiz;

    public void append(Tablero nuevoTablero)
    {
        if (Raiz == null)
        {
            Raiz = nuevoTablero;
        }
        else
        {
            Tablero? actual = Raiz;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoTablero;
            nuevoTablero.Anterior = actual;
        }
    }

    public void print()
    {
        Tablero? aux = Raiz;
        string cadena = "";

        while (aux != null)
        {
            cadena += $"Tablero: {aux.Nombre} con {aux.NumeroPeriodos} periodos y tamaño {aux.TamanoRejilla}x{aux.TamanoRejilla}\n";
            aux = aux.Siguiente;
        }

        Console.WriteLine(cadena);
    }
    public Tablero? buscarTablero(string nombre)
    {
        Tablero? aux = Raiz;

        while (aux != null)
        {
            if (aux.Nombre == nombre)
            {
                return aux;
            }
            aux = aux.Siguiente;
        }
        return null;
    }

}
