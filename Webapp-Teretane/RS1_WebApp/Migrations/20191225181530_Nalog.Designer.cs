﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RS1_Teretana.EF;

namespace RS1_Teretana.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20191225181530_Nalog")]
    partial class Nalog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.Clan", b =>
                {
                    b.Property<int>("ClanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumUclanjivanja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lozinka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NalogID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeretanaID")
                        .HasColumnType("int");

                    b.Property<int>("TipClanarineID")
                        .HasColumnType("int");

                    b.HasKey("ClanID");

                    b.HasIndex("TeretanaID");

                    b.HasIndex("TipClanarineID");

                    b.ToTable("Clan");
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.Drzava", b =>
                {
                    b.Property<int>("DrzavaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrzavaID");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.Grad", b =>
                {
                    b.Property<int>("GradID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrzavaID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostanskiBroj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GradID");

                    b.HasIndex("DrzavaID");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.Izvjestaj", b =>
                {
                    b.Property<int>("IzvjestajID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumKreiranja")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IzvjestajID");

                    b.HasIndex("KorisnikID");

                    b.ToTable("Izvjestaj");
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.KomentarTeretane", b =>
                {
                    b.Property<int>("KomentarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClanID")
                        .HasColumnType("int");

                    b.Property<string>("Komentar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeretanaID")
                        .HasColumnType("int");

                    b.HasKey("KomentarID");

                    b.HasIndex("ClanID");

                    b.HasIndex("TeretanaID");

                    b.ToTable("KomentarTeretane");
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.Korisnik", b =>
                {
                    b.Property<int>("KorisnikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KorisnickiNalogID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeretanaID")
                        .HasColumnType("int");

                    b.Property<int>("UlogaID")
                        .HasColumnType("int");

                    b.HasKey("KorisnikID");

                    b.HasIndex("KorisnickiNalogID");

                    b.HasIndex("TeretanaID");

                    b.HasIndex("UlogaID");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.Licenca", b =>
                {
                    b.Property<int>("LicencaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumIsteka")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumPolaganja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LicencaID");

                    b.ToTable("Licenca");
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.Obavijest", b =>
                {
                    b.Property<int>("ObavijestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClanID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumObjave")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeretanaID")
                        .HasColumnType("int");

                    b.HasKey("ObavijestID");

                    b.HasIndex("ClanID");

                    b.HasIndex("KorisnikID");

                    b.HasIndex("TeretanaID");

                    b.ToTable("Obavijest");
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.OcjenaTeretane", b =>
                {
                    b.Property<int>("OcjenaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClanID")
                        .HasColumnType("int");

                    b.Property<int>("Ocjena")
                        .HasColumnType("int");

                    b.Property<int>("TeretanaID")
                        .HasColumnType("int");

                    b.HasKey("OcjenaID");

                    b.HasIndex("ClanID");

                    b.HasIndex("TeretanaID");

                    b.ToTable("OcjenaTeretane");
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.PlacanjeClanarine", b =>
                {
                    b.Property<int>("PlacanjeClanarineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojRacuna")
                        .HasColumnType("int");

                    b.Property<int>("ClanID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumUplate")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<double>("Popust")
                        .HasColumnType("float");

                    b.Property<int>("TipClanarineID")
                        .HasColumnType("int");

                    b.Property<double>("UkupanIznos")
                        .HasColumnType("float");

                    b.HasKey("PlacanjeClanarineID");

                    b.HasIndex("ClanID");

                    b.HasIndex("KorisnikID");

                    b.HasIndex("TipClanarineID");

                    b.ToTable("PlacanjeClanarine");
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.Teretana", b =>
                {
                    b.Property<int>("TeretanaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("KrajRadnoVrijeme")
                        .HasColumnType("time");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("PocetakRadnoVrijeme")
                        .HasColumnType("time");

                    b.Property<int?>("TreninziID")
                        .HasColumnType("int");

                    b.HasKey("TeretanaID");

                    b.HasIndex("GradID");

                    b.HasIndex("TreninziID")
                        .IsUnique()
                        .HasFilter("[TreninziID] IS NOT NULL");

                    b.ToTable("Teretana");
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.TipClanarine", b =>
                {
                    b.Property<int>("TipClanarineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<string>("Tip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipClanarineID");

                    b.ToTable("TipClanarine");
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.Trener", b =>
                {
                    b.Property<int>("TrenerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LicencaID")
                        .HasColumnType("int");

                    b.Property<string>("Lozinka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Spol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrenerID");

                    b.HasIndex("LicencaID");

                    b.ToTable("Trener");
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.Uloga", b =>
                {
                    b.Property<int>("UlogaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UlogaID");

                    b.ToTable("Uloga");
                });

            modelBuilder.Entity("RS1_WebApp.EntityModels.ClanObavijest", b =>
                {
                    b.Property<int>("ClanObavijestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClanID")
                        .HasColumnType("int");

                    b.Property<int>("ObavijestID")
                        .HasColumnType("int");

                    b.Property<bool>("Procitana")
                        .HasColumnType("bit");

                    b.HasKey("ClanObavijestID");

                    b.HasIndex("ClanID");

                    b.HasIndex("ObavijestID");

                    b.ToTable("ClanObavijest");
                });

            modelBuilder.Entity("RS1_WebApp.EntityModels.ClanTeretana", b =>
                {
                    b.Property<int>("ClanTeretanaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClanID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumUclanjivanja")
                        .HasColumnType("datetime2");

                    b.Property<int>("TeretanaID")
                        .HasColumnType("int");

                    b.HasKey("ClanTeretanaID");

                    b.HasIndex("ClanID");

                    b.HasIndex("TeretanaID");

                    b.ToTable("ClanTeretana");
                });

            modelBuilder.Entity("RS1_WebApp.EntityModels.KorisnickiNalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KorisnickoIme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lozinka")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KorisnickiNalog");
                });

            modelBuilder.Entity("RS1_WebApp.EntityModels.Treninzi", b =>
                {
                    b.Property<int>("TreninziID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumOdrzavanja")
                        .HasColumnType("datetime2");

                    b.Property<string>("KrajTreninga")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PocetakTreninga")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeretanaID")
                        .HasColumnType("int");

                    b.Property<int>("TrenerID")
                        .HasColumnType("int");

                    b.HasKey("TreninziID");

                    b.HasIndex("TeretanaID");

                    b.HasIndex("TrenerID");

                    b.ToTable("Treninzi");
                });

            modelBuilder.Entity("RS1_WebApp.EntityModels.TreninziDetalji", b =>
                {
                    b.Property<int>("TreninziDetaljiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClanID")
                        .HasColumnType("int");

                    b.Property<bool>("Otkazan")
                        .HasColumnType("bit");

                    b.Property<int>("TreninziID")
                        .HasColumnType("int");

                    b.HasKey("TreninziDetaljiID");

                    b.HasIndex("ClanID");

                    b.HasIndex("TreninziID");

                    b.ToTable("treninziDetalji");
                });

            modelBuilder.Entity("RS1_WebApp.EntityModels.Uclanjivanje", b =>
                {
                    b.Property<int>("UclanjivanjeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClanID")
                        .HasColumnType("int");

                    b.Property<int>("TeretanaID")
                        .HasColumnType("int");

                    b.HasKey("UclanjivanjeID");

                    b.HasIndex("ClanID");

                    b.HasIndex("TeretanaID");

                    b.ToTable("Uclanjivanje");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.Clan", b =>
                {
                    b.HasOne("RS1_Teretana.EntityModels.Teretana", "Teretana")
                        .WithMany()
                        .HasForeignKey("TeretanaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Teretana.EntityModels.TipClanarine", "TipClanarine")
                        .WithMany()
                        .HasForeignKey("TipClanarineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.Grad", b =>
                {
                    b.HasOne("RS1_Teretana.EntityModels.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.Izvjestaj", b =>
                {
                    b.HasOne("RS1_Teretana.EntityModels.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.KomentarTeretane", b =>
                {
                    b.HasOne("RS1_Teretana.EntityModels.Clan", "Clan")
                        .WithMany()
                        .HasForeignKey("ClanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Teretana.EntityModels.Teretana", "Teretana")
                        .WithMany()
                        .HasForeignKey("TeretanaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.Korisnik", b =>
                {
                    b.HasOne("RS1_WebApp.EntityModels.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogID");

                    b.HasOne("RS1_Teretana.EntityModels.Teretana", "Teretana")
                        .WithMany()
                        .HasForeignKey("TeretanaID");

                    b.HasOne("RS1_Teretana.EntityModels.Uloga", "Uloga")
                        .WithMany()
                        .HasForeignKey("UlogaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.Obavijest", b =>
                {
                    b.HasOne("RS1_Teretana.EntityModels.Korisnik", "Clan")
                        .WithMany()
                        .HasForeignKey("ClanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Teretana.EntityModels.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Teretana.EntityModels.Teretana", "Teretana")
                        .WithMany()
                        .HasForeignKey("TeretanaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.OcjenaTeretane", b =>
                {
                    b.HasOne("RS1_Teretana.EntityModels.Clan", "Clan")
                        .WithMany()
                        .HasForeignKey("ClanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Teretana.EntityModels.Teretana", "Teretana")
                        .WithMany()
                        .HasForeignKey("TeretanaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.PlacanjeClanarine", b =>
                {
                    b.HasOne("RS1_Teretana.EntityModels.Clan", "Clan")
                        .WithMany()
                        .HasForeignKey("ClanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Teretana.EntityModels.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Teretana.EntityModels.TipClanarine", "TipClanarine")
                        .WithMany()
                        .HasForeignKey("TipClanarineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.Teretana", b =>
                {
                    b.HasOne("RS1_Teretana.EntityModels.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_WebApp.EntityModels.Treninzi", "Treninzi")
                        .WithOne()
                        .HasForeignKey("RS1_Teretana.EntityModels.Teretana", "TreninziID");
                });

            modelBuilder.Entity("RS1_Teretana.EntityModels.Trener", b =>
                {
                    b.HasOne("RS1_Teretana.EntityModels.Licenca", "Licenca")
                        .WithMany()
                        .HasForeignKey("LicencaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_WebApp.EntityModels.ClanObavijest", b =>
                {
                    b.HasOne("RS1_Teretana.EntityModels.Clan", "Clan")
                        .WithMany()
                        .HasForeignKey("ClanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Teretana.EntityModels.Obavijest", "Obavijest")
                        .WithMany()
                        .HasForeignKey("ObavijestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_WebApp.EntityModels.ClanTeretana", b =>
                {
                    b.HasOne("RS1_Teretana.EntityModels.Clan", "Clan")
                        .WithMany()
                        .HasForeignKey("ClanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Teretana.EntityModels.Teretana", "Teretana")
                        .WithMany()
                        .HasForeignKey("TeretanaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_WebApp.EntityModels.Treninzi", b =>
                {
                    b.HasOne("RS1_Teretana.EntityModels.Teretana", "Teretana")
                        .WithMany()
                        .HasForeignKey("TeretanaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Teretana.EntityModels.Trener", "Trener")
                        .WithMany()
                        .HasForeignKey("TrenerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_WebApp.EntityModels.TreninziDetalji", b =>
                {
                    b.HasOne("RS1_Teretana.EntityModels.Clan", "Clan")
                        .WithMany()
                        .HasForeignKey("ClanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_WebApp.EntityModels.Treninzi", "Treninzi")
                        .WithMany()
                        .HasForeignKey("TreninziID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RS1_WebApp.EntityModels.Uclanjivanje", b =>
                {
                    b.HasOne("RS1_Teretana.EntityModels.Clan", "Clan")
                        .WithMany()
                        .HasForeignKey("ClanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1_Teretana.EntityModels.Teretana", "Teretana")
                        .WithMany()
                        .HasForeignKey("TeretanaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
