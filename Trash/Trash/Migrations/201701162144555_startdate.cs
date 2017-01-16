namespace Trash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class startdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "StartDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "StartDate");
        }
    }
}
