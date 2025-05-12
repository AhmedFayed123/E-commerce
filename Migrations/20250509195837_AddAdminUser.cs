using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eStore.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [FirstName], [LastName], [ProfilePicture], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c28fad84-118e-4329-a89b-98dcfc1a5058', N'admin', N'ADMIN', N'admin@test.com', N'ADMIN@TEST.COM', 0, N'AQAAAAIAAYagAAAAEFJJ63YnIVutnCzrVCToWLzK9xoYgYAen2vbC2LqqrkeGD+THLMMsgCI2ILot6dvKw==', N'LIVJF24MZAPD6OOVG7K3TZGAKRIL7NZP', N'46d46d6c-c97c-4273-85d4-a11a9ec11ee6', NULL, N'Yousif ', N'Salah', NULL, 0, 0, NULL, 1, 0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetUsers] WHERE Id = 'c28fad84-118e-4329-a89b-98dcfc1a5058' ");
        }
    }
}
