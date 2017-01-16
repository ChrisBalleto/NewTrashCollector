namespace Trash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedZip : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Zipcodes ON INSERT INTO Zipcodes(Id, ZipcodeNum) VALUES (1, 53212)");
            Sql("SET IDENTITY_INSERT Zipcodes ON INSERT INTO Zipcodes(Id, ZipcodeNum) VALUES (2, 53211)");
            Sql("SET IDENTITY_INSERT Zipcodes ON INSERT INTO Zipcodes(Id, ZipcodeNum) VALUES (3, 53202)");
            Sql("SET IDENTITY_INSERT Zipcodes ON INSERT INTO Zipcodes(Id, ZipcodeNum) VALUES (4, 53203)");
            Sql("SET IDENTITY_INSERT Zipcodes ON INSERT INTO Zipcodes(Id, ZipcodeNum) VALUES (5, 53110)");
            Sql("SET IDENTITY_INSERT Zipcodes ON INSERT INTO Zipcodes(Id, ZipcodeNum) VALUES (6, 53217)");
            Sql("SET IDENTITY_INSERT Zipcodes ON INSERT INTO Zipcodes(Id, ZipcodeNum) VALUES (7, 53214)");
            Sql("SET IDENTITY_INSERT Zipcodes ON INSERT INTO Zipcodes(Id, ZipcodeNum) VALUES (8, 53122)");
            Sql("SET IDENTITY_INSERT Zipcodes ON INSERT INTO Zipcodes(Id, ZipcodeNum) VALUES (10, 53005)");
            Sql("SET IDENTITY_INSERT Zipcodes ON INSERT INTO Zipcodes(Id, ZipcodeNum) VALUES (11, 53092)");
            Sql("SET IDENTITY_INSERT Zipcodes ON INSERT INTO Zipcodes(Id, ZipcodeNum) VALUES (12, 53207)");
        }

        public override void Down()
        {
        }
    }
}
