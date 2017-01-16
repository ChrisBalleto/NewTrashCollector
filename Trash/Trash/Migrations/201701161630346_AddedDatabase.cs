namespace Trash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetOne = c.String(),
                        StreetTwo = c.String(),
                        StreetThree = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AddressId = c.Int(nullable: false),
                        EMailAddress = c.String(),
                        IsCurrentCustomer = c.Boolean(nullable: false),
                        MembershipTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .Index(t => t.AddressId)
                .Index(t => t.MembershipTypeId);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MembershipName = c.String(),
                        DayOfWeekPickUpId = c.Int(nullable: false),
                        PickUpRate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DayOfWeekPickUps", t => t.DayOfWeekPickUpId, cascadeDelete: true)
                .Index(t => t.DayOfWeekPickUpId);
            
            CreateTable(
                "dbo.DayOfWeekPickUps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayOfWeek = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vacations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        StartVacation = c.DateTime(),
                        EndVacation = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacations", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropForeignKey("dbo.MembershipTypes", "DayOfWeekPickUpId", "dbo.DayOfWeekPickUps");
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Vacations", new[] { "CustomerId" });
            DropIndex("dbo.MembershipTypes", new[] { "DayOfWeekPickUpId" });
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropIndex("dbo.Customers", new[] { "AddressId" });
            DropTable("dbo.Workers");
            DropTable("dbo.Vacations");
            DropTable("dbo.DayOfWeekPickUps");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
