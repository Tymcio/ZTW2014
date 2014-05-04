using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace WnioskiOnline.Models
{
    public class WnioskiContext : DbContext
    {
        public WnioskiContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Wniosek> Wnioski { get; set; }
        public DbSet<Dziedzina> Dziedziny { get; set; }
        public DbSet<Organizacja> Organizacje { get; set; }
        public DbSet<Kompetencja> Kompetencje { get; set; }
        public DbSet<Konkurs> Konkursy { get; set; }
        public DbSet<Wydatek> Wydatki { get; set; }
        public DbSet<Zadanie>Zadania { get; set; }
        public DbSet<Zasieg> Zasiegi { get; set; }
        public DbSet<ZrodloDofinansowania> ZrodlaDofinansowania { get; set; }  

    }
}