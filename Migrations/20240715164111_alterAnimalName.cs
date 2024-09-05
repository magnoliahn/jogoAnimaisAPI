using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jogoAnimaisAPI.Migrations
{
    /// <inheritdoc />
    public partial class alterAnimalName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "personagens",
                keyColumn: "personagemId",
                keyValue: 3,
                column: "personagemNome",
                value: "hipopótamo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "personagens",
                keyColumn: "personagemId",
                keyValue: 3,
                column: "personagemNome",
                value: "hipopótamomo");
        }
    }
}
