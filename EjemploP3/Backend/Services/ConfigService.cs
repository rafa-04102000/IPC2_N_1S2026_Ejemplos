using Backend.Models;
using Backend.Repositories;
using System.Text;
using System.Xml.Linq;

namespace Backend.Services
{
    public class ConfigService
    {
        private readonly RepositorioTienda _repositorio;

        public ConfigService(RepositorioTienda repositorio)
        {
            _repositorio = repositorio;
        }

        public string CargarConfiguracion(string xmlContent)
        {
            XDocument doc = XDocument.Parse(xmlContent);
            int clientesNuevos = 0;
            int clientesActualizados = 0;
            int bancosNuevos = 0;
            int bancosActualizados = 0;

            // 1. Procesar Clientes (si el nodo existe)
            var clientesXml = doc.Root?.Element("clientes")?.Elements("cliente");
            if (clientesXml != null)
            {
                foreach (var item in clientesXml)
                {
                    string nit = item.Element("NIT")?.Value ?? "";
                    string nombre = item.Element("nombre")?.Value ?? "";

                    var clienteExistente = _repositorio.Clientes.FirstOrDefault(c => c.NIT == nit);
                    if (clienteExistente != null)
                    {
                        clienteExistente.Nombre = nombre;
                        clientesActualizados++;
                    }
                    else
                    {
                        _repositorio.Clientes.Add(new Cliente { NIT = nit, Nombre = nombre });
                        clientesNuevos++;
                    }
                }
            }

            // 2. Procesar Bancos (si el nodo existe)
            var bancosXml = doc.Root?.Element("bancos")?.Elements("banco");
            if (bancosXml != null)
            {
                foreach (var item in bancosXml)
                {
                    string codigo = item.Element("codigo")?.Value ?? "";
                    string nombre = item.Element("nombre")?.Value ?? "";

                    var bancoExistente = _repositorio.Bancos.FirstOrDefault(b => b.Codigo == codigo);
                    if (bancoExistente != null)
                    {
                        bancoExistente.Nombre = nombre;
                        bancosActualizados++;
                    }
                    else
                    {
                        _repositorio.Bancos.Add(new Banco { Codigo = codigo, Nombre = nombre });
                        bancosNuevos++;
                    }
                }
            }

            // 3. Generar el XML de respuesta exacto a la imagen}


            XDocument respuestaXML = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"), // opcional, pero recomendado para especificar la versión y codificación

                new XElement("respuesta",
                    new XElement("clientes",
                        new XElement("creados", clientesNuevos),
                        new XElement("actualizados", clientesActualizados)
                    ),
                    new XElement("bancos",
                        new XElement("creados", bancosNuevos),
                        new XElement("actualizados", bancosActualizados)
                    )
                )
            );

            //XElement xmlRespuesta = new XElement("respuesta",
            //    new XElement("clientes",
            //        new XElement("creados", clientesNuevos),
            //        new XElement("actualizados", clientesActualizados)
            //    ),
            //    new XElement("bancos",
            //        new XElement("creados", bancosNuevos),
            //        new XElement("actualizados", bancosActualizados)
            //    )
            //);

            // Retornamos el XML formateado como string
            //return respuestaXML.ToString();

            // Usamos un StringWriter con una clase personalizada para forzar UTF-8 
            // y asegurar que la XDeclaration no se pierda
            var sb = new StringBuilder();
            using (var writer = new Utf8StringWriter(sb))
            {
                respuestaXML.Save(writer);
            }

            return sb.ToString();

            // Si no pude haber usado esto es valido igual
            //string declaracion = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
            //return declaracion + respuestaXML.ToString();
        }

    }
    // Esta clase se asegura de que el StringWriter utilice UTF-8 al generar el XML de respuesta
    public class Utf8StringWriter : StringWriter
    {
        public Utf8StringWriter(StringBuilder sb) : base(sb) { }
        public override Encoding Encoding => Encoding.UTF8;
    }
}
