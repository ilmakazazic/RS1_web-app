using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class Modifikacija_Licence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trener_Licenca_LicencaID",
                table: "Trener");

            migrationBuilder.DropColumn(
                name: "DatumIsteka",
                table: "Licenca");

            migrationBuilder.DropColumn(
                name: "DatumPolaganja",
                table: "Licenca");

            migrationBuilder.AlterColumn<int>(
                name: "LicencaID",
                table: "Trener",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TrenerLicencaID",
                table: "Trener",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TrenerLicenca",
                columns: table => new
                {
                    TrenerLicencaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrenerId = table.Column<int>(nullable: false),
                    TeretanaID = table.Column<int>(nullable: true),
                    LicencaId = table.Column<int>(nullable: false),
                    ClanID = table.Column<int>(nullable: true),
                    DatumPolaganja = table.Column<DateTime>(nullable: false),
                    DatumIsteka = table.Column<DateTime>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trener_TrenerLicenca_LicencaID",
                table: "Trener");

            migrationBuilder.DropTable(
                name: "TrenerLicenca");

            migrationBuilder.DropColumn(
                name: "TrenerLicencaID",
                table: "Trener");

            migrationBuilder.AlterColumn<int>(
                name: "LicencaID",
                table: "Trener",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumIsteka",
                table: "Licenca",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumPolaganja",
                table: "Licenca",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Trener_Licenca_LicencaID",
                table: "Trener",
                column: "LicencaID",
                principalTable: "Licenca",
                principalColumn: "LicencaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
