using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class ClanTeretana : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClanTeretana",
                columns: table => new
                {
                    ClanTeretanaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeretanaID = table.Column<int>(nullable: false),
                    ClanID = table.Column<int>(nullable: false),
                    DatumUclanjivanja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanTeretana", x => x.ClanTeretanaID);
                    table.ForeignKey(
                        name: "FK_ClanTeretana_Clan_ClanID",
                        column: x => x.ClanID,
                        principalTable: "Clan",
                        principalColumn: "ClanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClanTeretana_Teretana_TeretanaID",
                        column: x => x.TeretanaID,
                        principalTable: "Teretana",
                        principalColumn: "TeretanaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClanTeretana_ClanID",
                table: "ClanTeretana",
                column: "ClanID");

            migrationBuilder.CreateIndex(
                name: "IX_ClanTeretana_TeretanaID",
                table: "ClanTeretana",
                column: "TeretanaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClanTeretana");
        }
    }
}
