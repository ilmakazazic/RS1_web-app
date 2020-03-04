using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class Obavijest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Obavijest_Korisnik_ClanID",
            //    table: "Obavijest");

            //migrationBuilder.DropIndex(
            //    name: "IX_Obavijest_ClanID",
            //    table: "Obavijest");

            //migrationBuilder.DropColumn(
            //    name: "ClanID",
            //    table: "Obavijest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClanID",
                table: "Obavijest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_ClanID",
                table: "Obavijest",
                column: "ClanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Obavijest_Korisnik_ClanID",
                table: "Obavijest",
                column: "ClanID",
                principalTable: "Korisnik",
                principalColumn: "KorisnikID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
