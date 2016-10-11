namespace ZoolandiaRazor.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZoolandiaRazor.Models;


    internal sealed class Configuration : DbMigrationsConfiguration<ZoolandiaRazor.DAL.ZooContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZoolandiaRazor.DAL.ZooContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            var employeeOne = new Employee { FirstName = "KT", LastName = "Magnum", Age = 34, EmployeeId = 7 };
            var employeeTwo = new Employee { FirstName = "Rumple", LastName = "McBurt", Age = 88, EmployeeId = 1 };
            var employeeThree = new Employee { FirstName = "Zach", LastName = "Withaaach", Age = 44, EmployeeId = 25 };
            var employeeFour = new Employee { FirstName = "Knife", LastName = "Butter", Age = 34, EmployeeId = 46 };

            
                    
            context.Animals.AddOrUpdate(
                 a => a.Name,
                  new Animal { Name = "Andrew Peters", Habitat = 1, Age = 5 , Species = "Qbert" },
                  new Animal { Name = "Bigfoot", Habitat = 6, Age = 56, Species ="Fur" },
                  new Animal { Name = "Cheese", Habitat = 3, Age = 7, Species = "Ween" },
                  new Animal { Name = "Lucky", Habitat = 4, Age = 79, Species = "Gene" }

                );

            context.Species.AddOrUpdate(
                s => s.Name,
                    new Species { Name = "Qbert", CommonName = "Bob", ScientificName = "PotatMaximus" },
                    new Species { Name = "Fur", CommonName = "rub", ScientificName = "YouWannaKnow" },
                    new Species { Name = "Ween", CommonName = "Good", ScientificName = "Doh" },
                    new Species { Name = "Gene", CommonName = "Car", ScientificName = "Duh" }
                );

            context.Employees.AddOrUpdate(
                e => e.FirstName,
                    employeeOne,
                    employeeTwo,
                    employeeThree,
                    employeeFour
                );
            
            context.Habitats.AddOrUpdate(
                h => h.Name,
                    new Habitat { Name = "EastNasty", Type = "Hipster", CurrentlyOpen = true, EmployeeList = new List<Employee> { employeeOne } },
                    new Habitat { Name = "Hell", Type = "Eagle", CurrentlyOpen = false, EmployeeList = new List<Employee> { employeeTwo } },
                    new Habitat { Name = "Swamp", Type = "Post-it", CurrentlyOpen = true, EmployeeList = new List<Employee> { employeeThree } },
                    new Habitat { Name = "Table", Type = "Bark", CurrentlyOpen = true, EmployeeList = new List<Employee> { employeeFour } }
                    
                );

            
           
            
            
            //
        }
    }
}
