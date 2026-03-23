using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Semana8.Data;
using Semana8.EstructuraDeDatos;
using Semana8.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semana8.Pages.Movies
{
    public class CreateModel : PageModel
    {
        // Esto era del contexto, ya no lo usamos porque estamos usando singleton
        //private readonly Semana8.Data.Semana8Context _context;

        //public CreateModel(Semana8.Data.Semana8Context context)
        //{
        //    _context = context;
        //}

        private readonly RepositorioPeliculas _repositorio;

        public CreateModel(RepositorioPeliculas repositorioPeliculas)
        {
            _repositorio = repositorioPeliculas;
        }

        // la funcion de esto es mostrar la pagina para crear una nueva pelicula, no necesitamos hacer nada especial, solo retornar la pagina
        public IActionResult OnGet()
        {
            return Page();
        }

        // Esto es lo que se ejecuta cuando se hace su bmit del formulario para crear una nueva pelicula,
        // aqui es donde tenemos que agregar la nueva pelicula a nuestra lista enlazada, usando el repositorio
        [BindProperty]
        public Movie Movie { get; set; } = default!;


        //Esto era del contexto, ya no se usa
        // For more information, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Movie.Add(Movie);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}

        public IActionResult OnPost() {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Creamos el nuevo nodo con la película que el usuario llenó en el formulario HTML
            Nodo nuevoNodo = new Nodo { Pelicula = Movie };
            // Lo agregamos a la lista enlazada que vive en memoria
            _repositorio.Peliculas.Append(nuevoNodo);

            return RedirectToPage("./Index");
        }
    }
}
