using Microsoft.AspNetCore.Http; // Necesario para IFormFile
using System.IO;

namespace EjemploP2.EsctructuraDeDatos
{
    public class Repositorio
    {
        // Aca cualquier lista y la inicializo en el cosntrucor
        public Repositorio()
        {
            // no tengo ninguna
        }

        public string LeerArchivoComoString(IFormFile archivo)
        {
            // Validamos que el archivo no venga vacío
            if (archivo == null || archivo.Length == 0)
            {
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
    }
}
