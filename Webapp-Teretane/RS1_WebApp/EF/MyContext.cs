using Microsoft.EntityFrameworkCore;
using RS1_Teretana.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using RS1_WebApp.EntityModels;

namespace RS1_Teretana.EF
{
    public class MyContext : IdentityDbContext
    {
        public MyContext()
        {

        }
        public MyContext(DbContextOptions<MyContext> options)
        : base(options)
        {
        }

        public DbSet<Clan> Clan { get; set; }

        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Trener> Trener { get; set; }
        public DbSet<TipClanarine> TipClanarine { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Izvjestaj> Izvjestaj { get; set; }
        public DbSet<KomentarTeretane> KomentarTeretane { get; set; }
        public DbSet<Licenca> Licenca { get; set; }
        public DbSet<Obavijest> Obavijest { get; set; }
        public DbSet<OcjenaTeretane> OcjenaTeretane { get; set; }
        public DbSet<PlacanjeClanarine> PlacanjeClanarine { get; set; }
        public DbSet<Teretana> Teretana { get; set; }
        //public DbSet<Trening> Trening { get; set; }
        public DbSet<Uloga> Uloga { get; set; }
        public DbSet<Treninzi> Treninzi { get; set; }
        public DbSet<TreninziDetalji> treninziDetalji { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<ClanObavijest> ClanObavijest { get; set; }
        public DbSet<Uclanjivanje> Uclanjivanje { get; set; }
        public DbSet<ClanTeretana> ClanTeretana { get; set; }
        public DbSet<AutorizacijskiToken> AutorizacijskiToken { get; set; }
        public DbSet<TipNaloga> TipNaloga { get; set; }
        public DbSet<PorukeClanova> PorukeClanova { get; set; }
        public DbSet<ChatClanovi> ChatClanovi { get; set; }
        public DbSet<TrenerLicenca> TrenerLicenca { get; set; }
        public DbSet<TreningZahtjev> TreningZahtjev { get; set; }
        public DbSet<PopustKupon> PopustKupon { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
