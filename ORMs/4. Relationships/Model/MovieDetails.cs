using System;
using System.Collections.Generic;
using System.Text;

namespace ORMs.Example4
{
    public class MovieDetails
    {
        public int Id { get; set; }

        public int Ratings { get; set; }

        public decimal Budget { get; set; }

        public string Producer { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
