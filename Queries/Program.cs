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
            var numbers = MyLinq.Random()
                .Where(n => n > 0.5).Take(10);

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }





            // initiate movie data

            var movies = new List<Movie>
            {
                new Movie {Title = "The Dark Knight", Rating = 8.9F, Year = 2008},
                new Movie {Title = "The King's Speech", Rating = 8.9F, Year = 2018},
                new Movie {Title = "Darkest Hours", Rating = 8.9F, Year = 2005},
                new Movie {Title = "Cassanova", Rating = 7.9F, Year = 1958},
                new Movie {Title = "Return Of the Living Dead", Rating = 9.2F, Year = 2017},
                new Movie {Title = "Star Wars Return", Rating = 8.1F, Year = 1989}
            };
            /*
                //extension method
                var query = movies.Filter(m => m.Year > 2000)
                    .OrderByDescending(m=>m.Rating);
        */

            var query = from movie in movies
                        where movie.Year > 2000
                        orderby movie.Rating descending
                        select movie;

            var enumerator = query.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);

            }



        }
    }
}
