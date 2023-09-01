using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class UniqueConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_musica_nome_musica",
                table: "musica",
                column: "nome_musica");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_artista_nome_artista",
                table: "artista",
                column: "nome_artista");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_musica_nome_musica",
                table: "musica");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_artista_nome_artista",
                table: "artista");
        }
    }
}
