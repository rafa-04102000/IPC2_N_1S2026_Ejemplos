using System;

namespace EjListaDoblementeEnlazada;

public class ListaDoblementeEnlazada
{
    public Nodo2 Raiz;


    public void append(Nodo2 nuevoNodo)
    {
        if (Raiz == null)
        {
            Raiz = nuevoNodo;
        }
        else
        {
            Nodo2 nodoActual = Raiz;
            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
            }
            nodoActual.Siguiente =nuevoNodo; // hacia adelante
            nuevoNodo.Anterior = nodoActual; // hacia atras
        }

    }

    public void printAdelante()
    {
        Nodo2 nodoActual = Raiz;
        while (nodoActual != null)
        {
            Console.WriteLine($"Titulo: {nodoActual.Libro.Titulo}, Autor: {nodoActual.Libro.Autor}, Año: {nodoActual.Libro.Anio}");
            nodoActual = nodoActual.Siguiente;
        }
    }

    public void printAtras()
    {
        Nodo2 nodoActual = Raiz;
        if (nodoActual == null)
        {
            return;
        }
        // Ir al último nodo
        while (nodoActual.Siguiente != null)
        {
            nodoActual = nodoActual.Siguiente;
        }
        // Imprimir desde el último nodo hacia atrás
        while (nodoActual != null)
        {
            Console.WriteLine($"Titulo: {nodoActual.Libro.Titulo}, Autor: {nodoActual.Libro.Autor}, Año: {nodoActual.Libro.Anio}");
            nodoActual = nodoActual.Anterior;
        }
    }

    public void pop()
    {
        if (Raiz == null)
        {
            return;
        }
        if (Raiz.Siguiente == null)
        {
            Raiz = null;
            return;
        }
        Nodo2 nodoActual = Raiz;
        while (nodoActual.Siguiente != null)
        {
            nodoActual = nodoActual.Siguiente;
        }
        // nodoActual es el último nodo
        nodoActual.Anterior.Siguiente = null; // El penúltimo nodo ahora es el último
    }
}
