using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assegnamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSala = table.Column<int>(type: "int", nullable: false),
                    IdSpettatore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assegnamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assegnamento_Sale_IdSala",
                        column: x => x.IdSala,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assegnamento_Spettatori_IdSpettatore",
                        column: x => x.IdSpettatore,
                        principalTable: "Spettatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assegnamento_IdSala",
                table: "Assegnamento",
                column: "IdSala");

            migrationBuilder.CreateIndex(
                name: "IX_Assegnamento_IdSpettatore",
                table: "Assegnamento",
                column: "IdSpettatore");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assegnamento");
        }
    }
}
