namespace ZoolandiaRazor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Habitat = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Habitat_HabitatId = c.Int(),
                    })
                .PrimaryKey(t => t.AnimalId)
                .ForeignKey("dbo.Habitats", t => t.Habitat_HabitatId)
                .Index(t => t.Habitat_HabitatId);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        SpeciesId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CommonName = c.String(nullable: false),
                        ScientificName = c.String(nullable: false),
                        Animal_AnimalId = c.Int(),
                    })
                .PrimaryKey(t => t.SpeciesId)
                .ForeignKey("dbo.Animals", t => t.Animal_AnimalId)
                .Index(t => t.Animal_AnimalId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Habitats",
                c => new
                    {
                        HabitatId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        CurrentlyOpen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HabitatId);
            
            CreateTable(
                "dbo.HabitatEmployees",
                c => new
                    {
                        Habitat_HabitatId = c.Int(nullable: false),
                        Employee_EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Habitat_HabitatId, t.Employee_EmployeeId })
                .ForeignKey("dbo.Habitats", t => t.Habitat_HabitatId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .Index(t => t.Habitat_HabitatId)
                .Index(t => t.Employee_EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HabitatEmployees", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.HabitatEmployees", "Habitat_HabitatId", "dbo.Habitats");
            DropForeignKey("dbo.Animals", "Habitat_HabitatId", "dbo.Habitats");
            DropForeignKey("dbo.Species", "Animal_AnimalId", "dbo.Animals");
            DropIndex("dbo.HabitatEmployees", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.HabitatEmployees", new[] { "Habitat_HabitatId" });
            DropIndex("dbo.Species", new[] { "Animal_AnimalId" });
            DropIndex("dbo.Animals", new[] { "Habitat_HabitatId" });
            DropTable("dbo.HabitatEmployees");
            DropTable("dbo.Habitats");
            DropTable("dbo.Employees");
            DropTable("dbo.Species");
            DropTable("dbo.Animals");
        }
    }
}
