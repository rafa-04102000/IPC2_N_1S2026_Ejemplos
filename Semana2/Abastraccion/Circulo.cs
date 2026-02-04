using System;

namespace Abastraccion;

public class Circulo : Figura
{
    public double Radio;

    public Circulo(double radio)
    {
        Radio = radio;
    }

    // Tenemos que usar el override porque es un método abstracto

    public override double CalcularArea()
    {
        Console.WriteLine("Calculando el área del círculo...");
        // Console.WriteLine(Radio*Radio);
        return Math.PI * Radio * Radio;
    }

}
