using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tuckshop.Migrations
{
    public partial class fixedERDhopefully : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Request_RequestID",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Payment_PaymentID",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Payment_PaymentID",
                table: "Student");

            migrationBuilder.DropTable(
                name: "RequestStudent");

            migrationBuilder.DropIndex(
                name: "IX_Student_PaymentID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Request_PaymentID",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Food_RequestID",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "RequestID",
                table: "Food");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentID",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodID",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Request_FoodID",
                table: "Request",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_PaymentID",
                table: "Request",
                column: "PaymentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_StudentID",
                table: "Request",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Food_FoodID",
                table: "Request",
                column: "FoodID",
                principalTable: "Food",
                principalColumn: "FoodID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Payment_PaymentID",
                table: "Request",
                column: "PaymentID",
                principalTable: "Payment",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Student_StudentID",
                table: "Request",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Food_FoodID",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Payment_PaymentID",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Student_StudentID",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_FoodID",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_PaymentID",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_StudentID",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "FoodID",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Request");

            migrationBuilder.AddColumn<int>(
                name: "PaymentID",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentID",
                table: "Request",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RequestID",
                table: "Food",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RequestStudent",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStudent", x => new { x.RequestID, x.StudentID });
                    table.ForeignKey(
                        name: "FK_RequestStudent_Request_RequestID",
                        column: x => x.RequestID,
                        principalTable: "Request",
                        principalColumn: "RequestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestStudent_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_PaymentID",
                table: "Student",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_PaymentID",
                table: "Request",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Food_RequestID",
                table: "Food",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestStudent_StudentID",
                table: "RequestStudent",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Request_RequestID",
                table: "Food",
                column: "RequestID",
                principalTable: "Request",
                principalColumn: "RequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Payment_PaymentID",
                table: "Request",
                column: "PaymentID",
                principalTable: "Payment",
                principalColumn: "PaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Payment_PaymentID",
                table: "Student",
                column: "PaymentID",
                principalTable: "Payment",
                principalColumn: "PaymentID");
        }
    }
}
