using Microsoft.AspNetCore.Http; // Necesario para IFormFile
using System.IO;

using EjemploP2.EsctructuraDeDatos.Sistemas.Drones;
using EjemploP2.EsctructuraDeDatos.Sistemas.LectorXml;

namespace EjemploP2.EsctructuraDeDatos
{
    public class Repositorio
    {
        // Aca cualquier lista y la inicializo en el cosntrucor

        public Lector lectorXml;
        public string textoXml;
        public ListaDrones listaDrones;

        public Repositorio()
        {
            // no tengo ninguna
            lectorXml = new Lector();
            textoXml = "";
            listaDrones = new ListaDrones();
        }

        public void CargarValoresXmlSistemas(IFormFile archivo) { 
            lectorXml.LeerArchivoComoXmlSistemas(archivo,this.listaDrones);
        }

        public string LeerArchivoComoString(IFormFile archivo)
        {
            // Validamo que  el archivo no venga vacio
            if (archivo == null || archivo.Length ==0) {
                return "Error: No se seleccionó ningún archivo o el archivo está vacío.";
            }

            // Abrimos el flujo de datos en memoria y lo leemos
            using var stream = archivo.OpenReadStream();
            using var reader = new StreamReader(stream);

            string contenido = reader.ReadToEnd();

            // Aquí más adelante también podrías cargar tu XmlDocument 
            // y llenar tus Listas Enlazadas con los datos leídos.

            return contenido;
        }

        public void LeerArchivoComoStringLocal(IFormFile archivo)
        {
            // Validamos que el archivo no venga vacío
            if (archivo == null || archivo.Length == 0)
            {
                textoXml = "Error: No se seleccionó ningún archivo o el archivo está vacío.";
            }
            else
            {
                // Abrimos el flujo de datos en memoria y lo leemos
                using var stream = archivo.OpenReadStream();
                using var reader = new StreamReader(stream);

                string contenido = reader.ReadToEnd();

                // Aquí más adelante también podrías cargar tu XmlDocument 
                // y llenar tus Listas Enlazadas con los datos leídos.

                textoXml = contenido;
            }


        }
    }
}
