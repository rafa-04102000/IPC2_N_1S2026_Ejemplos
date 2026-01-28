
namespace Variables1;

public class Variables
{

    public void ejecutar()
    {
        // Variables en C#   

        // Vairables Enteras
        int numero1 = 10;
        Console.WriteLine("Valor de Numero1: " + numero1);

        // Variables de Punto Flotante
        float numero2 = 20.5f;
        Console.WriteLine("Valor de Numero2: " + numero2);

        // Variables de Doble Precisión
        double numero3 = 30.75;
        Console.WriteLine("Valor de Numero3: " + numero3);

        // Variables de Texto o Strings
        string mensaje = "Hola, Mundo!";
        Console.WriteLine("Valor de Mensaje: " + mensaje);

        // Listas en C#

        List<int> lista = new List<int> { 1, 2, 3, 4, 5 };
        Console.WriteLine("La variable 'lista' es de tipo: " + lista.GetType());
        Console.WriteLine("Contenido de 'lista': ", lista);
        Console.WriteLine(string.Join(", ", lista));
        Console.WriteLine("Contenido en posicion 2: " + lista[2]);

        // Agregar elementos a la lista
        lista.Add(6);
        Console.WriteLine("Contenido de 'lista' despues de agregar un elemento: " + string.Join(", ", lista));


        // Tuplas en C#
        (int, string, float) tupla = (1, "Ejemplo", 3.14f);
        Console.WriteLine("La variable 'tupla' es de tipo: " + tupla.GetType());
        Console.WriteLine("Contenido de 'tupla': " + tupla);
        Console.WriteLine("Contenido en posicion 1 de la tupla: " + tupla.Item1);


        // Diccionarios en C#
        Dictionary<string, int> diccionario = new Dictionary<string, int>
        {
            { "Uno", 1 },
            { "Dos", 2 },
            { "Tres", 3 }
        };
        Console.WriteLine("La variable 'diccionario' es de tipo: " + diccionario.GetType());
        Console.WriteLine("Contenido de 'diccionario': ");
        foreach (var item in diccionario)
        {
            Console.WriteLine(item.Key + ": " + item.Value);
        }
        
        // Agregar un elemento al diccionario
        diccionario["Cuatro"] = 4;
        Console.WriteLine("Contenido de 'diccionario' despues de agregar un elemento: ");
        foreach (var item in diccionario)
        {
            Console.WriteLine(item.Key + ": " + item.Value);
        }

        // Arreglos en C#
        int[] arreglo = { 10, 20, 30, 40, 50 };
        Console.WriteLine("La variable 'arreglo' es de tipo: " + arreglo.GetType());
        Console.WriteLine("Contenido de 'arreglo': " + string.Join(", ", arreglo));
        Console.WriteLine("Contenido en posicion 3 del arreglo: " + arreglo[3]);

        // La diferencia entre Arreglos y Listas es que los arreglos tienen un tamaño fijo, mientras que las listas pueden crecer o reducir su tamaño dinámicamente.

        // valor nulo
        string valorNulo = null;
        Console.WriteLine("Valor de valorNulo: " + valorNulo);
    }
}
