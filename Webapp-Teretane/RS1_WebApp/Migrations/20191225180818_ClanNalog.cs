using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class ClanNalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Clan_KorisnickiNalog_KorisnickiNalogId",
            //    table: "Clan");

            //migrationBuilder.DropIndex(
            //    name: "IX_Clan_KorisnickiNalogId",
            //    table: "Clan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateIndex(
            //    name: "IX_Clan_KorisnickiNalogId",
            //    table: "Clan",
            //    column: "KorisnickiNalogId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Clan_KorisnickiNalog_KorisnickiNalogId",
            //    table: "Clan",
            //    column: "KorisnickiNalogId",
            //    principalTable: "KorisnickiNalog",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);
        }
    }
}
