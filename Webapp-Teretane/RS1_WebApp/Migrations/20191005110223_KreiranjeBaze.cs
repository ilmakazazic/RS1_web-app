using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Teretana.Migrations
{
    public partial class KreiranjeBaze : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "Licenca",
                columns: table => new
                {
                    LicencaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tip = table.Column<string>(nullable: true),
                    DatumPolaganja = table.Column<DateTime>(nullable: false),
                    DatumIsteka = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenca", x => x.LicencaID);
                });

            migrationBuilder.CreateTable(
                name: "TipClanarine",
                columns: table => new
                {
                    TipClanarineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tip = table.Column<string>(nullable: true),
                    Cijena = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipClanarine", x => x.TipClanarineID);
                });

            migrationBuilder.CreateTable(
                name: "Uloga",
                columns: table => new
                {
                    UlogaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloga", x => x.UlogaID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<string>(nullable: true),
                    DrzavaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trener",
                columns: table => new
                {
                    TrenerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    Spol = table.Column<string>(nullable: true),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true),
                    LicencaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trener", x => x.TrenerID);
                    table.ForeignKey(
                        name: "FK_Trener_Licenca_LicencaID",
                        column: x => x.LicencaID,
                        principalTable: "Licenca",
                        principalColumn: "LicencaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teretana",
                columns: table => new
                {
                    TeretanaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    RadnoVrijeme = table.Column<TimeSpan>(nullable: false),
                    GradID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teretana", x => x.TeretanaID);
                    table.ForeignKey(
                        name: "FK_Teretana_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clan",
                columns: table => new
                {
                    ClanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true),
                    DatumUclanjivanja = table.Column<DateTime>(nullable: false),
                    TeretanaID = table.Column<int>(nullable: false),
                    TipClanarineID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clan", x => x.ClanID);
                    table.ForeignKey(
                        name: "FK_Clan_Teretana_TeretanaID",
                        column: x => x.TeretanaID,
                        principalTable: "Teretana",
                        principalColumn: "TeretanaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clan_TipClanarine_TipClanarineID",
                        column: x => x.TipClanarineID,
                        principalTable: "TipClanarine",
                        principalColumn: "TipClanarineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true),
                    UlogaID = table.Column<int>(nullable: false),
                    TeretanaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikID);
                    table.ForeignKey(
                        name: "FK_Korisnik_Teretana_TeretanaID",
                        column: x => x.TeretanaID,
                        principalTable: "Teretana",
                        principalColumn: "TeretanaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Korisnik_Uloga_UlogaID",
                        column: x => x.UlogaID,
                        principalTable: "Uloga",
                        principalColumn: "UlogaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trening",
                columns: table => new
                {
                    TreningID = table.Column<string>(nullable: false),
                    DatumOdrzavanja = table.Column<DateTime>(nullable: false),
                    PocetakTreninga = table.Column<TimeSpan>(nullable: false),
                    KrajTreninga = table.Column<TimeSpan>(nullable: false),
                    TeretanaID = table.Column<int>(nullable: false),
                    TrenerID = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "KomentarTeretane",
                columns: table => new
                {
                    KomentarID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Komentar = table.Column<string>(nullable: true),
                    ClanID = table.Column<int>(nullable: false),
                    TeretanaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KomentarTeretane", x => x.KomentarID);
                    table.ForeignKey(
                        name: "FK_KomentarTeretane_Clan_ClanID",
                        column: x => x.ClanID,
                        principalTable: "Clan",
                        principalColumn: "ClanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KomentarTeretane_Teretana_TeretanaID",
                        column: x => x.TeretanaID,
                        principalTable: "Teretana",
                        principalColumn: "TeretanaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OcjenaTeretane",
                columns: table => new
                {
                    OcjenaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ocjena = table.Column<int>(nullable: false),
                    TeretanaID = table.Column<int>(nullable: false),
                    ClanID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcjenaTeretane", x => x.OcjenaID);
                    table.ForeignKey(
                        name: "FK_OcjenaTeretane_Clan_ClanID",
                        column: x => x.ClanID,
                        principalTable: "Clan",
                        principalColumn: "ClanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OcjenaTeretane_Teretana_TeretanaID",
                        column: x => x.TeretanaID,
                        principalTable: "Teretana",
                        principalColumn: "TeretanaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Izvjestaj",
                columns: table => new
                {
                    IzvjestajID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Sadrzaj = table.Column<string>(nullable: true),
                    DatumKreiranja = table.Column<DateTime>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izvjestaj", x => x.IzvjestajID);
                    table.ForeignKey(
                        name: "FK_Izvjestaj_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obavijest",
                columns: table => new
                {
                    ObavijestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Sadrzaj = table.Column<string>(nullable: true),
                    DatumObjave = table.Column<DateTime>(nullable: false),
                    TeretanaID = table.Column<int>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijest", x => x.ObavijestID);
                    table.ForeignKey(
                        name: "FK_Obavijest_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Obavijest_Teretana_TeretanaID",
                        column: x => x.TeretanaID,
                        principalTable: "Teretana",
                        principalColumn: "TeretanaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PlacanjeClanarine",
                columns: table => new
                {
                    PlacanjeClanarineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Popust = table.Column<double>(nullable: false),
                    BrojRacuna = table.Column<int>(nullable: false),
                    UkupanIznos = table.Column<double>(nullable: false),
                    DatumUplate = table.Column<DateTime>(nullable: false),
                    TipClanarineID = table.Column<int>(nullable: false),
                    ClanID = table.Column<int>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacanjeClanarine", x => x.PlacanjeClanarineID);
                    table.ForeignKey(
                        name: "FK_PlacanjeClanarine_Clan_ClanID",
                        column: x => x.ClanID,
                        principalTable: "Clan",
                        principalColumn: "ClanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacanjeClanarine_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PlacanjeClanarine_TipClanarine_TipClanarineID",
                        column: x => x.TipClanarineID,
                        principalTable: "TipClanarine",
                        principalColumn: "TipClanarineID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clan_TeretanaID",
                table: "Clan",
                column: "TeretanaID");

            migrationBuilder.CreateIndex(
                name: "IX_Clan_TipClanarineID",
                table: "Clan",
                column: "TipClanarineID");

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaID",
                table: "Grad",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Izvjestaj_KorisnikID",
                table: "Izvjestaj",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KomentarTeretane_ClanID",
                table: "KomentarTeretane",
                column: "ClanID");

            migrationBuilder.CreateIndex(
                name: "IX_KomentarTeretane_TeretanaID",
                table: "KomentarTeretane",
                column: "TeretanaID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_TeretanaID",
                table: "Korisnik",
                column: "TeretanaID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_UlogaID",
                table: "Korisnik",
                column: "UlogaID");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_KorisnikID",
                table: "Obavijest",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_TeretanaID",
                table: "Obavijest",
                column: "TeretanaID");

            migrationBuilder.CreateIndex(
                name: "IX_OcjenaTeretane_ClanID",
                table: "OcjenaTeretane",
                column: "ClanID");

            migrationBuilder.CreateIndex(
                name: "IX_OcjenaTeretane_TeretanaID",
                table: "OcjenaTeretane",
                column: "TeretanaID");

            migrationBuilder.CreateIndex(
                name: "IX_PlacanjeClanarine_ClanID",
                table: "PlacanjeClanarine",
                column: "ClanID");

            migrationBuilder.CreateIndex(
                name: "IX_PlacanjeClanarine_KorisnikID",
                table: "PlacanjeClanarine",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_PlacanjeClanarine_TipClanarineID",
                table: "PlacanjeClanarine",
                column: "TipClanarineID");

            migrationBuilder.CreateIndex(
                name: "IX_Teretana_GradID",
                table: "Teretana",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Trener_LicencaID",
                table: "Trener",
                column: "LicencaID");

            migrationBuilder.CreateIndex(
                name: "IX_Trening_TeretanaID",
                table: "Trening",
                column: "TeretanaID");

            migrationBuilder.CreateIndex(
                name: "IX_Trening_TrenerID",
                table: "Trening",
                column: "TrenerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Izvjestaj");

            migrationBuilder.DropTable(
                name: "KomentarTeretane");

            migrationBuilder.DropTable(
                name: "Obavijest");

            migrationBuilder.DropTable(
                name: "OcjenaTeretane");

            migrationBuilder.DropTable(
                name: "PlacanjeClanarine");

            migrationBuilder.DropTable(
                name: "Trening");

            migrationBuilder.DropTable(
                name: "Clan");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Trener");

            migrationBuilder.DropTable(
                name: "TipClanarine");

            migrationBuilder.DropTable(
                name: "Teretana");

            migrationBuilder.DropTable(
                name: "Uloga");

            migrationBuilder.DropTable(
                name: "Licenca");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
