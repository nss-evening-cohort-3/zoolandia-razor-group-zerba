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

        public List<Species> FindSpeciesByName(string name)
        {
            Species found_species = Context.Species.FirstOrDefault(a => a.Name.ToLower() == name.ToLower());
            return found_species;
        }
        public List<Animal> GetAnimals()
        {
            return Context.Animal.ToList();
        }

        public Animal FindAnimalByName(string name)
        {
            Animal found_animal = Context.Animal.FirstOrDefault(a => a.Name.ToLower() == name.ToLower());
            return found_animal;
        }

        public List<Habitat> GetHabitats()
        {
            return Context.Habitat.ToList();
        }

        public Habitat FindHabitatByName(string name)
        {
            Habitat found_habitat = Context.Habitat.FirstOrDefault(a => a.Name.ToLower() == name.ToLower());
            return found_habitat;
        }

        public List<Employee> GetEmployees()
        {
            return Context.Employee.ToList();
        }

        public Employee FindEmployeeByEmployeeId(int id)
        {
            Employee found_employee = Context.Employee.FirstOrDefault(a => a.EmployeeId == id);
            return found_employee;
        }

    }
}