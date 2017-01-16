namespace Trash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class membershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT MembershipTypes ON INSERT INTO MembershipTypes(Id, MembershipName, PickUpRate) VALUES (1, 'One Time Pick-Up', 10)");
            Sql("SET IDENTITY_INSERT MembershipTypes ON INSERT INTO MembershipTypes(Id, MembershipName, PickUpRate) VALUES (2, 'Weekly', 8)");
        }
        
        public override void Down()
        {
        }
    }
}
