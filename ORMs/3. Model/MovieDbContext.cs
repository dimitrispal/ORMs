using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMs.Example3
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // instructs context to use inememory database with name sample3
            optionsBuilder
                .UseInMemoryDatabase("sample3");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure model using fluent api
            modelBuilder.Entity<Movie>()
                .HasKey(entity => entity.MovieId);

            // set property name of Movie to have max length 50 chars
            modelBuilder.Entity<Movie>()
                .Property(movie => movie.Name).HasMaxLength(50);
        }
    }
}