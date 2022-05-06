using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biglietto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fila = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Posto = table.Column<int>(type: "int", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biglietto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitoloFilm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Autore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Produttore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genere = table.Column<int>(type: "int", nullable: false),
                    Durata = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxNumSpettatori = table.Column<int>(type: "int", nullable: false),
                    IdFilmInCorso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sala_Film_IdFilmInCorso",
                        column: x => x.IdFilmInCorso,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spettatore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataNascita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Maggiorenne = table.Column<bool>(type: "bit", nullable: false),
                    Eta = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: true),
                    IdBiglietto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spettatore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spettatore_Biglietto_IdBiglietto",
                        column: x => x.IdBiglietto,
                        principalTable: "Biglietto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Spettatore_Sala_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Sala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sala_IdFilmInCorso",
                table: "Sala",
                column: "IdFilmInCorso",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spettatore_IdBiglietto",
                table: "Spettatore",
                column: "IdBiglietto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spettatore_SalaId",
                table: "Spettatore",
                column: "SalaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spettatore");

            migrationBuilder.DropTable(
                name: "Biglietto");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Film");
        }
    }
}
