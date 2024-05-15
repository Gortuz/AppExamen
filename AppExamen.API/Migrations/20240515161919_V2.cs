using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppExamen.API.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ataque",
                table: "Pokemon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defensa",
                table: "Pokemon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Velocidad",
                table: "Pokemon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ataque",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "Defensa",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "Velocidad",
                table: "Pokemon");
        }
    }
}
