using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Semana8.Movies;

namespace Semana8.Data
{
    public class Semana8Context : DbContext
    {
        public Semana8Context (DbContextOptions<Semana8Context> options)
            : base(options)
        {
        }

        public DbSet<Semana8.Movies.Movie> Movie { get; set; } = default!;
    }
}
