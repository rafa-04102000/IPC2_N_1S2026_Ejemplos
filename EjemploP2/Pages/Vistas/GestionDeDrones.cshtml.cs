using EjemploP2.EsctructuraDeDatos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjemploP2.Pages.Vistas
{
    public class GestionDeDronesModel : PageModel
    {
        private readonly Repositorio _repositorio;


        public GestionDeDronesModel(Repositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [BindProperty]
        public string NuevoNombreDron { get; set; } = string.Empty;

        public string[] ListaDeDrones { get; set; } = Array.Empty<string>();
        public void OnGet()
        {
            ListaDeDrones = _repositorio.listaDrones.ArrayDrones();
        }


        public IActionResult OnPostCrearDron()
        {
            // validamos que no nos mandan un nombre en blanco
            if (!string.IsNullOrWhiteSpace(NuevoNombreDron))
            {
                try
                {
                    _repositorio.listaDrones.AgregarDron(NuevoNombreDron);
                    // Si llegamos a esta línea, es porque no hubo excepción. ¡Éxito!
                    TempData["MensajeExito"] = $"El dron '{NuevoNombreDron}' se ha agregado correctamente al sistema.";
                }
                catch (Exception ex)
                {
                    TempData["MensajeError"] = ex.Message;
                }
            }
            else
            {
                TempData["MensajeError"] = "El nombre del dron no puede estar vacío.";
            }

            return RedirectToPage();
        }

    }
}
