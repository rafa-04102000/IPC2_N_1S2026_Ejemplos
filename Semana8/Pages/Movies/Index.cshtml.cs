using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Semana8.Data;
using Semana8.EstructuraDeDatos;
using Semana8.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semana8.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RepositorioPeliculas _repositorio;

        public IndexModel(RepositorioPeliculas repositorioPeliculas)
        {
            _repositorio = repositorioPeliculas;
        }

        // Esto de IList es la lista que usa Razor Pages para mostrar los datos en la vista,
        // es como un puente entre el código C# y el HTML, es la forma en que le decimos a Razor Pages:
        // "Oye, aquí tienes una lista de películas que puedes usar para mostrar en la página".
        // No usamos el array comun porque Razor Pages trabaja mejor con IList, que es una interfaz que representa una
        // lista de objetos, y nos da más flexibilidad para trabajar con los datos en la vista.
        public IList<Movie> Movie { get; set; } = default!;
        // IList es un contrato, no un objeto
        //IList<T>(Interface List) no es una clase real que puedas instanciar con new IList().
        //Es simplemente una interfaz, un "contrato" que dicta ciertas reglas.Ese contrato dice: 
        //"Cualquier cosa que firme esto, debe permitir contar sus elementos y acceder a ellos usando un índice como [i]".
        // Tanto Array como List<T> implementan ese contrato, por eso puedes usar cualquiera de los dos para cumplir con lo que Razor Pages espera.


        public void OnGet()
        {
            // 3. Extraes los datos de tu lista enlazada para mostrarlos
            // (Asumiendo que tu lista enlazada tiene un método para convertirse en array o iterar)
           Movie = _repositorio.ObtenerPeliculas();
        }
    }
}
