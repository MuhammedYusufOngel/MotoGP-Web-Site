using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGP_Web_Site.Migrations
{
    public partial class nationals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamChamps_National_NationalId",
                table: "TeamChamps");

            migrationBuilder.DropIndex(
                name: "IX_TeamChamps_NationalId",
                table: "TeamChamps");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "TeamChamps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NationalId",
                table: "TeamChamps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TeamChamps_NationalId",
                table: "TeamChamps",
                column: "NationalId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamChamps_National_NationalId",
                table: "TeamChamps",
                column: "NationalId",
                principalTable: "National",
                principalColumn: "NationalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
