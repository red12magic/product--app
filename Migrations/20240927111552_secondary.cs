using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace product__app.Migrations
{
    public partial class secondary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "BookName", "BookPrice", "UserID" },
                values: new object[] { 1, "Casablanca", 14.99m, 0 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "BookName", "BookPrice", "UserID" },
                values: new object[] { 2, "Book 2", 20m, 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Password", "Username" },
                values: new object[] { 1, "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Books");
        }
    }
}
