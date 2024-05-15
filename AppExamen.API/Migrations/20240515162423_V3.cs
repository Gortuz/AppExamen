using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppExamen.API.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ataque_Especial",
                table: "Pokemon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defensa_Especial",
                table: "Pokemon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ataque_Especial",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "Defensa_Especial",
                table: "Pokemon");
        }
    }
}
