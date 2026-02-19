using System;

namespace EjListaDoblementeEnlazada;

public class Nodo2
{   
    public Libro Libro;

    // este servira para ir hacia adelante 
    public Nodo2? Siguiente;

    // este servira para ir hacia atras
    public Nodo2? Anterior;



    public Nodo2(Libro libro)
    {
        Libro = libro;
        Siguiente = null;
        Anterior = null;
    }
}
