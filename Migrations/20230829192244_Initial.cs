using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artista",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_artista = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artista", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "musica",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_musica = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    duracao = table.Column<byte>(type: "tinyint", nullable: false),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false),
                    artista_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musica", x => x.id);
                    table.ForeignKey(
                        name: "FK_musica_artista_artista_id",
                        column: x => x.artista_id,
                        principalTable: "artista",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_musica_artista_id",
                table: "musica",
                column: "artista_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "musica");

            migrationBuilder.DropTable(
                name: "artista");
        }
    }
}
