namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'90166b1d-e47f-4f0d-92d7-017ded8f3051', N'admin@vidly.com', 0, N'ABWXnfqrJ/oaUm0Zx1ckV7c/rJ/N1xH7tDR1EvpiZYe5aZY6v9jc6MVysA1qkd0hHg==', N'9fe676b8-5c4c-41a8-a612-538f3dd286f8', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ad82a6ad-900e-4491-81c1-e5de55fc7943', N'guest@vidly.com', 0, N'AFFiN4/oLGuoeVMDNb/+58zvcm+/2KmaClhqb8i9jaCNGBj8OcTLaAjNCPkYY3TjWA==', N'5027752f-b46c-41da-a2dd-61cfb791c1ee', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9111bcf4-d828-44e7-80c5-8e427c853c56', N'CanManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'90166b1d-e47f-4f0d-92d7-017ded8f3051', N'9111bcf4-d828-44e7-80c5-8e427c853c56')

");
        }
        
        public override void Down()
        {
        }
    }
}
