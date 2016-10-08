using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ZoolandiaRazor.Models
{
    public class Species
    {
        [Key]
        public int SpeciesId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CommonName { get; set; }

        [Required]
        public string ScientificName { get; set; }
      
    }

}


