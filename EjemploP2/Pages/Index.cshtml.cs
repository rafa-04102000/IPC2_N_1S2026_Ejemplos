using EjemploP2.EsctructuraDeDatos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjemploP2.Pages
{
    public class IndexModel : PageModel
    {

        private readonly Repositorio _repositorio;
        public IndexModel(Repositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void OnGet()
        {
            // Al cargar la página por primera vez, no hacemos nada especial
        }

        //Agarramos el XML
        //Propiedad para atrapar el archivo del HTML
        // El BindProperty hace que al hacer submit del formulario,
        // el archivo se asigne automáticamente a esta propiedad, sin necesidad de parámetros adicionales en el método OnPost.
        [BindProperty]
        public IFormFile? ArchivoXml { get; set; }
        // Propiedad para guardar el texto y mandarlo al Textarea
        public string ContenidoXml { get; set; } = string.Empty;

        // El método que se ejecuta al darle clic al botón de "Cargar XML"
        public IActionResult OnPostCargarXml()
        {
            // Le pasamos el archivo a tu Gestor y guardamos el resultado
            ContenidoXml = _repositorio.LeerArchivoComoString(ArchivoXml!);

            // Recargamos la misma página para que se dibuje el texto
            return Page();
        }

        // El método para el segundo botón (lo dejamos vacío por ahora)
        public IActionResult OnPostGenerarXml()
        {
            ContenidoXml = "Función de generar XML en construcción...";
            return Page();
        }
    }
}
