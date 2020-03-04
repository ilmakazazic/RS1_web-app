using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class Obavijesti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ClanoviObavijesti");

            migrationBuilder.CreateTable(
                name: "ClanObavijest",
                columns: table => new
                {
                    ClanObavijestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClanID = table.Column<int>(nullable: false),
                    ObavijestID = table.Column<int>(nullable: false),
                    Procitana = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanObavijest", x => x.ClanObavijestID);
                    table.ForeignKey(
                        name: "FK_ClanObavijest_Clan_ClanID",
                        column: x => x.ClanID,
                        principalTable: "Clan",
                        principalColumn: "ClanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClanObavijest_Obavijest_ObavijestID",
                        column: x => x.ObavijestID,
                        principalTable: "Obavijest",
                        principalColumn: "ObavijestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClanObavijest_ClanID",
                table: "ClanObavijest",
                column: "ClanID");

            migrationBuilder.CreateIndex(
                name: "IX_ClanObavijest_ObavijestID",
                table: "ClanObavijest",
                column: "ObavijestID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClanObavijest");

            migrationBuilder.CreateTable(
                name: "ClanoviObavijesti",
                columns: table => new
                {
                    ClanoviObavijestiiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClanID = table.Column<int>(type: "int", nullable: false),
                    ObavijestID = table.Column<int>(type: "int", nullable: false),
                    Procitana = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanoviObavijesti", x => x.ClanoviObavijestiiID);
                    table.ForeignKey(
                        name: "FK_ClanoviObavijesti_Clan_ClanID",
                        column: x => x.ClanID,
                        principalTable: "Clan",
                        principalColumn: "ClanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClanoviObavijesti_Obavijest_ObavijestID",
                        column: x => x.ObavijestID,
                        principalTable: "Obavijest",
                        principalColumn: "ObavijestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClanoviObavijesti_ClanID",
                table: "ClanoviObavijesti",
                column: "ClanID");

            migrationBuilder.CreateIndex(
                name: "IX_ClanoviObavijesti_ObavijestID",
                table: "ClanoviObavijesti",
                column: "ObavijestID");
        }
    }
}
