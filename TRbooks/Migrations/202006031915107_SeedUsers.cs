namespace TRbooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6fdc62aa-0f18-4801-ba8d-318c992242a5', N'guest@gmail.com', 0, N'AK+cgHA46sQX0Vj8/yg1m7Rjbiz6vQUQSHOYWWW37xHRyOrCSGMXLFXAG5CtwV2cxA==', N'94517c0f-3ae3-4d76-b667-5098abca23f1', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd31cb252-4c2b-4a02-bf43-3fd0260c894c', N'admin@gmail.com', 0, N'AEv03HXQph9cx4a/k9X6fHN2vyHiBcoS6FRk/tnkIdSSjDOjhkJ64ZMehyxkR4hyKA==', N'89a348ed-546f-4119-a5c5-7217d1b44c46', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'14b1cdbd-3093-4f4b-8713-d214e9dfa506', N'CanManageBooks')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd31cb252-4c2b-4a02-bf43-3fd0260c894c', N'14b1cdbd-3093-4f4b-8713-d214e9dfa506')


                ");
        }
        
        public override void Down()
        {
        }
    }
}
