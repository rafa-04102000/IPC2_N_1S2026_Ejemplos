using System;
using System.Reflection.Metadata;


// Para usar XmlDocumment, necesitamos el namespace System.Xml
// Opcion clasica Legacy con W3C DOM
using System.Xml;

namespace Semana3;

public class EjemploXmlDocument
{

    // XmlDocument es parte de System.Xml, que es la API tradicional para trabajar con XML en C#. Es más verbosa y menos intuitiva que XDocument, pero sigue siendo ampliamente utilizada, especialmente en proyectos más antiguos.
    // Opcion clascia Legacy con W3C DOM (System.Xml)
    // Es mas antiguo, mas verboso y con menor rendimiento que XDocument
    public void CrearDocumento()
    {

        XmlDocument doc = new XmlDocument();

        // Declaracion
        XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        XmlElement root = doc.DocumentElement;
        doc.InsertBefore(xmlDeclaration, root);

        // Elemento Raiz
        XmlElement elemntoRaiz = doc.CreateElement("Biblioteca");
        doc.AppendChild(elemntoRaiz);

        // Crear un elemento hijo
        XmlElement libro = doc.CreateElement("Libro");
        libro.SetAttribute("id", "1");

        XmlElement titulo = doc.CreateElement("Titulo");
        titulo.InnerText = "El Quijote";
        libro.AppendChild(titulo);

        XmlElement autor = doc.CreateElement("Autor");
        autor.InnerText = "Miguel de Cervantes";
        libro.AppendChild(autor);

        // Agregar al elemento raiz, que en este caso sera la biblioteca
        elemntoRaiz.AppendChild(libro);

        // Guardar el documento
        // EjemplosXML/nombreArchivo.xml
        doc.Save("EjemplosXML/biblioteca.xml");
    }

    public void LeerDocumento()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("EjemplosXML/biblioteca.xml");

        // Obtener el elemento raiz
        XmlElement raiz = doc.DocumentElement;

        // Recorrer los elementos hijo (libros)
        foreach (XmlNode libro in raiz.ChildNodes)
        {
            string id = libro.Attributes["id"].Value;
            string titulo = libro["Titulo"].InnerText;
            string autor = libro["Autor"].InnerText;

            Console.WriteLine($"ID: {id}, Titulo: {titulo}, Autor: {autor}");
        }
    }
}
