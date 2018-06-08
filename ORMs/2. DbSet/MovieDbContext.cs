using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMs.Example2
{
    public class MovieDbContext : DbContext
    {
        // declare a new dbset with name movies that will be mapped to table Movies
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // instructs context to use inememory database with name sample2
            optionsBuilder
                .UseInMemoryDatabase("sample2");
        }
    }
}