using System;

namespace EjListaCircular;

public class Nodo
{
    public Libro Libro;
    public Nodo? Siguiente;

    public Nodo(Libro libro)
    {
        Libro = libro;
        Siguiente = null;
    }
}
