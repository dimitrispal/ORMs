using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORMs.Example4
{
    public static class RelationshipsSample
    {
        public static void Run()
        {
            var context = new MovieDbContext();
            context.Cleanup();

            Helpers.DisplaySectionTitle("Relationships one to many");
            OneToMany();
            Helpers.DisplaySectionEnd();

            Helpers.DisplaySectionTitle("Relationships one to one");
            OneToOne();
            Helpers.DisplaySectionEnd();

            Helpers.DisplaySectionTitle("Many to many");
            ManyToMany();
            Helpers.DisplaySectionEnd();
        }

        public static void OneToMany()
        {
            // create new context
            var context = new MovieDbContext();

            var platoon = new Movie
            {
                Name = "Platoon",
                DateReleased = new DateTime(1986, 12, 19),
                Director = new Director
                {
                    Name = "Oliver Stone"
                }
            };

            context.Movies.Add(platoon);
            context.SaveChanges();

            var movies = context.Movies.Count();
            var directors = context.Directors.Count();

            Console.WriteLine($"we have {movies} movie(s) & {directors} director(s)");
        }

        public static void OneToOne()
        {
            // create new context
            var context = new MovieDbContext();

            var platoon = new Movie
            {
                Name = "Platoon",
                DateReleased = new DateTime(1986, 12, 19),
                Director = new Director
                {
                    Name = "Oliver Stone"
                },
                Details = new MovieDetails
                {
                    Budget = 100,
                    Producer = "Weinstein",
                    Ratings = 5
                }
            };

            context.Movies.Add(platoon);
            context.SaveChanges();

            var movies = context.Movies.Count();
            var directors = context.Directors.Count();

            Console.WriteLine($"we have {movies} movie(s) & {directors} director(s)");
        }

        public static void ManyToMany()
        {
            // create new context
            var context = new MovieDbContext();
            SeedData(context);

            var war = context.Categories.First(c => c.Name == "War");
            var drama = context.Categories.First(c => c.Name == "Drama");

            var platoon = new Movie
            {
                Name = "Platoon",
                DateReleased = new DateTime(1986, 12, 19),
                Categories = new[]
                {
                    new MovieCategory { Category = war },
                    new MovieCategory { Category = drama },
                },
                Director = new Director
                {
                    Name = "Oliver Stone"
                },
                Details = new MovieDetails
                {
                    Budget = 100,
                    Producer = "Weinstein",
                    Ratings = 5
                }
            };

            context.Movies.Add(platoon);
            context.SaveChanges();

            var movies = context.Movies.Count();
            var directors = context.Directors.Count();

            Console.WriteLine($"we have {movies} movie(s) & {directors} director(s)");
        }

        private static void SeedData(MovieDbContext context)
        {
            context.Categories.AddRange(
                new Category { Name = "Thriller" },
                new Category { Name = "War" },
                new Category { Name = "Drama" });

            context.SaveChanges();
        }
    }
}
