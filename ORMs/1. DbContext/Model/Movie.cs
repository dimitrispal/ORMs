using System;
using System.Collections.Generic;
using System.Text;

namespace ORMs.Example1
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Director { get; set; }

        public DateTime DateReleased { get; set; }
    }
}
