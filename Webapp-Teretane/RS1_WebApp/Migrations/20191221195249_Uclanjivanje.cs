using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class Uclanjivanje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uclanjivanje",
                columns: table => new
                {
                    UclanjivanjeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeretanaID = table.Column<int>(nullable: false),
                    ClanID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uclanjivanje", x => x.UclanjivanjeID);
                    table.ForeignKey(
                        name: "FK_Uclanjivanje_Clan_ClanID",
                        column: x => x.ClanID,
                        principalTable: "Clan",
                        principalColumn: "ClanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uclanjivanje_Teretana_TeretanaID",
                        column: x => x.TeretanaID,
                        principalTable: "Teretana",
                        principalColumn: "TeretanaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uclanjivanje_ClanID",
                table: "Uclanjivanje",
                column: "ClanID");

            migrationBuilder.CreateIndex(
                name: "IX_Uclanjivanje_TeretanaID",
                table: "Uclanjivanje",
                column: "TeretanaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uclanjivanje");
        }
    }
}
