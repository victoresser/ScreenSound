using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class FixBandaMusicaRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_musica_artista_artista_id",
                table: "musica");

            migrationBuilder.RenameColumn(
                name: "Disponivel",
                table: "musica",
                newName: "disponivel");

            migrationBuilder.AddForeignKey(
                name: "FK_musica_artista_artista_id",
                table: "musica",
                column: "artista_id",
                principalTable: "artista",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_musica_artista_artista_id",
                table: "musica");

            migrationBuilder.RenameColumn(
                name: "disponivel",
                table: "musica",
                newName: "Disponivel");

            migrationBuilder.AddForeignKey(
                name: "FK_musica_artista_artista_id",
                table: "musica",
                column: "artista_id",
                principalTable: "artista",
                principalColumn: "id");
        }
    }
}
