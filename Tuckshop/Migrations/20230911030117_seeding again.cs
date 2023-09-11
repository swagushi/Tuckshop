using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tuckshop.Migrations
{
    public partial class seedingagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentID", "PaymentAmount", "PaymentName", "PaymentStatement" },
                values: new object[] { 1, 3m, "Connor", "Fatu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentID",
                keyValue: 1);
        }
    }
}
