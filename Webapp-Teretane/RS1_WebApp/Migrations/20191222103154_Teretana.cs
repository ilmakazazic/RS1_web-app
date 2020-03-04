using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class Teretana : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_Teretana_TreninziID",
            //    table: "Teretana");

            migrationBuilder.AddColumn<int>(
                name: "TeretanaID",
                table: "Treninzi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Treninzi_TeretanaID",
                table: "Treninzi",
                column: "TeretanaID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Teretana_TreninziID",
            //    table: "Teretana",
            //    column: "TreninziID",
            //    unique: true,
            //    filter: "[TreninziID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Treninzi_Teretana_TeretanaID",
                table: "Treninzi",
                column: "TeretanaID",
                principalTable: "Teretana",
                principalColumn: "TeretanaID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treninzi_Teretana_TeretanaID",
                table: "Treninzi");

            migrationBuilder.DropIndex(
                name: "IX_Treninzi_TeretanaID",
                table: "Treninzi");

            //migrationBuilder.DropIndex(
            //    name: "IX_Teretana_TreninziID",
            //    table: "Teretana");

            migrationBuilder.DropColumn(
                name: "TeretanaID",
                table: "Treninzi");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Teretana_TreninziID",
            //    table: "Teretana",
            //    column: "TreninziID");
        }
    }
}
