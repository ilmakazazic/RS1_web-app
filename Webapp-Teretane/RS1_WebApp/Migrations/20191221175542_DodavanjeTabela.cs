using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class DodavanjeTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trening");

          
     
            migrationBuilder.CreateTable(
                name: "Treninzi",
                columns: table => new
                {
                    TreninziID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrenerID = table.Column<int>(nullable: false),
                    DatumOdrzavanja = table.Column<DateTime>(nullable: false),
                    PocetakTreninga = table.Column<string>(nullable: true),
                    KrajTreninga = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treninzi", x => x.TreninziID);
                    table.ForeignKey(
                        name: "FK_Treninzi_Trener_TrenerID",
                        column: x => x.TrenerID,
                        principalTable: "Trener",
                        principalColumn: "TrenerID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.AddColumn<int>(
              name: "TreninziID",
              table: "Teretana",
              nullable: true);

            migrationBuilder.CreateTable(
                name: "treninziDetalji",
                columns: table => new
                {
                    TreninziDetaljiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreninziID = table.Column<int>(nullable: false),
                    ClanID = table.Column<int>(nullable: false),
                    Otkazan = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_treninziDetalji", x => x.TreninziDetaljiID);
                    table.ForeignKey(
                        name: "FK_treninziDetalji_Clan_ClanID",
                        column: x => x.ClanID,
                        principalTable: "Clan",
                        principalColumn: "ClanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_treninziDetalji_Treninzi_TreninziID",
                        column: x => x.TreninziID,
                        principalTable: "Treninzi",
                        principalColumn: "TreninziID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teretana_TreninziID",
                table: "Teretana",
                column: "TreninziID");

            migrationBuilder.CreateIndex(
                name: "IX_Treninzi_TrenerID",
                table: "Treninzi",
                column: "TrenerID");

            migrationBuilder.CreateIndex(
                name: "IX_treninziDetalji_ClanID",
                table: "treninziDetalji",
                column: "ClanID");

            migrationBuilder.CreateIndex(
                name: "IX_treninziDetalji_TreninziID",
                table: "treninziDetalji",
                column: "TreninziID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teretana_Treninzi_TreninziID",
                table: "Teretana",
                column: "TreninziID",
                principalTable: "Treninzi",
                principalColumn: "TreninziID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teretana_Treninzi_TreninziID",
                table: "Teretana");

            migrationBuilder.DropTable(
                name: "treninziDetalji");

            migrationBuilder.DropTable(
                name: "Treninzi");

            migrationBuilder.DropIndex(
                name: "IX_Teretana_TreninziID",
                table: "Teretana");

            migrationBuilder.DropColumn(
                name: "TreninziID",
                table: "Teretana");

            migrationBuilder.CreateTable(
                name: "Trening",
                columns: table => new
                {
                    TreningID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DatumOdrzavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KrajTreninga = table.Column<TimeSpan>(type: "time", nullable: false),
                    PocetakTreninga = table.Column<TimeSpan>(type: "time", nullable: false),
                    TeretanaID = table.Column<int>(type: "int", nullable: false),
                    TrenerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trening", x => x.TreningID);
                    table.ForeignKey(
                        name: "FK_Trening_Teretana_TeretanaID",
                        column: x => x.TeretanaID,
                        principalTable: "Teretana",
                        principalColumn: "TeretanaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trening_Trener_TrenerID",
                        column: x => x.TrenerID,
                        principalTable: "Trener",
                        principalColumn: "TrenerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trening_TeretanaID",
                table: "Trening",
                column: "TeretanaID");

            migrationBuilder.CreateIndex(
                name: "IX_Trening_TrenerID",
                table: "Trening",
                column: "TrenerID");
        }
    }
}
