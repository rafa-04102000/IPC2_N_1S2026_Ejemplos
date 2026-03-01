using System;

namespace EjListaDoblementeCircular;

public class Libro
{
    public string Titulo;
    public string Autor;
    public int AnioPublicacion;

    public Libro(string titulo, string autor, int anioPublicacion)
    {
        Titulo = titulo;
        Autor = autor;
        AnioPublicacion = anioPublicacion;
    }
}
