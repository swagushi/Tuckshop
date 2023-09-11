using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tuckshop.Migrations
{
    public partial class Seedingpt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentID", "FirstName", "FoodID", "Homeroom", "LastName", "PaymentID" },
                values: new object[] { 4, "Muhammad", null, "2", "Sherry", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: 4);
        }
    }
}
