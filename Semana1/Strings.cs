
namespace Strings1;

public class Strings
{
    public void ejecutar()
    {
        // Strings en C#

        string saludo = "Hola";
        string nombre = "Rafael";

        // Concatenación
        string mensajeCompleto = saludo + ", " + nombre + "!";
        Console.WriteLine(mensajeCompleto);

        // Interpolación de cadenas
        string mensajeInterpolado = $"{saludo}, {nombre}!";
        Console.WriteLine(mensajeInterpolado);

        // Métodos comunes de strings
        Console.WriteLine("Longitud del saludo: " + saludo.Length);
        Console.WriteLine("Saludo en mayúsculas: " + saludo.ToUpper());
        Console.WriteLine("Saludo en minúsculas: " + saludo.ToLower());
        Console.WriteLine("¿El saludo contiene 'la'? " + saludo.Contains("la"));
        Console.WriteLine("Índice de 'a' en nombre: " + nombre.IndexOf('a'));
        Console.WriteLine("Reemplazar 'Rafael' por 'Mundo': " + mensajeCompleto.Replace("Rafael", "Mundo"));
    }
}
