using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class PromjenaIDteretanaKorisnik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Teretana_TeretanaID",
                table: "Korisnik");

            migrationBuilder.AlterColumn<int>(
                name: "TeretanaID",
                table: "Korisnik",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_Teretana_TeretanaID",
                table: "Korisnik",
                column: "TeretanaID",
                principalTable: "Teretana",
                principalColumn: "TeretanaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Teretana_TeretanaID",
                table: "Korisnik");

            migrationBuilder.AlterColumn<int>(
                name: "TeretanaID",
                table: "Korisnik",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_Teretana_TeretanaID",
                table: "Korisnik",
                column: "TeretanaID",
                principalTable: "Teretana",
                principalColumn: "TeretanaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
