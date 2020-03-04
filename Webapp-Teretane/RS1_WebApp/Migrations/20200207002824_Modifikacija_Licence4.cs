using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class Modifikacija_Licence4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrenerLicenca",
                columns: table => new
                {
                    TrenerLicencaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrenerId = table.Column<int>(nullable: false),
                    LicencaId = table.Column<int>(nullable: false),
                    DatumPolaganja = table.Column<DateTime>(nullable: false),
                    DatumIsteka = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrenerLicenca", x => x.TrenerLicencaId);
                    table.ForeignKey(
                        name: "FK_TrenerLicenca_Licenca_LicencaId",
                        column: x => x.LicencaId,
                        principalTable: "Licenca",
                        principalColumn: "LicencaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrenerLicenca_Trener_TrenerId",
                        column: x => x.TrenerId,
                        principalTable: "Trener",
                        principalColumn: "TrenerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrenerLicenca_LicencaId",
                table: "TrenerLicenca",
                column: "LicencaId");

            migrationBuilder.CreateIndex(
                name: "IX_TrenerLicenca_TrenerId",
                table: "TrenerLicenca",
                column: "TrenerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrenerLicenca");
        }
    }
}
