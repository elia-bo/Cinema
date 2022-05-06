using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Durata = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Biglietti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fila = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Posto = table.Column<int>(type: "int", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false),
                    IdSpettatore = table.Column<int>(type: "int", nullable: true),
                    IdFilm = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biglietti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biglietti_Film_IdFilm",
                        column: x => x.IdFilm,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxNumSpettatori = table.Column<int>(type: "int", nullable: false),
                    IdFilmInCorso = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sale_Film_IdFilmInCorso",
                        column: x => x.IdFilmInCorso,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spettatori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataNascita = table.Column<DateTime>(type: "date", nullable: false),
                    Maggiorenne = table.Column<bool>(type: "bit", nullable: false),
                    Eta = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: true),
                    IdBiglietto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spettatori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spettatori_Biglietti_IdBiglietto",
                        column: x => x.IdBiglietto,
                        principalTable: "Biglietti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spettatori_Sale_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biglietti_IdFilm",
                table: "Biglietti",
                column: "IdFilm");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_IdFilmInCorso",
                table: "Sale",
                column: "IdFilmInCorso",
                unique: true,
                filter: "[IdFilmInCorso] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Spettatori_IdBiglietto",
                table: "Spettatori",
                column: "IdBiglietto",
                unique: true,
                filter: "[IdBiglietto] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Spettatori_SalaId",
                table: "Spettatori",
                column: "SalaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spettatori");

            migrationBuilder.DropTable(
                name: "Biglietti");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Film");
        }
    }
}
