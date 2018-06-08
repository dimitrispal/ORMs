using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORMs.Example2
{
    public static class DbSetSample
    {
        public static void Run()
        {
            Helpers.DisplaySectionTitle("DbSet query movies:");
            Querying();
            Helpers.DisplaySectionEnd();
        }

        public static void Querying()
        {
            // create new context
            var context = new MovieDbContext();
            SeedData(context);

            var movies = context.Movies.ToList();
            Console.WriteLine($"Total movies: {movies.Count}");
            PrintMovies(movies);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Print movies sorted by release date");

            // get dates and sort by release date
            var byReleaseDate = context.Movies.OrderBy(movie => movie.DateReleased);
            PrintMovies(byReleaseDate);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Find movie");

            // get a movie by name
            var mv = context.Movies.First(movie => movie.Name == "Platoon");
            Console.WriteLine(mv.Name);

            context.SaveChanges();
        }

        private static void PrintMovies(IEnumerable<Movie> movies)
        {
            foreach (var item in movies)
            {
                Console.WriteLine($"[{item.Id}] {item.Name}, initial release {item.DateReleased.ToString("dd/MM/yyyy")}, directed by {item.Director}");
            }
        }

        private static void SeedData(MovieDbContext context)
        {
            context.Movies.AddRange(
                new Movie { Id = 1, Name = "Shape of Water", Director = "Guillermo del Toro", DateReleased = new DateTime(2017, 12, 1) },
                new Movie { Id = 2, Name = "Platoon", Director = "Oliver Stone", DateReleased = new DateTime(1996, 12, 19) },
                new Movie { Id = 3, Name = "Black Hawk Down", Director = "Ridley Scott", DateReleased = new DateTime(2002, 3, 1) },
                new Movie { Id = 4, Name = "Blade Runner", Director = "Ridley Scott", DateReleased = new DateTime(1982, 10, 1) }
            );

            context.SaveChanges();
        }
    }
}
