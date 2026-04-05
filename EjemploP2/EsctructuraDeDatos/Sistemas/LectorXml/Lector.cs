// Para usa XDocument, necesitamos el namespace System.Xml.Linq
using EjemploP2.EsctructuraDeDatos.Sistemas.Drones;
using System.Xml.Linq;
using System.Xml.Schema;

namespace EjemploP2.EsctructuraDeDatos.Sistemas.LectorXml
{
    public class Lector
    {
        public void LeerArchivoComoXmlSistemas(IFormFile archivo, ListaDrones listaDronesGlobal)
        {

            // Variables para crear el Sistema de Drones

            // Lista de Sistemas de Drones Global
            // la traigo como parametro

            // SistemaDrones
            //SistemaDrones nuevoSistema = new SistemaDrones("NombrePorDefecto");

            //Lista de Drones Global
            // la traigo como parametro

            // Dron
            //Dron nuevoDron = new Dron("NombreDronPorDefecto");


            //-------------------------------------------------------------------


            // Validamos que el archivo no venga vacío
            if (archivo == null || archivo.Length == 0)
            {
                throw new ArgumentException("No se seleccionó ningún archivo o el archivo está vacío.");
            }

            // Abrimos el flujo de datos en memoria y lo leemos
            using var stream = archivo.OpenReadStream();
            XDocument xmlDoc = XDocument.Load(stream);

            //-------------------------------------------------------------------
            // 1. Cargar el esquema XSD de manera dinámica apuntando a wwwroot/assets
            string rutaXsd = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "EsquemaSistemas.xsd");

            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", rutaXsd);

            // 2. Variables para capturar los errores
            bool formatoCorrecto = true;
            string erroresDeFormato = "";

            // 3. Validar el XML contra el XSD
            xmlDoc.Validate(schemas, (sender, e) =>
            {
                formatoCorrecto = false;
                erroresDeFormato += $"- Error en línea {e.Exception.LineNumber}: {e.Message}\n";
            });

            // 4. Decidir qué hacer si el formato falla
            if (!formatoCorrecto)
            {
                Console.WriteLine("❌ EL XML NO TIENE EL FORMATO CORRECTO:");
                Console.WriteLine(erroresDeFormato);

                // Aquí podrías lanzar una excepción, retornar un BadRequest en tu API, etc.
                throw new FormatException("El archivo XML contiene campos inválidos o no respeta la estructura.\n" + erroresDeFormato);
            }

            Console.WriteLine("✅ El XML tiene el formato perfecto. Procediendo a leer...");
            //-------------------------------------------------------------------


            Console.WriteLine("=========================================");
            Console.WriteLine("        LEYENDO ARCHIVO XML");
            Console.WriteLine("=========================================\n");

            // 1. LECTURA DE LA LISTA DE DRONES
            Console.WriteLine("--- LISTA DE DRONES ---");
            var listaDrones = xmlDoc.Descendants("listaDrones").Elements("dron");
            //int contadorEnListaDrones = listaDrones.Count();
            //Console.WriteLine($"Cantidad en la lista de droes {contadorEnListaDrones}");
            foreach (var dron in listaDrones)
            {
                Console.WriteLine($"- {dron.Value}");

                Dron? dronEncontrado = listaDronesGlobal.Search(dron.Value);
                if (dronEncontrado == null)
                {
                    Dron nuevoDron = new Dron(dron.Value);
                    listaDronesGlobal.Append(nuevoDron);
                    // con esto evito duplicados, si el dron ya existe en la lista global,
                    // no lo agrego nuevamente, pero si no existe, lo creo
                    // y lo agrego a la lista global de drones para luego ser usado en los sistemas de drones
                }
            }

            // 2. LECTURA DE LOS SISTEMAS DE DRONES
            Console.WriteLine("\n--- SISTEMAS DE DRONES ---");
            //var sistemasDrones = xmlDoc.Descendants("sistemaDrones");
            var sistemasDrones = xmlDoc
                .Root?
                .Element("listaSistemasDrones")?
                .Elements("sistemaDrones");

            if (sistemasDrones != null)
            {
                foreach (var sistema in sistemasDrones)
                {
                    string nombreSistema = sistema.Attribute("nombre")?.Value ?? "";
                    string alturaMaxima = sistema.Element("alturaMaxima")?.Value ?? "";
                    int cantidadDrones = ObtenerEntero(sistema.Element("cantidadDrones"));

                    //SistemaDrones nuevoSistemaDrones = new SistemaDrones(nombreSistema);

                    Console.WriteLine($"Sistema: {nombreSistema} | Altura Máx: {alturaMaxima} | Drones: {cantidadDrones}");



                    var contenido = sistema.Element("contenido");
                    if (contenido != null)
                    {
                        int contadorEnContendido = 0;
                        foreach (var elemento in contenido.Elements())
                        {
                            if (contadorEnContendido > cantidadDrones)
                            {
                                //Console.WriteLine($"listado {contadorEnContendido}, cantidadDrones {cantidadDrones}");
                                throw new FormatException(
                                    "El archivo no respeta la cantidad de drones indicada en el valor cantidadDrones en SistemaDrones.\n" +
                                    $"cantidad de drones indicado {cantidadDrones}, se sobrepaso la cantidad de drones en contendio {contadorEnContendido}, Sistema {nombreSistema}"
                                );
                            }
                            if (elemento.Name == "dron")
                            {
                                // Veo si el dron existe en la lista global de drones
                                Dron? dronEncontrado = listaDronesGlobal.Search(elemento.Value);
                                if (dronEncontrado == null)
                                {
                                    throw new FormatException(
                                        "El archivo contiene nombres de Drones que no existen en el Sistema, debe crearlos primero para luego ser usados.\n" +
                                        $"El dron '{elemento.Value}' no existe en la lista global de drones."
                                    );
                                }

                                //Dron? copiaDron = new Dron(dronEncontrado.Nombre);
                                //nuevoSistemaDrones.ListaDrones.Append(copiaDron);

                                Console.WriteLine($"  Dron Asignado: {elemento.Value}");

                                contadorEnContendido++;
                            }
                            else if (elemento.Name == "alturas")
                            {
                                foreach (var altura in elemento.Elements("altura"))
                                {
                                    string valorAltura = altura.Attribute("valor")?.Value ?? "";
                                    string letra = altura.Value;
                                    Console.WriteLine($"    -> Altura {valorAltura}: '{letra}'");
                                }
                            }
                        }
                    }
                    //listaSistemaDronesGlobal.Append(nuevoSistemaDrones);
                }
            }

            // 3. LECTURA DE LOS MENSAJES
            Console.WriteLine("\n--- LISTA DE MENSAJES ---");
            var listaMensajes = xmlDoc.Descendants("Mensaje");
            foreach (var mensaje in listaMensajes)
            {
                string nombreMensaje = mensaje.Attribute("nombre")?.Value;
                string sistemaAsociado = mensaje.Element("sistemaDrones")?.Value;

                Console.WriteLine($"Mensaje: {nombreMensaje} (Aplica para: {sistemaAsociado})");

                var instrucciones = mensaje.Element("instrucciones")?.Elements("instruccion");
                if (instrucciones != null)
                {
                    Console.WriteLine("  Instrucciones:");
                    foreach (var instruccion in instrucciones)
                    {
                        string dronDestino = instruccion.Attribute("dron")?.Value;
                        string valorInstruccion = instruccion.Value;
                        Console.WriteLine($"    - Mover {dronDestino} a la altura {valorInstruccion}");
                    }
                }
            }

            Console.WriteLine("\n=========================================");
            Console.WriteLine("        FIN LECTURA DEL XML");
            Console.WriteLine("=========================================");
        }

        public int ObtenerEntero(XElement elemento, int valorPorDefecto = 0)
        {
            return int.TryParse(elemento?.Value, out int resultado) ? resultado : valorPorDefecto;
        }

    }
}
