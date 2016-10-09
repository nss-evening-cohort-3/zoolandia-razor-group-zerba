using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ZoolandiaRazor.Models
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Habitat { get; set; }

        [Required]
        //public int Species { get; set; }
        public virtual List<Species> Species { get; set; }

        [Required]
        public int Age { get; set; }


    }
}