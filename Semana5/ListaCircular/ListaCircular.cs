using System;

namespace EjListaCircular;

public class ListaCircular
{
    public Nodo Raiz;

    public void append(Nodo nuevoNodo)
    {
        if (Raiz == null)
        {
            Raiz = nuevoNodo;
            Raiz.Siguiente = Raiz; // Apunta a sí mismo para formar el círculo
        }
        else
        {
            Nodo actual = Raiz;
            while (actual.Siguiente != Raiz)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo; // El último nodo apunta al nuevo nodo
            nuevoNodo.Siguiente = Raiz; // El nuevo nodo apunta a la raíz para cerrar el círculo
        }
    }

    public void print()
    {
        if (Raiz == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo actual = Raiz;
        do
        {
            Console.WriteLine($"Título: {actual.Libro.Titulo}, Autor: {actual.Libro.Autor}");
            actual = actual.Siguiente;
        } while (actual != Raiz);
    }   
}
