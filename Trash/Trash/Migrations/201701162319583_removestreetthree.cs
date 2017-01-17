namespace Trash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removestreetthree : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Addresses", "StreetThree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "StreetThree", c => c.String());
        }
    }
}
