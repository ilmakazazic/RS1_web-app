using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class login5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KorisnickoIme",
                table: "Clan");

            migrationBuilder.DropColumn(
                name: "Lozinka",
                table: "Clan");

            migrationBuilder.CreateIndex(
                name: "IX_Clan_NalogID",
                table: "Clan",
                column: "NalogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clan_KorisnickiNalog_NalogID",
                table: "Clan",
                column: "NalogID",
                principalTable: "KorisnickiNalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clan_KorisnickiNalog_NalogID",
                table: "Clan");

            migrationBuilder.DropIndex(
                name: "IX_Clan_NalogID",
                table: "Clan");

            migrationBuilder.AddColumn<string>(
                name: "KorisnickoIme",
                table: "Clan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lozinka",
                table: "Clan",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
