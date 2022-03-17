using Microsoft.EntityFrameworkCore.Migrations;

namespace FishingBlog.Migrations
{
    public partial class AdminTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Administrators_AdministratorId",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Publications_AdministratorId",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "AdministratorId",
                table: "Publications");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_AdminId",
                table: "Publications",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Administrators_AdminId",
                table: "Publications",
                column: "AdminId",
                principalTable: "Administrators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Administrators_AdminId",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Publications_AdminId",
                table: "Publications");

            migrationBuilder.AddColumn<int>(
                name: "AdministratorId",
                table: "Publications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publications_AdministratorId",
                table: "Publications",
                column: "AdministratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Administrators_AdministratorId",
                table: "Publications",
                column: "AdministratorId",
                principalTable: "Administrators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
