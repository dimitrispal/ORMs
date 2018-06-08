using System;
using System.Collections.Generic;
using System.Text;

namespace ORMs.Example4
{
    public class MovieCategory
    {
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
