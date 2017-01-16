namespace Trash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StateZipCity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Zipcodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ZipcodeNum = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Addresses", "CityId", c => c.String());
            AddColumn("dbo.Addresses", "StateId", c => c.String());
            AddColumn("dbo.Addresses", "ZipcodeId", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "City_Id", c => c.Int());
            AddColumn("dbo.Addresses", "State_Id", c => c.Int());
            AddColumn("dbo.Workers", "FirstName", c => c.String());
            AddColumn("dbo.Workers", "LastName", c => c.String());
            CreateIndex("dbo.Addresses", "ZipcodeId");
            CreateIndex("dbo.Addresses", "City_Id");
            CreateIndex("dbo.Addresses", "State_Id");
            AddForeignKey("dbo.Addresses", "City_Id", "dbo.Cities", "Id");
            AddForeignKey("dbo.Addresses", "State_Id", "dbo.States", "Id");
            AddForeignKey("dbo.Addresses", "ZipcodeId", "dbo.Zipcodes", "Id", cascadeDelete: true);
            DropColumn("dbo.Addresses", "City");
            DropColumn("dbo.Addresses", "State");
            DropColumn("dbo.Addresses", "ZipCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "ZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "State", c => c.String());
            AddColumn("dbo.Addresses", "City", c => c.String());
            DropForeignKey("dbo.Addresses", "ZipcodeId", "dbo.Zipcodes");
            DropForeignKey("dbo.Addresses", "State_Id", "dbo.States");
            DropForeignKey("dbo.Addresses", "City_Id", "dbo.Cities");
            DropIndex("dbo.Addresses", new[] { "State_Id" });
            DropIndex("dbo.Addresses", new[] { "City_Id" });
            DropIndex("dbo.Addresses", new[] { "ZipcodeId" });
            DropColumn("dbo.Workers", "LastName");
            DropColumn("dbo.Workers", "FirstName");
            DropColumn("dbo.Addresses", "State_Id");
            DropColumn("dbo.Addresses", "City_Id");
            DropColumn("dbo.Addresses", "ZipcodeId");
            DropColumn("dbo.Addresses", "StateId");
            DropColumn("dbo.Addresses", "CityId");
            DropTable("dbo.Zipcodes");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
        }
    }
}
