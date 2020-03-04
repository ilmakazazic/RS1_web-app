using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class PlacanjeClanarine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeretanaID",
                table: "PlacanjeClanarine",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlacanjeClanarine_TeretanaID",
                table: "PlacanjeClanarine",
                column: "TeretanaID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlacanjeClanarine_Teretana_TeretanaID",
                table: "PlacanjeClanarine",
                column: "TeretanaID",
                principalTable: "Teretana",
                principalColumn: "TeretanaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlacanjeClanarine_Teretana_TeretanaID",
                table: "PlacanjeClanarine");

            migrationBuilder.DropIndex(
                name: "IX_PlacanjeClanarine_TeretanaID",
                table: "PlacanjeClanarine");

            migrationBuilder.DropColumn(
                name: "TeretanaID",
                table: "PlacanjeClanarine");
        }
    }
}
