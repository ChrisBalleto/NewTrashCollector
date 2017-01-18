namespace Trash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedAddresses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Addresses", "State_Id", "dbo.States");
            DropForeignKey("dbo.Addresses", "ZipcodeId", "dbo.Zipcodes");
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Addresses", new[] { "ZipcodeId" });
            DropIndex("dbo.Addresses", new[] { "City_Id" });
            DropIndex("dbo.Addresses", new[] { "State_Id" });
            DropIndex("dbo.Customers", new[] { "AddressId" });
            AddColumn("dbo.Customers", "StreetOne", c => c.String());
            AddColumn("dbo.Customers", "StreetTwo", c => c.String());
            AddColumn("dbo.Customers", "CityId", c => c.String());
            AddColumn("dbo.Customers", "StateId", c => c.String());
            AddColumn("dbo.Customers", "ZipcodeId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "City_Id", c => c.Int());
            AddColumn("dbo.Customers", "State_Id", c => c.Int());
            CreateIndex("dbo.Customers", "ZipcodeId");
            CreateIndex("dbo.Customers", "City_Id");
            CreateIndex("dbo.Customers", "State_Id");
            AddForeignKey("dbo.Customers", "City_Id", "dbo.Cities", "Id");
            AddForeignKey("dbo.Customers", "State_Id", "dbo.States", "Id");
            AddForeignKey("dbo.Customers", "ZipcodeId", "dbo.Zipcodes", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "AddressId");
            DropTable("dbo.Addresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetOne = c.String(),
                        StreetTwo = c.String(),
                        CityId = c.String(),
                        StateId = c.String(),
                        ZipcodeId = c.Int(nullable: false),
                        City_Id = c.Int(),
                        State_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "AddressId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "ZipcodeId", "dbo.Zipcodes");
            DropForeignKey("dbo.Customers", "State_Id", "dbo.States");
            DropForeignKey("dbo.Customers", "City_Id", "dbo.Cities");
            DropIndex("dbo.Customers", new[] { "State_Id" });
            DropIndex("dbo.Customers", new[] { "City_Id" });
            DropIndex("dbo.Customers", new[] { "ZipcodeId" });
            DropColumn("dbo.Customers", "State_Id");
            DropColumn("dbo.Customers", "City_Id");
            DropColumn("dbo.Customers", "ZipcodeId");
            DropColumn("dbo.Customers", "StateId");
            DropColumn("dbo.Customers", "CityId");
            DropColumn("dbo.Customers", "StreetTwo");
            DropColumn("dbo.Customers", "StreetOne");
            CreateIndex("dbo.Customers", "AddressId");
            CreateIndex("dbo.Addresses", "State_Id");
            CreateIndex("dbo.Addresses", "City_Id");
            CreateIndex("dbo.Addresses", "ZipcodeId");
            AddForeignKey("dbo.Customers", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "ZipcodeId", "dbo.Zipcodes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "State_Id", "dbo.States", "Id");
            AddForeignKey("dbo.Addresses", "City_Id", "dbo.Cities", "Id");
        }
    }
}
