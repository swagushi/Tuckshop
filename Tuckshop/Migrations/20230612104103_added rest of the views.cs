using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tuckshop.Migrations
{
    public partial class addedrestoftheviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodID",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentID",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentID",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    FoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrinkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.FoodID);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentAmount = table.Column<int>(type: "int", nullable: false),
                    PaymentStatement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payment_Food_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Food",
                        principalColumn: "FoodID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_FoodID",
                table: "Student",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_PaymentID",
                table: "Student",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentID",
                table: "Order",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_FoodID",
                table: "Payment",
                column: "FoodID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Payment_PaymentID",
                table: "Order",
                column: "PaymentID",
                principalTable: "Payment",
                principalColumn: "PaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Food_FoodID",
                table: "Student",
                column: "FoodID",
                principalTable: "Food",
                principalColumn: "FoodID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Payment_PaymentID",
                table: "Student",
                column: "PaymentID",
                principalTable: "Payment",
                principalColumn: "PaymentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Payment_PaymentID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Food_FoodID",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Payment_PaymentID",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropIndex(
                name: "IX_Student_FoodID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_PaymentID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Order_PaymentID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "FoodID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "Order");
        }
    }
}
