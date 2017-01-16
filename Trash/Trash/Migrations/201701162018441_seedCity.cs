namespace Trash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedCity : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Cities ON INSERT INTO Cities(Id, CityName) VALUES (1, 'Milwaukee')");
            Sql("SET IDENTITY_INSERT Cities ON INSERT INTO Cities(Id, CityName) VALUES (2, 'West Allis')");
            Sql("SET IDENTITY_INSERT Cities ON INSERT INTO Cities(Id, CityName) VALUES (3, 'Whitefish Bay')");
            Sql("SET IDENTITY_INSERT Cities ON INSERT INTO Cities(Id, CityName) VALUES (4, 'Brookfield')");
            Sql("SET IDENTITY_INSERT Cities ON INSERT INTO Cities(Id, CityName) VALUES (5, 'Mequon')");
            Sql("SET IDENTITY_INSERT Cities ON INSERT INTO Cities(Id, CityName) VALUES (6, 'Cudahy')");
        }

        public override void Down()
        {
        }
    }
}
