using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGP_Web_Site.Migrations
{
    public partial class manuTrueFalse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAdd",
                table: "ManuChamps",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAdd",
                table: "ManuChamps");
        }
    }
}
