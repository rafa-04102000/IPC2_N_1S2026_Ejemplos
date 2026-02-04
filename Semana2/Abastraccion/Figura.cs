using System;

namespace Abastraccion;

// Abstracción (El "QUÉ"): Es una estrategia de diseño. Se trata de simplificar la realidad. Al crear una clase abstracta Animal, estás diciendo: 
// "En mi mundo existen animales, pero el concepto 'Animal' es solo una idea, no puedes comprar un 'Animal' genérico en la tienda, tienes que comprar un Perro o un Gato".
// Objetivo: Definir un molde base y esconder la complejidad.
public abstract class Figura
{

    // Para que sea obligatoria, tiene que tener abstract
    public abstract double CalcularArea();

    // Método común para todas las figuras
    public void MostrarArea()
    {
        Console.WriteLine($"El área es: {CalcularArea()}");
    }
}
