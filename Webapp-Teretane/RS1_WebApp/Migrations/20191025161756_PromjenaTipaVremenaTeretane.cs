using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class PromjenaTipaVremenaTeretane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RadnoVrijeme",
                table: "Teretana");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "KrajRadnoVrijeme",
                table: "Teretana",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "PocetakRadnoVrijeme",
                table: "Teretana",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KrajRadnoVrijeme",
                table: "Teretana");

            migrationBuilder.DropColumn(
                name: "PocetakRadnoVrijeme",
                table: "Teretana");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "RadnoVrijeme",
                table: "Teretana",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
