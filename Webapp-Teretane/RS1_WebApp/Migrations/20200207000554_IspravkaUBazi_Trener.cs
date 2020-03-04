using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class IspravkaUBazi_Trener : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KorisnickoIme",
                table: "Trener");

            migrationBuilder.DropColumn(
                name: "Lozinka",
                table: "Trener");

            migrationBuilder.AddColumn<int>(
                name: "NalogID",
                table: "Trener",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trener_NalogID",
                table: "Trener",
                column: "NalogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trener_KorisnickiNalog_NalogID",
                table: "Trener",
                column: "NalogID",
                principalTable: "KorisnickiNalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trener_KorisnickiNalog_NalogID",
                table: "Trener");

            migrationBuilder.DropIndex(
                name: "IX_Trener_NalogID",
                table: "Trener");

            migrationBuilder.DropColumn(
                name: "NalogID",
                table: "Trener");

            migrationBuilder.AddColumn<string>(
                name: "KorisnickoIme",
                table: "Trener",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lozinka",
                table: "Trener",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
