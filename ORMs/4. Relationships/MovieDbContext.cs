using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMs.Example4
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // instructs context to use inememory database with name sample4
            optionsBuilder
                .UseSqlServer(@"Data Source=(localdb)\netacademy;initial catalog=MoviesDb; Integrated Security=SSPI;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one to many
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(m => m.Movies);

            // one to one
            modelBuilder.Entity<Movie>()
               .HasOne(m => m.Details)
               .WithOne(m => m.Movie)
               .HasForeignKey<MovieDetails>(m => m.MovieId);

            // many to many
            modelBuilder.Entity<MovieCategory>()
                .HasKey(bc => new { bc.MovieId, bc.CategoryId });

            modelBuilder.Entity<MovieCategory>().Property(b => b.MovieId).ValueGeneratedNever();
            modelBuilder.Entity<MovieCategory>().Property(b => b.CategoryId).ValueGeneratedNever();

            modelBuilder.Entity<MovieCategory>()
                .HasOne(bc => bc.Movie)
                .WithMany(b => b.Categories)
                .HasForeignKey(bc => bc.MovieId);

            modelBuilder.Entity<MovieCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.Categories)
                .HasForeignKey(bc => bc.CategoryId);
        }

        public void Cleanup()
        {
            Database.ExecuteSqlCommand(@"
                DELETE FROM dbo.Categories;
                DELETE FROM dbo.Movies;
                DELETE FROM dbo.Directors;
                DELETE FROM dbo.MovieDetails;
                DELETE FROM dbo.MovieCategory"
            );
        }
    }
}