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


        //Agarramos el XML
        //Propiedad para atrapar el archivo del HTML
        // El BindProperty hace que al hacer submit del formulario,
        // el archivo se asigne automáticamente a esta propiedad, sin necesidad de parámetros adicionales en el método OnPost.
        [BindProperty]
        public IFormFile? ArchivoXml { get; set; }
        // Propiedad para guardar el texto y mandarlo al Textarea
        public string ContenidoXml { get; set; } = string.Empty;

        public void OnGet()
        {
            // Al cargar la página por primera vez, no hacemos nada especial
            ContenidoXml = _repositorio.textoXml;
            _repositorio.textoXml = "";
        }


        // El método que se ejecuta al darle clic al botón de "Cargar XML"
        public IActionResult OnPostCargarXml()
        {
            if (ArchivoXml == null)
            {
                TempData["MensajeError"] = "Por favor, seleccione un archivo XML antes de hacer clic en Cargar.";
                return RedirectToPage();
            }

            try
            {
                _repositorio.CargarValoresXmlSistemas(ArchivoXml);

                _repositorio.LeerArchivoComoStringLocal(ArchivoXml);

                TempData["MensajeExito"] = "Se cargó el archivo XML de forma correcta.";


            }
            catch (Exception ex) {
                TempData["MensajeError"] = ex.Message;
                _repositorio.textoXml = "El archivo cargado contenia errore de formato y no pude ser procesado";
            }

            return RedirectToPage();
            // Cuando no guardan datos, retrun Page();

        }

        // El método para el segundo botón (lo dejamos vacío por ahora)
        public IActionResult OnPostGenerarXml()
        {
            ContenidoXml = "Función de generar XML en construcción...";
            return Page();
        }


        public IActionResult OnPostReiniciarSistema()
        {
            // _repositorio.ReiniciarTodo(); (tu método lógico)
            TempData["MensajeReinicio"] = "El sistema se ha reiniciado correctamente. Todos los datos han sido borrados.";
            return RedirectToPage();
        }
    }
}
