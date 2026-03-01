using System;

namespace EjListaDoblementeCircular;

public class ListaDoblementeCircular
{
    public Nodo Raiz;
    public Nodo Ultimo;

    public void append(Nodo nuevoNodo)
    {
        if (Raiz == null)
        {
            Raiz = nuevoNodo;
            Ultimo = nuevoNodo;
            nuevoNodo.Siguiente = Raiz;
            nuevoNodo.Anterior = Ultimo;
        }
        else
        {
            // el ! se utiliza para indicar que estamos seguros de que Ultimo no es nulo en este punto del código. Esto es necesario porque el compilador de C# no puede determinar si Ultimo podría ser nulo o no, y sin el !, el compilador generaría un error de compilación al intentar acceder a la propiedad Siguiente de Ultimo.

            Ultimo!.Siguiente = nuevoNodo;
            nuevoNodo.Anterior = Ultimo;
            Ultimo = nuevoNodo;
            Ultimo.Siguiente = Raiz;
            Raiz.Anterior = Ultimo;
        }
    }

        public void print()
    {
        if (Raiz == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo? actual = Raiz;
        do
        {
            Console.WriteLine($"Título: {actual?.Libro.Titulo}, Autor: {actual?.Libro.Autor}, Año: {actual?.Libro.AnioPublicacion}");
            actual = actual.Siguiente;
        } while (actual != Raiz);
    }
}
