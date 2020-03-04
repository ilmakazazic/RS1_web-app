using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class ClanISpravljanjeFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clan_Teretana_TeretanaID",
                table: "Clan");

            migrationBuilder.DropForeignKey(
                name: "FK_Clan_TipClanarine_TipClanarineID",
                table: "Clan");

            migrationBuilder.DropIndex(
                name: "IX_Clan_TeretanaID",
                table: "Clan");

            migrationBuilder.DropIndex(
                name: "IX_Clan_TipClanarineID",
                table: "Clan");

            migrationBuilder.DropColumn(
                name: "TeretanaID",
                table: "Clan");

            migrationBuilder.DropColumn(
                name: "TipClanarineID",
                table: "Clan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeretanaID",
                table: "Clan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipClanarineID",
                table: "Clan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clan_TeretanaID",
                table: "Clan",
                column: "TeretanaID");

            migrationBuilder.CreateIndex(
                name: "IX_Clan_TipClanarineID",
                table: "Clan",
                column: "TipClanarineID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clan_Teretana_TeretanaID",
                table: "Clan",
                column: "TeretanaID",
                principalTable: "Teretana",
                principalColumn: "TeretanaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clan_TipClanarine_TipClanarineID",
                table: "Clan",
                column: "TipClanarineID",
                principalTable: "TipClanarine",
                principalColumn: "TipClanarineID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
