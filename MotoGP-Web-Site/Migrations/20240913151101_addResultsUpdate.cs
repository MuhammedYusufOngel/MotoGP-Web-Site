using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGP_Web_Site.Migrations
{
    public partial class addResultsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Drivers_DriverId",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "DriverId",
                table: "Results",
                newName: "DriverChampId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_DriverId",
                table: "Results",
                newName: "IX_Results_DriverChampId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_DriverChamps_DriverChampId",
                table: "Results",
                column: "DriverChampId",
                principalTable: "DriverChamps",
                principalColumn: "DriverChampId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_DriverChamps_DriverChampId",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "DriverChampId",
                table: "Results",
                newName: "DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_DriverChampId",
                table: "Results",
                newName: "IX_Results_DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Drivers_DriverId",
                table: "Results",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
