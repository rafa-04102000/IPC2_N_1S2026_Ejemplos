namespace Expresiones1;

public class Expresiones
{
    // Expresiones en C#
    public void ejecutar()
    {
        // Ejemplo de Expresiones Aritméticas
        int a = 10;
        int b = 5;
        int suma = a + b;
        Console.WriteLine("Suma: " + suma);

        // Ejemplo de Expresiones Lógicas
        bool esMayor = a > b;
        Console.WriteLine("¿Es a mayor que b? " + esMayor);

        // Ejemplo de Expresiones Relacionales
        bool esIgual = a == b;
        Console.WriteLine("¿Es a igual a b? " + esIgual);

        // If ternario
        string resultado = (a > b) ? "a es mayor que b" : "a no es mayor que b";
        Console.WriteLine(resultado);

        // F-strings
        Console.WriteLine($"El valor de a es {a} y el valor de b es {b}");

        // Contains
        List<int> numeros = new List<int> { 1, 2, 3, 4, 5 };
        bool contieneTres = numeros.Contains(6);
        Console.WriteLine("¿La lista contiene el número 3? " + contieneTres);
    }
}
