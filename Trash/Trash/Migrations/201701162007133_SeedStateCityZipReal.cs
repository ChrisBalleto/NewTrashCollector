namespace Trash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedStateCityZipReal : DbMigration
    {
        public override void Up()
        {
            

            Sql("SET IDENTITY_INSERT States ON INSERT INTO States(Id, StateName) VALUES (1, 'Wisconsin')");
        }
        
        public override void Down()
        {
        }
    }
}
