using System;

namespace Abastraccion;

public class Cuadrado : Figura
{
    public double Lado;

    public Cuadrado(double lado)
    {
        Lado = lado;
    }

    public override double CalcularArea()
    {
        Console.WriteLine("Calculando el área del cuadrado...");
        // Console.WriteLine(Lado * Lado);
        return Lado * Lado;
    }
}
