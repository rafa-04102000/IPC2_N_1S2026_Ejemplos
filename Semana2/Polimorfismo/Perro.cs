using System;

namespace Polimorfismo;

public class Perro : Animal
{
    // 'override' indica que estamos sobrescribiendo el método de la clase base
    public override void HacerSonido()
    {
        Console.WriteLine("El perro dice: Guau");
    }
}
