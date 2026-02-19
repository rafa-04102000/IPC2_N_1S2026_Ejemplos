using System;
using System.Diagnostics;
using System.IO;   

namespace EjemploP1;

public class Rejilla
{
    public Casilla Raiz;

    public int NumeroPeriodo;

    public int TamanoRejilla;

    public Rejilla(int numeroPeriodo, int tamanoRejilla)
    {
        NumeroPeriodo = numeroPeriodo;
        TamanoRejilla = tamanoRejilla;
        Raiz = null;
    }   

    public void append(Casilla nuevaCasilla)
    {
        if (Raiz == null)
        {
            Raiz = nuevaCasilla;
        }
        else
        {
            Casilla? actual = Raiz;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevaCasilla;
            nuevaCasilla.Anterior = actual;
        }
    }

    // Print de la Rejilla
    public void printRejilla()
    {
        Casilla aux = Raiz;
        string cadena = "";

        for (int fila=1; fila <= TamanoRejilla; fila++)
        {
            for (int columna=1; columna <= TamanoRejilla; columna++)
            {
                if (columna == TamanoRejilla)
                {
                    cadena += $"{aux.Condicion}";
                    aux = aux.Siguiente;
                }
                else
                {
                    cadena += $"{aux.Condicion} ";
                    aux = aux.Siguiente;   
                }
            }
            Console.WriteLine(cadena);
            cadena = "";
        }

    }


}
