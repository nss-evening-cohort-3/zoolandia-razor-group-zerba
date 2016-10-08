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

        public Species FindSpeciesByName(string name)
        {
            Species found_species = Context.Species.FirstOrDefault(a => a.Name.ToLower() == name.ToLower());
            return found_species;
        }
        public List<Animal> GetAnimals()
        {
            return Context.Animals.ToList();
        }

        public Animal FindAnimalByName(string name)
        {
            Animal found_animal = Context.Animals.FirstOrDefault(a => a.Name.ToLower() == name.ToLower());
            return found_animal;
        }

        public List<Habitat> GetHabitats()
        {
            return Context.Habitats.ToList();
        }

        public Habitat FindHabitatByName(string name)
        {
            Habitat found_habitat = Context.Habitats.FirstOrDefault(a => a.Name.ToLower() == name.ToLower());
            return found_habitat;
        }

        public List<Employee> GetEmployees()
        {
            return Context.Employees.ToList();
        }

        public Employee FindEmployeeByEmployeeId(int id)
        {
            Employee found_employee = Context.Employees.FirstOrDefault(a => a.EmployeeId == id);
            return found_employee;
        }

    }
}