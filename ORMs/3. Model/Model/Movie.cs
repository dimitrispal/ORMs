using System;
using System.Collections.Generic;
using System.Text;

namespace ORMs.Example3
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string Name { get; set; }

        public string Director { get; set; }

        public DateTime DateReleased { get; set; }
    }
}
