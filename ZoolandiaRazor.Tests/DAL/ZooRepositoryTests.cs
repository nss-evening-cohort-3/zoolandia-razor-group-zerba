using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZoolandiaRazor.Models;
using System.Collections.Generic;
using System.Linq;
using Moq;
using System.Data.Entity;
using ZoolandiaRazor.DAL;

namespace ZoolandiaRazor.Tests.DAL
{
    [TestClass]
    public class ZooRepositoryTests
    {
        Mock<ZooContext> mock_context { get; set; }

        Mock<DbSet<Animal>> mock_animal_table { get; set; }
        List<Animal> animal_list { get; set; }

        Mock<DbSet<Employee>> mock_employee_table { get; set; }
        List<Employee> employee_list { get; set; }

        Mock<DbSet<Habitat>> mock_habitat_table { get; set; }
        List<Habitat> habitat_list { get; set; }

        Mock<DbSet<Species>> mock_species_table { get; set; }
        List<Species> species_list { get; set; }

        ZooRepository repo { get; set; }

        public void ConnectMocksToDatastore()
        {
            var animal_queryable_list = animal_list.AsQueryable();
            var employee_queryable_list = employee_list.AsQueryable();
            var habitat_queryable_list = habitat_list.AsQueryable();
            var species_queryable_list = species_list.AsQueryable();

            //Animal class
            mock_animal_table.As<IQueryable<Animal>>().Setup(m => m.Provider).Returns(animal_queryable_list.Provider);
            mock_animal_table.As<IQueryable<Animal>>().Setup(m => m.Expression).Returns(animal_queryable_list.Expression);
            mock_animal_table.As<IQueryable<Animal>>().Setup(m => m.ElementType).Returns(animal_queryable_list.ElementType);
            mock_animal_table.As<IQueryable<Animal>>().Setup(m => m.GetEnumerator()).Returns(() => animal_queryable_list.GetEnumerator());

            //Employee Class
            mock_employee_table.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(employee_queryable_list.Provider);
            mock_employee_table.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(employee_queryable_list.Expression);
            mock_employee_table.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(employee_queryable_list.ElementType);
            mock_employee_table.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(() => employee_queryable_list.GetEnumerator());

            //Habitat Class
            mock_habitat_table.As<IQueryable<Habitat>>().Setup(m => m.Provider).Returns(habitat_queryable_list.Provider);
            mock_habitat_table.As<IQueryable<Habitat>>().Setup(m => m.Expression).Returns(habitat_queryable_list.Expression);
            mock_habitat_table.As<IQueryable<Habitat>>().Setup(m => m.ElementType).Returns(habitat_queryable_list.ElementType);
            mock_habitat_table.As<IQueryable<Habitat>>().Setup(m => m.GetEnumerator()).Returns(() => habitat_queryable_list.GetEnumerator());

            //Species Class
            mock_species_table.As<IQueryable<Species>>().Setup(m => m.Provider).Returns(species_queryable_list.Provider);
            mock_species_table.As<IQueryable<Species>>().Setup(m => m.Expression).Returns(species_queryable_list.Expression);
            mock_species_table.As<IQueryable<Species>>().Setup(m => m.ElementType).Returns(species_queryable_list.ElementType);
            mock_species_table.As<IQueryable<Species>>().Setup(m => m.GetEnumerator()).Returns(() => species_queryable_list.GetEnumerator());

            mock_context.Setup(c => c.Animals).Returns(mock_animal_table.Object);
            mock_context.Setup(c => c.Employees).Returns(mock_employee_table.Object);
            mock_context.Setup(c => c.Habitats).Returns(mock_habitat_table.Object);
            mock_context.Setup(c => c.Species).Returns(mock_species_table.Object);

            //Add
            mock_animal_table.Setup(t => t.Add(It.IsAny<Animal>())).Callback((Animal a) => animal_list.Add(a));
            mock_employee_table.Setup(t => t.Add(It.IsAny<Employee>())).Callback((Employee a) => employee_list.Add(a));
            mock_habitat_table.Setup(t => t.Add(It.IsAny<Habitat>())).Callback((Habitat a) => habitat_list.Add(a));
            mock_species_table.Setup(t => t.Add(It.IsAny<Species>())).Callback((Species a) => species_list.Add(a));

            //Delete
            mock_animal_table.Setup(t => t.Remove(It.IsAny<Animal>())).Callback((Animal a) => animal_list.Remove(a));
            mock_employee_table.Setup(t => t.Remove(It.IsAny<Employee>())).Callback((Employee a) => employee_list.Remove(a));
            mock_habitat_table.Setup(t => t.Remove(It.IsAny<Habitat>())).Callback((Habitat a) => habitat_list.Remove(a));
            mock_species_table.Setup(t => t.Remove(It.IsAny<Species>())).Callback((Species a) => species_list.Remove(a));

        }


        [TestInitialize]
        public void Initialize()
        {

            mock_context = new Mock<ZooContext>();
            
            //Animal
            mock_animal_table = new Mock<DbSet<Animal>>();
            animal_list = new List<Animal>();

            //Employee
            mock_employee_table = new Mock<DbSet<Employee>>();
            employee_list = new List<Employee>();

            //Habitat
            mock_habitat_table = new Mock<DbSet<Habitat>>();
            habitat_list = new List<Habitat>();

            //Species
            mock_species_table = new Mock<DbSet<Species>>();
            species_list = new List<Species>();

            repo = new ZooRepository(mock_context.Object);

            ConnectMocksToDatastore();
        }

        [TestCleanup] //runs after every test
        public void TearDown()
        {
            repo = null;  // 
        }

        [TestMethod]
        public void RepoInsureRepoHasContext()
        {
            ZooRepository repo = new ZooRepository();

            ZooContext actual_context = repo.Context;

            Assert.IsInstanceOfType(actual_context, typeof(ZooContext));        
        }

        
        [TestMethod]

        public void EnsureCanAddAnimalsToDatabase()
        {

            //this is my first test that will require fakeing the database
            //Arrange
           
            Animal my_animal = new Animal { AnimalId = 1, Name = "Dog", Age = 17, Habitat = 1};

            //Act
            repo.AddAnimal(my_animal);
            int actual_animal_count = repo.GetAnimals().Count;
            int expected_animal_count = 1;

            //Assert
            Assert.AreEqual(expected_animal_count, actual_animal_count);
        }

        [TestMethod]
        public void EnsureCanRemoveAnimalsFromRepoInstance()
        {
            //Arrange
            animal_list.Add(new Animal { AnimalId = 1, Name = "Dog", Age = 17, Habitat = 1 });
            animal_list.Add(new Animal { AnimalId = 2, Name = "Zebra", Age = 5, Habitat = 2 });
            animal_list.Add(new Animal { AnimalId = 3, Name = "Cat", Age = 7, Habitat = 3 });

            //Act
            string animal_entered = "Zebra";
            Animal removed_animal = repo.RemoveAnimal(animal_entered);
            int expected_animal_count = 2;
            int actual_animal_count = repo.GetAnimals().Count;
            int expected_animal_id = 2;
            int actual_animal_id = removed_animal.AnimalId;

            //Assert
            Assert.AreEqual(expected_animal_count, actual_animal_count);
            Assert.AreEqual(expected_animal_id, actual_animal_id);
        }




        /*
        [TestMethod]
        public void EnsureICanAddSpciesToDatabase()
        {

            Species my_species = new Species { CommonName = "Spud",
                                               Name = "Potato",
                                               ScientificName = "tuber massive starches", 
                                               SpeciesId = 1

            };

            //Act
            repo.AddSpecies(my_species);
            int actual_species_count = repo.GetSpecies().Count;
            int expected_species_count = 1;

            //Assert
            Assert.AreEqual(expected_species_count, actual_species_count);

        }
        */
       

    }//end of Zoo Repo Tests
}
