using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class Avaliacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "avaliacao_banda",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    banda_id = table.Column<int>(type: "int", nullable: false),
                    rated_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avaliacao_banda", x => x.id);
                    table.ForeignKey(
                        name: "FK_avaliacao_banda_artista_banda_id",
                        column: x => x.banda_id,
                        principalTable: "artista",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "avaliacao_musica",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    musica_id = table.Column<int>(type: "int", nullable: false),
                    rated_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avaliacao_musica", x => x.id);
                    table.ForeignKey(
                        name: "FK_avaliacao_musica_musica_musica_id",
                        column: x => x.musica_id,
                        principalTable: "musica",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "avalicao_album",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    album_id = table.Column<int>(type: "int", nullable: false),
                    rated_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avalicao_album", x => x.id);
                    table.ForeignKey(
                        name: "FK_avalicao_album_album_album_id",
                        column: x => x.album_id,
                        principalTable: "album",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_avaliacao_banda_banda_id",
                table: "avaliacao_banda",
                column: "banda_id");

            migrationBuilder.CreateIndex(
                name: "IX_avaliacao_musica_musica_id",
                table: "avaliacao_musica",
                column: "musica_id");

            migrationBuilder.CreateIndex(
                name: "IX_avalicao_album_album_id",
                table: "avalicao_album",
                column: "album_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "avaliacao_banda");

            migrationBuilder.DropTable(
                name: "avaliacao_musica");

            migrationBuilder.DropTable(
                name: "avalicao_album");
        }
    }
}
