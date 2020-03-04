using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class TreninziFKIspravka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teretana_Treninzi_TreninziID",
                table: "Teretana");

            migrationBuilder.DropIndex(
                name: "IX_Teretana_TreninziID",
                table: "Teretana");

            migrationBuilder.DropColumn(
                name: "TreninziID",
                table: "Teretana");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreninziID",
                table: "Teretana",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teretana_TreninziID",
                table: "Teretana",
                column: "TreninziID",
                unique: true,
                filter: "[TreninziID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Teretana_Treninzi_TreninziID",
                table: "Teretana",
                column: "TreninziID",
                principalTable: "Treninzi",
                principalColumn: "TreninziID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
