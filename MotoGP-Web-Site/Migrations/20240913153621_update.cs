using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGP_Web_Site.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverChamps_Drivers_DriverId",
                table: "DriverChamps");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "DriverChamps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverChamps_Drivers_DriverId",
                table: "DriverChamps",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverChamps_Drivers_DriverId",
                table: "DriverChamps");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "DriverChamps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverChamps_Drivers_DriverId",
                table: "DriverChamps",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
