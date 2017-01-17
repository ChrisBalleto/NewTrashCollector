namespace Trash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class concataddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ConcatAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ConcatAddress");
        }
    }
}
