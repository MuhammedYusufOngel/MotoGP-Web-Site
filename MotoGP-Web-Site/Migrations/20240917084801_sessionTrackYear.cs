using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGP_Web_Site.Migrations
{
    public partial class sessionTrackYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Years_YearId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_YearId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "SessionTracks");

            migrationBuilder.DropColumn(
                name: "YearId",
                table: "Results");

            migrationBuilder.AddColumn<int>(
                name: "YearId",
                table: "SessionTracks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionTracks_YearId",
                table: "SessionTracks",
                column: "YearId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionTracks_Years_YearId",
                table: "SessionTracks",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "YearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionTracks_Years_YearId",
                table: "SessionTracks");

            migrationBuilder.DropIndex(
                name: "IX_SessionTracks_YearId",
                table: "SessionTracks");

            migrationBuilder.DropColumn(
                name: "YearId",
                table: "SessionTracks");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "SessionTracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearId",
                table: "Results",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_YearId",
                table: "Results",
                column: "YearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Years_YearId",
                table: "Results",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "YearId");
        }
    }
}
