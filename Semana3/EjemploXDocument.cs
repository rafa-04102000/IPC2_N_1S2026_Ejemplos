using System;

// Para usa XDocument, necesitamos el namespace System.Xml.Linq
using System.Xml.Linq;

namespace Semana3;

public class EjemploXDocument
{

    // XDocument es parte de System.Xml.Linq, que es una API moderna para trabajar con XML en C#. Es más fácil de usar y tiene soporte para LINQ, lo que facilita la consulta y manipulación de XML.
    // Es lo mas moderno, mas facil y con mayor dendimiento 

    public void CrearDocumento()
    {
        // Construcción funcional (Functional Construction)
        
        XDocument doc = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"), // opcional, pero recomendado para especificar la versión y codificación
            new XComment("This is a comment"),
            new XElement("Biblioteca",
                new XElement("Libro", new XAttribute("id", "1"),
                    new XElement("Titulo", "El Principito"),
                    new XElement("Autor", "Antoine de Saint-Exupéry")
                ),
                new XElement("Libro", new XAttribute("id", "2"),
                    new XElement("Titulo", "1984"),
                    new XElement("Autor", "George Orwell")
                )
            )
        );

        doc.Save("EjemplosXML/XDocument.xml");
    }

    public void LeerDocumento(string rutaArchivo)
    {
        if (!File.Exists(rutaArchivo))
        {
            Console.WriteLine("Archivo no encontrado. Por favor, verifique la ruta y el nombre del archivo.");
            return;
        }

        XDocument doc = XDocument.Load(rutaArchivo);

        var libros = from libro in doc.Descendants("Libro")
                     select new
                     {
                         Id = libro.Attribute("id")?.Value,
                         Titulo = libro.Element("Titulo")?.Value,
                         Autor = libro.Element("Autor")?.Value
                     };

        foreach (var libro in libros)
        {
            Console.WriteLine($"ID: {libro.Id}, Título: {libro.Titulo}, Autor: {libro.Autor}");
        }
    }

}
