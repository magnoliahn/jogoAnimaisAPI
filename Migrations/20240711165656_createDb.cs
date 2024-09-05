using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jogoAnimaisAPI.Migrations
{
    /// <inheritdoc />
    public partial class createDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personagens",
                columns: table => new
                {
                    personagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personageNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    posicaoPersonagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personagens", x => x.personagemId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personagens");
        }
    }
}
