using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Queries.MyLinq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialte movie data

            var movies = new List<Movie>
            {
                new Movie {Title = "The Dark Knight", Rating = 8.9F, Year = 2008},
                new Movie {Title = "The King's Speech", Rating = 8.9F, Year = 2018},
                new Movie {Title = "Darkest Hours", Rating = 8.9F, Year = 2005},
                new Movie {Title = "Cassanova", Rating = 7.9F, Year = 1958},
                new Movie {Title = "Return Of the Living Dead", Rating = 9.2F, Year = 2017},
                new Movie {Title = "Star Wars Return", Rating = 8.1F, Year = 1989}
            };




            //extension method

            var query = movies.Where(m => m.Year > 2000);

            foreach (var movie in query)
            {
                Console.WriteLine(movie.Title);
            }
        }
    }
}
