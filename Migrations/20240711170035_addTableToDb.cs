using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace jogoAnimaisAPI.Migrations
{
    /// <inheritdoc />
    public partial class addTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "personagens",
                columns: new[] { "personagemId", "personageNome", "posicaoPersonagem" },
                values: new object[,]
                {
                    { 1, "zebra", "Direita" },
                    { 2, "leão", "Direita" },
                    { 3, "hipopotámo", "Direita" },
                    { 4, "guarda", "Direita" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "personagens",
                keyColumn: "personagemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "personagens",
                keyColumn: "personagemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "personagens",
                keyColumn: "personagemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "personagens",
                keyColumn: "personagemId",
                keyValue: 4);
        }
    }
}
