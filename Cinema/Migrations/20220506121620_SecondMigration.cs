using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Biglietti",
                columns: new[] { "Id", "Fila", "IdFilm", "IdSpettatore", "Posto", "Prezzo" },
                values: new object[,]
                {
                    { 1, "A", null, null, 5, 20.0 },
                    { 2, "G", null, null, 7, 13.0 },
                    { 3, "D", null, null, 2, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Film",
                columns: new[] { "Id", "Autore", "Durata", "Genere", "Produttore", "TitoloFilm" },
                values: new object[,]
                {
                    { 1, "Cesare", 200, 0, "Alberto", "Matrix" },
                    { 2, "Gino", 150, 3, "Giacomo", "Top Gun" },
                    { 3, "Luca", 190, 1, "Paolo", "Scream" }
                });

            migrationBuilder.InsertData(
                table: "Sale",
                columns: new[] { "Id", "IdFilmInCorso", "MaxNumSpettatori" },
                values: new object[,]
                {
                    { 1, null, 200 },
                    { 2, null, 300 }
                });

            migrationBuilder.InsertData(
                table: "Spettatori",
                columns: new[] { "Id", "Cognome", "DataNascita", "Eta", "IdBiglietto", "Maggiorenne", "Nome", "SalaId" },
                values: new object[,]
                {
                    { 1, "Alby", new DateTime(2014, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, null, false, "Alberto", null },
                    { 2, "Gallo", new DateTime(1980, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, null, true, "Mario", null },
                    { 3, "Gallo", new DateTime(1970, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, null, true, "Giacomo", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Biglietti",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Biglietti",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Biglietti",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Film",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Film",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Film",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Spettatori",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Spettatori",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Spettatori",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
