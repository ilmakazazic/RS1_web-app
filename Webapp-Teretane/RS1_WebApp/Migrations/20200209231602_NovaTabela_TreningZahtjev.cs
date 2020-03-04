using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class NovaTabela_TreningZahtjev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreningZahtjev",
                columns: table => new
                {
                    TreningZahtjevId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClanId = table.Column<int>(nullable: false),
                    TreninziId = table.Column<int>(nullable: false),
                    Odobren = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreningZahtjev", x => x.TreningZahtjevId);
                    table.ForeignKey(
                        name: "FK_TreningZahtjev_Clan_ClanId",
                        column: x => x.ClanId,
                        principalTable: "Clan",
                        principalColumn: "ClanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreningZahtjev_Treninzi_TreninziId",
                        column: x => x.TreninziId,
                        principalTable: "Treninzi",
                        principalColumn: "TreninziID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreningZahtjev_ClanId",
                table: "TreningZahtjev",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_TreningZahtjev_TreninziId",
                table: "TreningZahtjev",
                column: "TreninziId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreningZahtjev");
        }
    }
}
