using Microsoft.EntityFrameworkCore.Migrations;
using UserService.Data;

#nullable disable

namespace UserService.Migrations
{
    public partial class RiseFromYourGrave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "User"),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSysAdmin = table.Column<bool>(type: "bit", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiresIn = table.Column<int>(type: "int", nullable: true),
                    ExpiresOn = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            var password = "SysAdmin";
            Utility.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "IsSysAdmin", "Deleted" },
                values: new object[] { "SysAdmin", "Admin", "User", passwordHash, passwordSalt, true, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
