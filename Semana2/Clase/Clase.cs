using System;

namespace Clase1;

public class Clase
{
    // Atributos
    public string nombre;
    public int edad;

    // Constructor
    public Clase()
    {
        nombre = "Lucas";
        edad = 25;
    }

    // Constructor con sobrecarga
    public Clase(string nombre, int edad)
    {
        this.nombre = nombre;
        this.edad = edad;
    }

    // Metodos

    public void MostrarDatos()
    {
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Edad: " + edad);
    }


    // Funciones
    public int SumarEdades(int edadAdicional)
    {
        return edad + edadAdicional;
    }
}
