using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class FilmListContext : DbContext
    {
        public FilmListContext (DbContextOptions<FilmListContext> options) : base (options)
        { }

        public DbSet<Film> Films { get; set; }
    }
}
