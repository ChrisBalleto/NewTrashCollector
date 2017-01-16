namespace Trash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PutDayOfWeekinCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MembershipTypes", "DayOfWeekPickUpId", "dbo.DayOfWeekPickUps");
            DropIndex("dbo.MembershipTypes", new[] { "DayOfWeekPickUpId" });
            AddColumn("dbo.Customers", "DayOfWeekPickUpId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "DayOfWeekPickUpId");
            AddForeignKey("dbo.Customers", "DayOfWeekPickUpId", "dbo.DayOfWeekPickUps", "Id", cascadeDelete: true);
            DropColumn("dbo.MembershipTypes", "DayOfWeekPickUpId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "DayOfWeekPickUpId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "DayOfWeekPickUpId", "dbo.DayOfWeekPickUps");
            DropIndex("dbo.Customers", new[] { "DayOfWeekPickUpId" });
            DropColumn("dbo.Customers", "DayOfWeekPickUpId");
            CreateIndex("dbo.MembershipTypes", "DayOfWeekPickUpId");
            AddForeignKey("dbo.MembershipTypes", "DayOfWeekPickUpId", "dbo.DayOfWeekPickUps", "Id", cascadeDelete: true);
        }
    }
}
