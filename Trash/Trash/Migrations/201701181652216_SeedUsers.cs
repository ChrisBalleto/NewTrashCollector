namespace Trash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'893de7c7-70b1-4c2d-9344-f5d59eef160b', N'admin@gyj.com', 0, N'AFR+1h3xjANVXt/tJK++1RBk3CwlifOW5kQH+tSEnBq2PbqLeb7BylSUcdNFPNnD9w==', N'2a7eb8e0-ea0d-481e-9261-454f21f585f9', NULL, 0, 0, NULL, 1, 0, N'admin@gyj.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd7b7af26-99a6-4e46-9047-6151ed173c39', N'maikorlauj@gmail.com', 0, N'AA3KmzxUWjRMjsGobrB6/p+PYvPJhh6pfKXd5f2DOlQmyDmUs8jmofHEm5aUDL09NA==', N'efe4dad4-5e61-4511-84a9-00b52e5383cf', NULL, 0, 0, NULL, 1, 0, N'maikorlauj@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6da45d5c-ad84-4395-9f32-832fb2d4e14f', N'CanManageForm')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'893de7c7-70b1-4c2d-9344-f5d59eef160b', N'6da45d5c-ad84-4395-9f32-832fb2d4e14f')

");
        }
        
        public override void Down()
        {
        }
    }
}
