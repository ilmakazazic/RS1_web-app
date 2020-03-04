using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class Modifikacija_Licence2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trener_TrenerLicenca_LicencaID",
                table: "Trener");

            migrationBuilder.DropTable(
                name: "TrenerLicenca");

            migrationBuilder.DropIndex(
                name: "IX_Trener_LicencaID",
                table: "Trener");

            migrationBuilder.DropColumn(
                name: "LicencaID",
                table: "Trener");

            migrationBuilder.DropColumn(
                name: "TrenerLicencaID",
                table: "Trener");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LicencaID",
                table: "Trener",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrenerLicencaID",
                table: "Trener",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TrenerLicenca",
                columns: table => new
                {
                    TrenerLicencaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClanID = table.Column<int>(type: "int", nullable: true),
                    DatumIsteka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumPolaganja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicencaId = table.Column<int>(type: "int", nullable: false),
                    TeretanaID = table.Column<int>(type: "int", nullable: true),
                    TrenerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrenerLicenca", x => x.TrenerLicencaId);
                    table.ForeignKey(
                        name: "FK_TrenerLicenca_Licenca_ClanID",
                        column: x => x.ClanID,
                        principalTable: "Licenca",
                        principalColumn: "LicencaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrenerLicenca_Trener_TeretanaID",
                        column: x => x.TeretanaID,
                        principalTable: "Trener",
                        principalColumn: "TrenerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trener_LicencaID",
                table: "Trener",
                column: "LicencaID");

            migrationBuilder.CreateIndex(
                name: "IX_TrenerLicenca_ClanID",
                table: "TrenerLicenca",
                column: "ClanID");

            migrationBuilder.CreateIndex(
                name: "IX_TrenerLicenca_TeretanaID",
                table: "TrenerLicenca",
                column: "TeretanaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trener_TrenerLicenca_LicencaID",
                table: "Trener",
                column: "LicencaID",
                principalTable: "TrenerLicenca",
                principalColumn: "TrenerLicencaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
