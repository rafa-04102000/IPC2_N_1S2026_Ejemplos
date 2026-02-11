using System;

// Para usar XPathNavigator, necesitamos el namespace System.Xml.XPath
using System.Xml.XPath;

namespace Semana3;

public class EjemploXPathNavigator
{
    // XPathNavigator es parte de System.Xml.XPath, que se utiliza para navegar y consultar XML utilizando expresiones XPath. Es útil para consultas complejas, pero no es tan fácil de usar como XDocument para la creación y manipulación de XML.
    // Es una API especializada para consultas XPath, no es tan facil de usar como XDocument para la creación y manipulación de XML, pero es muy potente para consultas complejas.
    // Es el mas complejo y solo seria necesario si necesitamos hacer consultas XPath muy complejas, pero para la mayoría de los casos, XDocument es suficiente y mucho mas facil de usar.
    // Con XPathNavigator, segun indican no es tanto para crear o modificar XML, sino mas bien para navegar y consultar XML de manera eficiente, especialmente cuando se trabaja con documentos XML grandes o complejos. Para la creación y manipulación de XML, XDocument es generalmente más fácil de usar y más adecuado.

    private string rutaArchivo = "EjemplosXML/tienda_compleja.xml";

    public void Ejecutar()
    {
        if (!File.Exists(rutaArchivo))
        {
            Console.WriteLine("¡Error! No encontré el archivo tienda_compleja.xml");
            return;
        }

        // 1. Cargar el documento en modo solo lectura (Optimizado)
        XPathDocument doc = new XPathDocument(rutaArchivo);
        XPathNavigator nav = doc.CreateNavigator();

        Console.WriteLine("--- ANÁLISIS DE TIENDA CON XPATH ---");

        // --- CASO 1: Filtrado Lógico Complejo ---
        // "Dame los productos que sean 'Procesador' Y que estén en 'oferta'"
        Console.WriteLine("\n1. Procesadores en Oferta:");

        XPathNodeIterator iterador = nav.Select("//Producto[@categoria='Procesador' and @oferta='true']/Nombre");

        while (iterador.MoveNext())
        {
            Console.WriteLine($"   -> {iterador.Current?.Value}");
        }

        // --- CASO 2: Matemáticas en el XML (Valor del Inventario) ---
        // ¿Cuánto dinero tengo en total en GPUs? (Precio * Stock de cada una)
        // Nota: XPath 1.0 no soporta multiplicacion de arrays directos, asi que iteramos
        Console.WriteLine("\n2. Valor total del inventario de Gráficas (Precio * Stock):");

        XPathNodeIterator graficas = nav.Select("//Producto[@categoria='Grafica']");
        double totalGraficas = 0;

        while (graficas.MoveNext())
        {
            // Movemos el cursor relativo al nodo actual
            double precio = double.Parse(graficas.Current.SelectSingleNode("Precio")?.Value ?? "0");
            int stock = int.Parse(graficas.Current.SelectSingleNode("Stock")?.Value ?? "0");
            totalGraficas += (precio * stock);
        }
        Console.WriteLine($"   -> Total invertido en GPUs: ${totalGraficas}");

        // --- CASO 3: Búsqueda por Valor Numérico (Range) ---
        // "Dame productos con precio mayor a 500 USD"
        Console.WriteLine("\n3. Productos de Gama Alta (> $500):");

        XPathNodeIterator caros = nav.Select("//Producto[Precio > 500]");

        while (caros.MoveNext())
        {
            string nombre = caros.Current.SelectSingleNode("Nombre")?.Value ?? "";
            string precio = caros.Current.SelectSingleNode("Precio")?.Value ?? "";
            Console.WriteLine($"   -> {nombre} (${precio})");
        }

        // --- CASO 4: Función de Agregación (Count) ---
        // Contar cuántos productos tienen stock crítico (menos de 5 unidades)
        Console.WriteLine("\n4. Alertas de Stock Bajo (< 5 unidades):");

        // La función count() devuelve un número directamente
        double cantidadCritica = (double)nav.Evaluate("count(//Producto[Stock < 5])");

        Console.WriteLine($"   -> Hay {cantidadCritica} productos con stock crítico.");
    }

}
