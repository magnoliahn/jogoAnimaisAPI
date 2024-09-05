using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jogoAnimaisAPI.Migrations
{
    /// <inheritdoc />
    public partial class alterColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "personageNome",
                table: "personagens",
                newName: "personagemNome");

            migrationBuilder.UpdateData(
                table: "personagens",
                keyColumn: "personagemId",
                keyValue: 3,
                column: "personagemNome",
                value: "hipopótamomo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "personagemNome",
                table: "personagens",
                newName: "personageNome");

            migrationBuilder.UpdateData(
                table: "personagens",
                keyColumn: "personagemId",
                keyValue: 3,
                column: "personageNome",
                value: "hipopotámo");
        }
    }
}
