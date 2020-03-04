using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class NovaTabela_PopustKupon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PopustKupon",
                columns: table => new
                {
                    PopustKuponId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KuponKod = table.Column<string>(nullable: true),
                    PocetakDatum = table.Column<DateTime>(nullable: false),
                    KrajDatum = table.Column<DateTime>(nullable: false),
                    Broj_Koristenja = table.Column<int>(nullable: false),
                    Brojac_Koristenja = table.Column<int>(nullable: false),
                    Aktivan = table.Column<bool>(nullable: false),
                    TeretanaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopustKupon", x => x.PopustKuponId);
                    table.ForeignKey(
                        name: "FK_PopustKupon_Teretana_TeretanaId",
                        column: x => x.TeretanaId,
                        principalTable: "Teretana",
                        principalColumn: "TeretanaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PopustKupon_TeretanaId",
                table: "PopustKupon",
                column: "TeretanaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PopustKupon");
        }
    }
}
