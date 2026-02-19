using System;


namespace EjListaEnalazadaSimple;

public class Nodo
{
    public Pelicula Pelicula;

    public Nodo? Siguiente;

    public Nodo(Pelicula pelicula)
    {
        Pelicula = pelicula;
        Siguiente = null;
    }
}
