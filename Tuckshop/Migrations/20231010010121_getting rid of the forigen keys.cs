using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tuckshop.Migrations
{
    public partial class gettingridoftheforigenkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Food_FoodID",
                table: "Student");

            migrationBuilder.DropTable(
                name: "FoodRequest");

            migrationBuilder.DropIndex(
                name: "IX_Student_FoodID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "FoodID",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "RequestID",
                table: "Food",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Food_RequestID",
                table: "Food",
                column: "RequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Request_RequestID",
                table: "Food",
                column: "RequestID",
                principalTable: "Request",
                principalColumn: "RequestID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Request_RequestID",
                table: "Food");

            migrationBuilder.DropIndex(
                name: "IX_Food_RequestID",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "RequestID",
                table: "Food");

            migrationBuilder.AddColumn<int>(
                name: "FoodID",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FoodRequest",
                columns: table => new
                {
                    FoodID = table.Column<int>(type: "int", nullable: false),
                    RequestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRequest", x => new { x.FoodID, x.RequestID });
                    table.ForeignKey(
                        name: "FK_FoodRequest_Food_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Food",
                        principalColumn: "FoodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodRequest_Request_RequestID",
                        column: x => x.RequestID,
                        principalTable: "Request",
                        principalColumn: "RequestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_FoodID",
                table: "Student",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRequest_RequestID",
                table: "FoodRequest",
                column: "RequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Food_FoodID",
                table: "Student",
                column: "FoodID",
                principalTable: "Food",
                principalColumn: "FoodID");
        }
    }
}
