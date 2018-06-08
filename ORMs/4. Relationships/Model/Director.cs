using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ORMs.Example4
{
    public class Director
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
