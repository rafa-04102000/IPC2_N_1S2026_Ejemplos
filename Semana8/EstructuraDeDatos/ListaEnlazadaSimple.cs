using Semana8.Movies;

namespace Semana8.EstructuraDeDatos
{
    public class ListaEnlazadaSimple
    {
        public Nodo? Raiz { get; set; }

        public void Append(Nodo nuevoNodo)
        {
            if (Raiz == null)
            {
                Raiz = nuevoNodo;
            }
            else
            {
                Nodo nodoActual = Raiz;
                while (nodoActual.Siguiente != null)
                {
                    nodoActual = nodoActual.Siguiente;
                }
                nodoActual.Siguiente = nuevoNodo;
            }
        }

        // Retornar las peliculas como un arreglo
        public Movie[] ToArray()
        {
            List<Movie> peliculas = new List<Movie>();
            Nodo? nodoActual = Raiz;
            while (nodoActual != null)
            {
                peliculas.Add(nodoActual.Pelicula);
                nodoActual = nodoActual.Siguiente;
            }
            return peliculas.ToArray();
        }
    }
}
