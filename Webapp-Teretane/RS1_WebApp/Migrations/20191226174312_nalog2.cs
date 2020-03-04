using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class nalog2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tip",
                table: "KorisnickiNalog");

            migrationBuilder.AddColumn<int>(
                name: "TipNalogaID",
                table: "KorisnickiNalog",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipNaloga",
                columns: table => new
                {
                    TipNalogaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipNaloga", x => x.TipNalogaID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KorisnickiNalog_TipNalogaID",
                table: "KorisnickiNalog",
                column: "TipNalogaID");

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnickiNalog_TipNaloga_TipNalogaID",
                table: "KorisnickiNalog",
                column: "TipNalogaID",
                principalTable: "TipNaloga",
                principalColumn: "TipNalogaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorisnickiNalog_TipNaloga_TipNalogaID",
                table: "KorisnickiNalog");

            migrationBuilder.DropTable(
                name: "TipNaloga");

            migrationBuilder.DropIndex(
                name: "IX_KorisnickiNalog_TipNalogaID",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "TipNalogaID",
                table: "KorisnickiNalog");

            migrationBuilder.AddColumn<string>(
                name: "tip",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
