using System;

namespace EjemploP1;

public class Periodo
{
    public Rejilla Rejilla;

    public Periodo? Siguiente;
    public Periodo? Anterior;

    public Periodo(Rejilla rejilla)
    {
        Rejilla = rejilla;
        Siguiente = null;
        Anterior = null;
    }
}
