namespace Trash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Customers", "State_Id", "dbo.States");
            DropIndex("dbo.Customers", new[] { "City_Id" });
            DropIndex("dbo.Customers", new[] { "State_Id" });
            DropColumn("dbo.Customers", "CityId");
            DropColumn("dbo.Customers", "StateId");
            RenameColumn(table: "dbo.Customers", name: "City_Id", newName: "CityId");
            RenameColumn(table: "dbo.Customers", name: "State_Id", newName: "StateId");
            AlterColumn("dbo.Customers", "CityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "StateId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "CityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "CityId");
            CreateIndex("dbo.Customers", "StateId");
            AddForeignKey("dbo.Customers", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "StateId", "dbo.States", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "StateId", "dbo.States");
            DropForeignKey("dbo.Customers", "CityId", "dbo.Cities");
            DropIndex("dbo.Customers", new[] { "StateId" });
            DropIndex("dbo.Customers", new[] { "CityId" });
            AlterColumn("dbo.Customers", "StateId", c => c.Int());
            AlterColumn("dbo.Customers", "CityId", c => c.Int());
            AlterColumn("dbo.Customers", "StateId", c => c.String());
            AlterColumn("dbo.Customers", "CityId", c => c.String());
            RenameColumn(table: "dbo.Customers", name: "StateId", newName: "State_Id");
            RenameColumn(table: "dbo.Customers", name: "CityId", newName: "City_Id");
            AddColumn("dbo.Customers", "StateId", c => c.String());
            AddColumn("dbo.Customers", "CityId", c => c.String());
            CreateIndex("dbo.Customers", "State_Id");
            CreateIndex("dbo.Customers", "City_Id");
            AddForeignKey("dbo.Customers", "State_Id", "dbo.States", "Id");
            AddForeignKey("dbo.Customers", "City_Id", "dbo.Cities", "Id");
        }
    }
}
