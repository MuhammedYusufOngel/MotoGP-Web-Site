using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGP_Web_Site.Migrations
{
    public partial class yearForeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "TeamChamps");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "ManuChamps");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "DriverChamps");

            migrationBuilder.AddColumn<int>(
                name: "YearId",
                table: "TeamChamps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearId",
                table: "Results",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearId",
                table: "ManuChamps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearId",
                table: "DriverChamps",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamChamps_YearId",
                table: "TeamChamps",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_YearId",
                table: "Results",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_ManuChamps_YearId",
                table: "ManuChamps",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverChamps_YearId",
                table: "DriverChamps",
                column: "YearId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverChamps_Years_YearId",
                table: "DriverChamps",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "YearId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManuChamps_Years_YearId",
                table: "ManuChamps",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "YearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Years_YearId",
                table: "Results",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "YearId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamChamps_Years_YearId",
                table: "TeamChamps",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "YearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverChamps_Years_YearId",
                table: "DriverChamps");

            migrationBuilder.DropForeignKey(
                name: "FK_ManuChamps_Years_YearId",
                table: "ManuChamps");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Years_YearId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamChamps_Years_YearId",
                table: "TeamChamps");

            migrationBuilder.DropIndex(
                name: "IX_TeamChamps_YearId",
                table: "TeamChamps");

            migrationBuilder.DropIndex(
                name: "IX_Results_YearId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_ManuChamps_YearId",
                table: "ManuChamps");

            migrationBuilder.DropIndex(
                name: "IX_DriverChamps_YearId",
                table: "DriverChamps");

            migrationBuilder.DropColumn(
                name: "YearId",
                table: "TeamChamps");

            migrationBuilder.DropColumn(
                name: "YearId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "YearId",
                table: "ManuChamps");

            migrationBuilder.DropColumn(
                name: "YearId",
                table: "DriverChamps");

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "TeamChamps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "ManuChamps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "DriverChamps",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
