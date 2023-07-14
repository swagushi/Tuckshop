using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tuckshop.Migrations
{
    public partial class updatedorders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Order_OrderID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_OrderID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Student");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOrdered",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "FoodOrder",
                columns: table => new
                {
                    FoodID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodOrder", x => new { x.FoodID, x.OrderID });
                    table.ForeignKey(
                        name: "FK_FoodOrder_Food_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Food",
                        principalColumn: "FoodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodOrder_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderStudent",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStudent", x => new { x.OrderID, x.StudentID });
                    table.ForeignKey(
                        name: "FK_OrderStudent_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderStudent_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrder_OrderID",
                table: "FoodOrder",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStudent_StudentID",
                table: "OrderStudent",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodOrder");

            migrationBuilder.DropTable(
                name: "OrderStudent");

            migrationBuilder.DropColumn(
                name: "DateOrdered",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_OrderID",
                table: "Student",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Order_OrderID",
                table: "Student",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID");
        }
    }
}
