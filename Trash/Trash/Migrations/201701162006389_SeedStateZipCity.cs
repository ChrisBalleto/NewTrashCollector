namespace Trash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedStateZipCity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Zipcodes", "ZipcodeNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zipcodes", "ZipcodeNum", c => c.String());
        }
    }
}
