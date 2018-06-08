using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORMs.Example1
{
    public static class DbContextSample
    {
        public static void Run()
        {
            Helpers.DisplaySectionTitle("DbContext add movies:");
            AddMovies();
            Helpers.DisplaySectionEnd();

            Helpers.DisplaySectionTitle("DbContext modify movies:");
            ModifyMovies();
            Helpers.DisplaySectionEnd();

            Helpers.DisplaySectionTitle("DbContext delete movies:");
            DeleteMovies();
            Helpers.DisplaySectionEnd();
        }

        public static void AddMovies()
        {
            // create new context
            var context = new MovieDbContext();

            // add 1 movie
            context.Add(new Movie
            {
                Name = "Shape of Water",
                DateReleased = new DateTime(2017, 12, 1),
                Director = "Guillermo del Toro"
            });
            // save changes
            context.SaveChanges();

            // add many
            context.AddRange(new[]
            {
                new Movie
                {
                    Name = "Platoon",
                    DateReleased = new DateTime(1996, 12, 19),
                    Director = "Oliver Stone"
                },
                new Movie
                {
                    Name = "Black Hawk Down",
                    DateReleased = new DateTime(2002, 3, 1),
                    Director = "Ridley Scott"
                }
            });

            context.SaveChanges();

            Console.WriteLine("Added 3 movies");
            var movies = context.Movies.ToList();
            Console.WriteLine($"Total movies: {movies.Count}");
        }

        public static void ModifyMovies()
        {
            var context = new MovieDbContext();
            var movies = context.Movies.ToList();
            Console.WriteLine($"Total movies: {movies.Count}");

            // get movie by name
            var platoon = context.Movies.First(movie => movie.Name == "Platoon");
            Console.WriteLine($"Platoon release date is set to {platoon.DateReleased.ToString("dd/MM/yyyy")}");

            // update movie
            platoon.DateReleased = new DateTime(1986, 12, 19);
            context.Update(platoon);
            context.SaveChanges();

            // get movie by name
            platoon = context.Movies.First(movie => movie.Name == "Platoon");
            Console.WriteLine($"Platoon release date is now set to {platoon.DateReleased.ToString("dd/MM/yyyy")}");
        }

        public static void DeleteMovies()
        {
            var context = new MovieDbContext();
            var movies = context.Movies.ToList();
            Console.WriteLine($"Total movies: {movies.Count}");

            // get movie by name
            var platoon = context.Movies.First(movie => movie.Name == "Platoon");
            // remove from context & save
            context.Remove(platoon);
            context.SaveChanges();
            Console.WriteLine("Deleted movie Platoon");

            movies = context.Movies.ToList();
            Console.WriteLine($"Total movies: {movies.Count}");
        }
    }
}
