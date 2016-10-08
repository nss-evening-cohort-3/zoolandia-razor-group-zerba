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
        public int SpeciesId { get; set; }

        public string Name { get; set; }

        public string CommonName { get; set; }

        public string ScientificName { get; set; }
      
    }

}


