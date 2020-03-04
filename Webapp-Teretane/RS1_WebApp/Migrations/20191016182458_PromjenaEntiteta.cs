using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class PromjenaEntiteta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KorisnickoIme",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "Lozinka",
                table: "Korisnik");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KorisnickoIme",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lozinka",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
