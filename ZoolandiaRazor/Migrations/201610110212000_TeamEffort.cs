namespace ZoolandiaRazor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeamEffort : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Species", "Animal_AnimalId", "dbo.Animals");
            DropForeignKey("dbo.Animals", "Habitat_HabitatId", "dbo.Habitats");
            DropIndex("dbo.Animals", new[] { "Habitat_HabitatId" });
            DropIndex("dbo.Species", new[] { "Animal_AnimalId" });
            AddColumn("dbo.Animals", "Species", c => c.String(nullable: false));
            DropColumn("dbo.Animals", "Habitat_HabitatId");
            DropColumn("dbo.Species", "Animal_AnimalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Species", "Animal_AnimalId", c => c.Int());
            AddColumn("dbo.Animals", "Habitat_HabitatId", c => c.Int());
            DropColumn("dbo.Animals", "Species");
            CreateIndex("dbo.Species", "Animal_AnimalId");
            CreateIndex("dbo.Animals", "Habitat_HabitatId");
            AddForeignKey("dbo.Animals", "Habitat_HabitatId", "dbo.Habitats", "HabitatId");
            AddForeignKey("dbo.Species", "Animal_AnimalId", "dbo.Animals", "AnimalId");
        }
    }
}
