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
        public int AnimalId { get; set; }

        public String Name { get; set; }

        public int Habitat { get; set; }

        public int Species { get; set; }

        public int Age { get; set; }


    }
}