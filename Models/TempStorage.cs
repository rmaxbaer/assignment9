using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class TempStorage
    {
        private static List<Film> films = new List<Film>();

        public static IEnumerable<Film> Films => films;

        public static void AddFilm(Film myFilm)
        {
            films.Add(myFilm);
        }
    }
}
