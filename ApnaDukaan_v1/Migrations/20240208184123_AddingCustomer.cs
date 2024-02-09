using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApnaDukaan_v1.Migrations
{
    public partial class AddingCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAENyoSl0NLDSaKGlekdGzQSlYCY0Eek408Gc6JiYV0HOOIiVVmTTk5JVr7OnsfRk3wQ==");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DOB", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "PhoneNo", "RoleId", "Username" },
                values: new object[] { 2, new DateTime(2004, 2, 9, 0, 0, 0, 0, DateTimeKind.Local), "punit@gmail.com", "Punit", 1, "Gupta", "AQAAAAEAACcQAAAAEFUJb8b0MnzmhkNKIwaQyO4G20T+HNuhVQ6eO1sYKiaKPw5FYJLX0EO4QADBozf5bA==", "9888888881", 1, "punit" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Landmark", "Pincode", "State", "StreetAddress", "UserId" },
                values: new object[] { 1, "Mumbai", "something", "400701", "Maharashtra", "Some street", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEB612RH/X0CfAJ85yOS2FS2XSZp81H+9VUfcpJi/2+Uxu3VW5SdKjnKC+eH741oKjw==");
        }
    }
}
