using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FishingBlog.Migrations
{
    public partial class NewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                table: "Publications",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "NewsId",
                table: "Publications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Newses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Publications_NewsId",
                table: "Publications",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Newses_NewsId",
                table: "Publications",
                column: "NewsId",
                principalTable: "Newses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Newses_NewsId",
                table: "Publications");

            migrationBuilder.DropTable(
                name: "Newses");

            migrationBuilder.DropIndex(
                name: "IX_Publications_NewsId",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "NewsId",
                table: "Publications");

            migrationBuilder.AlterColumn<string>(
                name: "PublishedOn",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
