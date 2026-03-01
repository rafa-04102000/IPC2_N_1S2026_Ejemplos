using System;

namespace EjListaDoblementeCircular;

public class Nodo
{
    public Libro Libro;
    public Nodo? Siguiente;
    public Nodo? Anterior;

    public Nodo(Libro libro)
    {
        Libro = libro;
        Siguiente = null;
        Anterior = null;
    }
}
