using System;

namespace Iteraciones1;

public class Iteraciones
{

    public void ejecutar()
    {
        // Ejemplo de Iteraciones en C#

        // Bucle For
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Iteración For: " + i);
        }

        // Bucle While
        int contadorWhile = 0;
        while (contadorWhile < 5)
        {
            Console.WriteLine("Iteración While: " + contadorWhile);
            contadorWhile++;
        }

        // Bucle Do-While
        int contadorDoWhile = 0;
        do
        {
            Console.WriteLine("Iteración Do-While: " + contadorDoWhile);
            contadorDoWhile++;
        } while (contadorDoWhile < 5);

        // Bucle Foreach
        string[] frutas = { "Manzana", "Banana", "Cereza" };
        foreach (string fruta in frutas)
        {
            Console.WriteLine("Fruta: " + fruta);
        }
    }
}
