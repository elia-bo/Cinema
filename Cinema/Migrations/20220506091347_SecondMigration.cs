using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sala_Film_IdFilmInCorso",
                table: "Sala");

            migrationBuilder.DropForeignKey(
                name: "FK_Spettatore_Biglietto_IdBiglietto",
                table: "Spettatore");

            migrationBuilder.DropForeignKey(
                name: "FK_Spettatore_Sala_SalaId",
                table: "Spettatore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Spettatore",
                table: "Spettatore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sala",
                table: "Sala");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Biglietto",
                table: "Biglietto");

            migrationBuilder.RenameTable(
                name: "Spettatore",
                newName: "Spettatori");

            migrationBuilder.RenameTable(
                name: "Sala",
                newName: "Sale");

            migrationBuilder.RenameTable(
                name: "Biglietto",
                newName: "Biglietti");

            migrationBuilder.RenameIndex(
                name: "IX_Spettatore_SalaId",
                table: "Spettatori",
                newName: "IX_Spettatori_SalaId");

            migrationBuilder.RenameIndex(
                name: "IX_Spettatore_IdBiglietto",
                table: "Spettatori",
                newName: "IX_Spettatori_IdBiglietto");

            migrationBuilder.RenameIndex(
                name: "IX_Sala_IdFilmInCorso",
                table: "Sale",
                newName: "IX_Sale_IdFilmInCorso");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Spettatori",
                table: "Spettatori",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sale",
                table: "Sale",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Biglietti",
                table: "Biglietti",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Film_IdFilmInCorso",
                table: "Sale",
                column: "IdFilmInCorso",
                principalTable: "Film",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spettatori_Biglietti_IdBiglietto",
                table: "Spettatori",
                column: "IdBiglietto",
                principalTable: "Biglietti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spettatori_Sale_SalaId",
                table: "Spettatori",
                column: "SalaId",
                principalTable: "Sale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Film_IdFilmInCorso",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Spettatori_Biglietti_IdBiglietto",
                table: "Spettatori");

            migrationBuilder.DropForeignKey(
                name: "FK_Spettatori_Sale_SalaId",
                table: "Spettatori");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Spettatori",
                table: "Spettatori");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sale",
                table: "Sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Biglietti",
                table: "Biglietti");

            migrationBuilder.RenameTable(
                name: "Spettatori",
                newName: "Spettatore");

            migrationBuilder.RenameTable(
                name: "Sale",
                newName: "Sala");

            migrationBuilder.RenameTable(
                name: "Biglietti",
                newName: "Biglietto");

            migrationBuilder.RenameIndex(
                name: "IX_Spettatori_SalaId",
                table: "Spettatore",
                newName: "IX_Spettatore_SalaId");

            migrationBuilder.RenameIndex(
                name: "IX_Spettatori_IdBiglietto",
                table: "Spettatore",
                newName: "IX_Spettatore_IdBiglietto");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_IdFilmInCorso",
                table: "Sala",
                newName: "IX_Sala_IdFilmInCorso");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Spettatore",
                table: "Spettatore",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sala",
                table: "Sala",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Biglietto",
                table: "Biglietto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sala_Film_IdFilmInCorso",
                table: "Sala",
                column: "IdFilmInCorso",
                principalTable: "Film",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spettatore_Biglietto_IdBiglietto",
                table: "Spettatore",
                column: "IdBiglietto",
                principalTable: "Biglietto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spettatore_Sala_SalaId",
                table: "Spettatore",
                column: "SalaId",
                principalTable: "Sala",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
