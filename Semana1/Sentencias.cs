
namespace Sentencias1;

public class Sentencias
{
    public void ejecutar()
    {
        // If
        int numero = 10;
        if (numero > 5)
        {
            Console.WriteLine("El número es mayor que 5");
        }

        // If-Else
        if (numero % 2 == 0)
        {
            Console.WriteLine("El número es par");
        }
        else
        {
            Console.WriteLine("El número es impar");
        }

        // Switch
        int dia = 3;
        switch (dia)
        {
            case 1:
                Console.WriteLine("Lunes");
                break;
            case 2:
                Console.WriteLine("Martes");
                break;
            case 3:
                Console.WriteLine("Miércoles");
                break;
            default:
                Console.WriteLine("Otro día");
                break;
        }

        // For
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Iteración: " + i);
        }

        // For de una cadena
        string palabra = "hola";
        for (int i = 0; i < palabra.Length; i++)
        {
            Console.WriteLine("Letra en posición " + i + ": " + palabra[i]);
        }


        // For con una lista
        List<string> frutas = new List<string> { "Manzana", "Banana", "Cereza" };
        for (int i = 0; i < frutas.Count; i++)
        {
            Console.WriteLine("Fruta en posición " + i + ": " + frutas[i]);
        }

        // Foreach
        foreach (var fruta in frutas)
        {
            Console.WriteLine("Fruta: " + fruta);
        }

        // Break y Continue
        for (int i = 0; i < 10; i++)
        {
            if (i == 5)
            {
                Console.WriteLine("Se encontró el número 5, saliendo del ciclo.");
                break;
                Console.WriteLine("Este mensaje no se mostrará.");
            }
            if (i % 2 == 0)
            {
                Console.WriteLine("Número par encontrado, continuando.");
                continue;
                Console.WriteLine("Este mensaje no se mostrará para números pares.");
            }
            Console.WriteLine("Número impar: " + i);
        }
    }
}
