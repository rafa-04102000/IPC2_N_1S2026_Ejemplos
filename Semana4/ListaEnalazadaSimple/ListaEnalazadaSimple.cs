using System;
using EjListaEnalazadaSimple;

namespace EjListaEnalazadaSimple;

public class ListaEnalazadaSimple
{
    // Por defecto va a ser null, lo que indica que la lista está vacía
    public Nodo Raiz;


    public void append(Nodo nuevoNodo)
    {
        if (Raiz == null)
        {
            Raiz = nuevoNodo;
        }
        else
        {
            Nodo nodoActual = Raiz;
            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
            }
            nodoActual.Siguiente = nuevoNodo;
        }
    }

    public void print()
    {
        Nodo nodoActual = Raiz;
        while (nodoActual != null)
        {
            Console.WriteLine($"Título: {nodoActual.Pelicula.Titulo}, Director: {nodoActual.Pelicula.Director}, Año: {nodoActual.Pelicula.Anio}");
            nodoActual = nodoActual.Siguiente;
        }
    }

    public void pop()
    {
        if (Raiz == null)
        {
            Console.WriteLine("La lista está vacía, no se puede eliminar ningún nodo.");
        }

        if (Raiz.Siguiente == null)
        {
            Raiz = null;
            return;
        }
        // el garbage collector se encarga de eliminar el nodo que ya no tiene referencias

        Nodo nodoActual = Raiz;
        // buscamos el penúltimo nodo, para que el último nodo quede sin referencias y sea eliminado por el garbage collector
        while (nodoActual.Siguiente.Siguiente != null)
        {
            nodoActual = nodoActual.Siguiente;
        }
        nodoActual.Siguiente = null;
    }
}
