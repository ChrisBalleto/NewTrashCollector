namespace Trash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMembershipTypesAndDaysOfWeek : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT DayOfWeekPickUps ON INSERT INTO DayOfWeekPickUps(Id, DayOfWeek) VALUES (1, 'Sunday')");
            Sql("SET IDENTITY_INSERT DayOfWeekPickUps ON INSERT INTO DayOfWeekPickUps(Id, DayOfWeek) VALUES (2, 'Monday')");
            Sql("SET IDENTITY_INSERT DayOfWeekPickUps ON INSERT INTO DayOfWeekPickUps(Id, DayOfWeek) VALUES (3, 'Tuesday')");
            Sql("SET IDENTITY_INSERT DayOfWeekPickUps ON INSERT INTO DayOfWeekPickUps(Id, DayOfWeek) VALUES (4, 'Wednesday')");
            Sql("SET IDENTITY_INSERT DayOfWeekPickUps ON INSERT INTO DayOfWeekPickUps(Id, DayOfWeek) VALUES (5, 'Thursday')");
            Sql("SET IDENTITY_INSERT DayOfWeekPickUps ON INSERT INTO DayOfWeekPickUps(Id, DayOfWeek) VALUES (6, 'Friday')");
            Sql("SET IDENTITY_INSERT DayOfWeekPickUps ON INSERT INTO DayOfWeekPickUps(Id, DayOfWeek) VALUES (7, 'Saturday')");


        }
        
        public override void Down()
        {
        }
    }
}
