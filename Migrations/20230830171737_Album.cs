using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class Album : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_musica_artista_artista_id",
                table: "musica");

            migrationBuilder.AddColumn<int>(
                name: "album_id",
                table: "musica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "musica",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "artista",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.CreateTable(
                name: "album",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_album = table.Column<string>(type: "varchar(50)", nullable: false),
                    artista_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_album", x => x.id);
                    table.UniqueConstraint("AK_album_nome_album", x => x.nome_album);
                    table.ForeignKey(
                        name: "FK_album_artista_artista_id",
                        column: x => x.artista_id,
                        principalTable: "artista",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_musica_album_id",
                table: "musica",
                column: "album_id");

            migrationBuilder.CreateIndex(
                name: "IX_album_artista_id",
                table: "album",
                column: "artista_id");

            migrationBuilder.AddForeignKey(
                name: "FK_musica_album_album_id",
                table: "musica",
                column: "album_id",
                principalTable: "album",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_musica_artista_artista_id",
                table: "musica",
                column: "artista_id",
                principalTable: "artista",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_musica_album_album_id",
                table: "musica");

            migrationBuilder.DropForeignKey(
                name: "FK_musica_artista_artista_id",
                table: "musica");

            migrationBuilder.DropTable(
                name: "album");

            migrationBuilder.DropIndex(
                name: "IX_musica_album_id",
                table: "musica");

            migrationBuilder.DropColumn(
                name: "album_id",
                table: "musica");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "musica");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "artista");

            migrationBuilder.AddForeignKey(
                name: "FK_musica_artista_artista_id",
                table: "musica",
                column: "artista_id",
                principalTable: "artista",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
