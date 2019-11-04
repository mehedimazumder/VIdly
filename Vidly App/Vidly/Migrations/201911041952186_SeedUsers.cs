namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'33d41f96-62fd-42c0-b8cc-23be32b665d0', N'guest@gmail.com', 0, N'AMaHP68qcO92LGwmKY+i4yo1gXgwwWz0b41798cDTt67+CvsSbmde+l4irh05MTdVQ==', N'74e18cc9-618f-4460-a1d4-21c23aecde51', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4efeac88-7bf6-4b93-bb9e-14c30e965206', N'admin@gmail.com', 0, N'ACWCF4UpRXGlx6xQ5Qh34vNQGfcL1NevOGARZXDeZAMhEbwKVX1vIZ1A9DSwmccMdg==', N'0d3a44fc-f8b9-4a36-a3c5-dc8b790ca566', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'90314ea9-fef2-4a32-9593-2ad50cfa89f7', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4efeac88-7bf6-4b93-bb9e-14c30e965206', N'90314ea9-fef2-4a32-9593-2ad50cfa89f7')

");
        }
        
        public override void Down()
        {
        }
    }
}
