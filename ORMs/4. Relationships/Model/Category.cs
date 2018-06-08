using System;
using System.Collections.Generic;
using System.Text;

namespace ORMs.Example4
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<MovieCategory> Categories { get; set; }
    }
}
