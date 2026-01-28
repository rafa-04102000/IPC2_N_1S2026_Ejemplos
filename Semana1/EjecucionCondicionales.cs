using System;

namespace EjecucionCondicionales1;

public class EjecucionCondicionales
{
    public void ejecutar()
    {
        // Ejemplo de Ejecución de Condicionales en C#

        int edad = 18;
        if (edad >= 18)
        {
            Console.WriteLine("Eres mayor de edad.");
        }
        else
        {
            Console.WriteLine("Eres menor de edad.");
        }
        

        // Switch
        string dia = "Lunes";
        switch (dia)
        {
            case "Lunes":
                Console.WriteLine("Hoy es lunes.");
                break;
            case "Martes":
                Console.WriteLine("Hoy es martes.");
                break;
            default:
                Console.WriteLine("Es otro día de la semana.");
                break;
                
        }

        // Sentencias con Operadores Lógicos
        bool tieneLicencia = true;
        bool esMayorDeEdad = true;

        // && operador lógico AND
        // || operador lógico OR
        if (tieneLicencia && esMayorDeEdad)
        {
            Console.WriteLine("Puedes conducir.");
        }
        else
        {
            Console.WriteLine("No puedes conducir.");
        }

        // Sentencias con Operadores Relacionales
        int numeroA = 20;
        int numeroB = 20;
        if (numeroA < numeroB)
        {
            Console.WriteLine("Número A es menor que Número B.");
        }
        else if (numeroA > numeroB)
        {
            Console.WriteLine("Número A es mayor que Número B.");
        }
        else
        {
            Console.WriteLine("Número A es igual a Número B.");
        }
    }
}
