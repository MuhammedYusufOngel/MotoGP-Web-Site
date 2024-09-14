using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGP_Web_Site.Migrations
{
    public partial class tracknational : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NationalId",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_NationalId",
                table: "Tracks",
                column: "NationalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_National_NationalId",
                table: "Tracks",
                column: "NationalId",
                principalTable: "National",
                principalColumn: "NationalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_National_NationalId",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_NationalId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "Tracks");
        }
    }
}
