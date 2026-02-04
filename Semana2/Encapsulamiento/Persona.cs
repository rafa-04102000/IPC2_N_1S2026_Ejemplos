using System;

namespace Encapsulamiento;

public class Persona
{
    // Modificadores de acceso: public, private, protected
    // public cualquiera puede acceder
    // private solo la misma clase puede acceder
    // protected solo las clases derivadas pueden acceder, como la clase padre y la hija
    
    public string nombre; 

    private int edad;
    public int Edad
    {
        get {return edad; }
        set
        {
            if (value >= 0)
            {
                edad = value;
            }
            else
            {
                Console.WriteLine("Edad no válida");
            }
        }
    }

    // Edad = 1 --> set --> 
    // Edad --> get

    protected string direccion;


    public Persona(string nombre, int edad, string direccion)
    {
        this.nombre = nombre;
        Edad = edad; // Usando la propiedad para validar
        this.direccion = direccion;
    }

    public void MostrarDatos()
    {
        Console.WriteLine($"Nombre: {nombre}, Edad: {Edad}, Dirección: {direccion}");
    }

}
