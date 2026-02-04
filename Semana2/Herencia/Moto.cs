using System;

namespace Herencia;

public class Moto : Vehiculo
{
    public bool TieneCasco;
    public Moto(string marca, bool tieneCasco)
    {
        Marca = marca;
        TieneCasco = tieneCasco;
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"Marca: {Marca}, Tiene Casco: {TieneCasco}");
    }
   
    
}
