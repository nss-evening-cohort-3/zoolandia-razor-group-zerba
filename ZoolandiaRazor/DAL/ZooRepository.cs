using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
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


        public Animal FindAnimalByAnimalId(int animalId)
        {
            Animal found_animal_id = Context.Animals.FirstOrDefault(a => a.AnimalId == animalId);
            return found_animal_id;
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

        public void AddAnimal(Animal my_animal)
        {
            
            if (FindAnimalByAnimalEntered(my_animal.Name) == null)
            {
                Context.Animals.Add(my_animal);
                Context.SaveChanges();
            }
            else
            {
                throw new Exception("Error! " + my_animal.Name + " is already in the zoo!");
            }
        }

        public Animal FindAnimalByAnimalEntered(string animals_entered)
        {
            Animal found_animal = Context.Animals.FirstOrDefault(rowInRowAnimalTable => 
                                                                    rowInRowAnimalTable.Name.ToString().ToLower()
                                                                         == animals_entered.ToString().ToLower());
            return found_animal;
        }


        public Animal RemoveAnimal(string animal_entered)
        {
            
            Animal found_animal = FindAnimalByAnimalEntered(animal_entered);
            if (found_animal != null)
            {
                Context.Animals.Remove(found_animal);
                Context.SaveChanges();
                return found_animal;
            }
            else
            {
                throw new Exception("Error! animal doesn't exist");
            }
        }

        

        public List<Species> GetSpecies()
        {
            return Context.Species.ToList();
        }

        public void AddSpecies(Species my_species)
        {
            if (FindSpeciesByName(my_species.Name) == null)
            {
                Context.Species.Add(my_species);
                Context.SaveChanges();
            }
            else
            {
                throw new Exception("Error! " + my_species.Name + " is already in the database");
            }  
        }
        

        public Species RemoveSpecies(string species_entered)
        {
            Species found_species = FindSpeciesByName(species_entered);
            if (found_species != null)
            {
                Context.Species.Remove(found_species);
                Context.SaveChanges();
                return found_species;

            }
            else
            {

                throw new Exception("Error! species doesn't exist");
            }
        }
    }
}