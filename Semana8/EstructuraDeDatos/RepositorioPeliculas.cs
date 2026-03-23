using Semana8.Movies;

namespace Semana8.EstructuraDeDatos
{
    public class RepositorioPeliculas
    {
        public ListaEnlazadaSimple Peliculas { get; set; }

        public RepositorioPeliculas()
        {
            Peliculas = new ListaEnlazadaSimple();
        }

        // Metodo para retornar las peliculas como un arreglo
        public Movie[] ObtenerPeliculas()
        {
            return Peliculas.ToArray();
        }
    }
}
