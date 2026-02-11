
using Semana3;

// Para organizar los documentos o imagenes a generar
string nombreCarpeta = "EjemplosXML";
Directory.CreateDirectory(nombreCarpeta);

// Ejemplo con XmlDocument
EjemploXmlDocument ejemplo = new EjemploXmlDocument();
ejemplo.CrearDocumento();
ejemplo.LeerDocumento();


// Ejemplo con XDocument
EjemploXDocument ejemplo2 = new EjemploXDocument();
ejemplo2.CrearDocumento();


// Ejemplo con XPathNavigator
EjemploXPathNavigator ejemplo3 = new EjemploXPathNavigator();
ejemplo3.Ejecutar();