using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class Nalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "KorisnickiNalogId",
            //    table: "Clan");

            migrationBuilder.AddColumn<int>(
                name: "NalogID",
                table: "Clan",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NalogID",
                table: "Clan");

            //migrationBuilder.AddColumn<int>(
            //    name: "KorisnickiNalogId",
            //    table: "Clan",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);
        }
    }
}
