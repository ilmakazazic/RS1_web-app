using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class Poruke2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Odgovor",
                table: "PorukeClanova",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sadrzaj",
                table: "PorukeClanova",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Odgovor",
                table: "PorukeClanova");

            migrationBuilder.DropColumn(
                name: "Sadrzaj",
                table: "PorukeClanova");
        }
    }
}
