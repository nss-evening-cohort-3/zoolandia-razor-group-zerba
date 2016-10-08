using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.DAL
{
    public class ZooRepository
    {
        public ZooContext Context { get; set; }

        public ZooRepository()
        {
            Context = new ZooContext();
        }

        public ZooRepository(ZooContext _context)
        {
            Context = _context;
        }

        public List<Animal> GetAnimals()
        {
            return Context.Animal.ToList();
        }

        public List<Habitat> GetHabitats()
        {
            return Context.Habitat.ToList();
        }

        public List<Employee> GetEmployees()
        {
            return Context.Employee.ToList();
        }

    }
}