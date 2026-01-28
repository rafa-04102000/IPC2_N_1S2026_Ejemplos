using System;

namespace Funciones1;

public class Funciones
{
    public void ejecutar()
    {
        // Funciones en C#

        void Saludar(string nombre)
        {
            Console.WriteLine("Hola, " + nombre + "!");
        }

        // LLamada a metodo
        Saludar("Rafael");


        int Sumar(int x, int y)
        {
            return x + y;
        }
        // Llamada a funcion
        int resultado = Sumar(5, 3);
        Console.WriteLine("La suma es: " + resultado);


        // Las funciones devuelven valores (tipo de retorno al inicio)
        // Los meotods no devuelven valores (void)
    }
}
