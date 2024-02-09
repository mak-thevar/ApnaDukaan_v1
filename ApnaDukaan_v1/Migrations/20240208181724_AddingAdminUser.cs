using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApnaDukaan_v1.Migrations
{
    public partial class AddingAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DOB", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "PhoneNo", "RoleId", "Username" },
                values: new object[] { 1, null, "mak.thevar@outlook.com", "Mak", null, "Thevar", "AQAAAAEAACcQAAAAEB612RH/X0CfAJ85yOS2FS2XSZp81H+9VUfcpJi/2+Uxu3VW5SdKjnKC+eH741oKjw==", "9888888888", 2, "mkthevar" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
