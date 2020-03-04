using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class DodavanjeKorisnickogNaloga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KorisnickiNalogID",
                table: "Korisnik",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_KorisnickiNalogID",
                table: "Korisnik",
                column: "KorisnickiNalogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_KorisnickiNalog_KorisnickiNalogID",
                table: "Korisnik",
                column: "KorisnickiNalogID",
                principalTable: "KorisnickiNalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_KorisnickiNalog_KorisnickiNalogID",
                table: "Korisnik");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");

            migrationBuilder.DropIndex(
                name: "IX_Korisnik_KorisnickiNalogID",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "KorisnickiNalogID",
                table: "Korisnik");
        }
    }
}
