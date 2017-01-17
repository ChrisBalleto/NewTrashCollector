namespace Trash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zipcodeTerritory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "ZipcodeTerritoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Workers", "ZipcodeTerritoryId");
            AddForeignKey("dbo.Workers", "ZipcodeTerritoryId", "dbo.Zipcodes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workers", "ZipcodeTerritoryId", "dbo.Zipcodes");
            DropIndex("dbo.Workers", new[] { "ZipcodeTerritoryId" });
            DropColumn("dbo.Workers", "ZipcodeTerritoryId");
        }
    }
}
