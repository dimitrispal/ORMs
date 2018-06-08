using System;
using System.Collections.Generic;
using System.Text;

namespace ORMs.Example4
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Director Director { get; set; }

        public DateTime DateReleased { get; set; }

        public virtual MovieDetails Details { get; set; }

        public virtual ICollection<MovieCategory> Categories { get; set; }
    }
}
