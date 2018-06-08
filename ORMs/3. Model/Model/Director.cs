using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ORMs.Example3
{
    public class Director
    {
        // set direcgtorId as entity key
        [Key]
        public int DirectorId { get; set; }

        // set max length to 50 chars
        [StringLength(50)]
        public string Name { get; set; }
    }
}
