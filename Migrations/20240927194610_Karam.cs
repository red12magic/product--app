using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace product__app.Migrations
{
    public partial class Karam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Password", "Username" },
                values: new object[] { 1, "admin", "admin" });
        }
    }
}
