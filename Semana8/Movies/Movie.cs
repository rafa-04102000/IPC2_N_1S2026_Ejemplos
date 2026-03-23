using System.ComponentModel.DataAnnotations;

namespace Semana8.Movies
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Prcie { get; set; }

    }
}
