using System;

namespace Polimorfismo;
// Polimorfismo (El "CÓMO") Es una mecánica de ejecución. Se trata de identidad. Permite que un Perro se haga pasar por un Animal en una lista, pero cuando le digas "Habla", ladre como perro.

// Objetivo: Tratar a objetos diferentes de la misma manera genérica.
public class Animal
{
    // 'virtual' permite que este método sea sobrescrito en clases derivadas
    public virtual void HacerSonido()
    {
        Console.WriteLine("El animal hace un sonido.");
    }
}
