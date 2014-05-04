namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Konkursy",
                c => new
                    {
                        IdKonkursu = c.Int(nullable: false, identity: true),
                        NazwaKonkursu = c.String(),
                        DataRozpoczecia = c.DateTime(nullable: false),
                        DataZakonczenia = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdKonkursu);
            
            CreateTable(
                "dbo.Dziedziny",
                c => new
                    {
                        IdDziedziny = c.Int(nullable: false, identity: true),
                        NazwaDziedziny = c.String(),
                    })
                .PrimaryKey(t => t.IdDziedziny);
            
            CreateTable(
                "dbo.Organizacje",
                c => new
                    {
                        IdOrganizacji = c.Int(nullable: false, identity: true),
                        NazwaOrganizacji = c.String(),
                        Miasto = c.String(),
                        KodPocztowy = c.String(),
                        Ulica = c.String(),
                        NumerBudynku = c.Int(nullable: false),
                        NumerLokalu = c.Int(nullable: false),
                        Telefon = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.IdOrganizacji);
            
            CreateTable(
                "dbo.Kompetencje",
                c => new
                    {
                        IdKompetencji = c.Int(nullable: false, identity: true),
                        Recenzent_UserId = c.Int(),
                        Dziedzina_IdDziedziny = c.Int(),
                    })
                .PrimaryKey(t => t.IdKompetencji)
                .ForeignKey("dbo.UserProfile", t => t.Recenzent_UserId)
                .ForeignKey("dbo.Dziedziny", t => t.Dziedzina_IdDziedziny)
                .Index(t => t.Recenzent_UserId)
                .Index(t => t.Dziedzina_IdDziedziny);
            
            CreateTable(
                "dbo.Wydatki",
                c => new
                    {
                        IdWydatku = c.Int(nullable: false, identity: true),
                        RodzajWydatku = c.String(),
                        Wyszczegolnienie = c.String(),
                        KwotaOgolem = c.Double(nullable: false),
                        KwotaDoSfinans = c.Double(nullable: false),
                        Wniosek_IdWniosku = c.Int(),
                    })
                .PrimaryKey(t => t.IdWydatku)
                .ForeignKey("dbo.Wnioski", t => t.Wniosek_IdWniosku)
                .Index(t => t.Wniosek_IdWniosku);
            
            CreateTable(
                "dbo.Zadania",
                c => new
                    {
                        IdZadania = c.Int(nullable: false, identity: true),
                        NazwaZadania = c.String(),
                        DataRozpoczecia = c.DateTime(nullable: false),
                        DataZakonczenia = c.DateTime(nullable: false),
                        UdzialFinansowyUczelni = c.Double(nullable: false),
                        Wniosek_IdWniosku = c.Int(),
                    })
                .PrimaryKey(t => t.IdZadania)
                .ForeignKey("dbo.Wnioski", t => t.Wniosek_IdWniosku)
                .Index(t => t.Wniosek_IdWniosku);
            
            CreateTable(
                "dbo.Zasiegi",
                c => new
                    {
                        IdZasiegu = c.Int(nullable: false, identity: true),
                        NazwaZasiegu = c.String(),
                    })
                .PrimaryKey(t => t.IdZasiegu);
            
            CreateTable(
                "dbo.ZrodlaDofinansowania",
                c => new
                    {
                        IdZrodla = c.Int(nullable: false, identity: true),
                        NazwaZrodla = c.String(),
                        Wyszczegolnienie = c.String(),
                        Kwota = c.Double(nullable: false),
                        Wniosek_IdWniosku = c.Int(),
                    })
                .PrimaryKey(t => t.IdZrodla)
                .ForeignKey("dbo.Wnioski", t => t.Wniosek_IdWniosku)
                .Index(t => t.Wniosek_IdWniosku);
            
            AddColumn("dbo.Wnioski", "Konkurs_IdKonkursu", c => c.Int());
            AddColumn("dbo.Wnioski", "Wnioskodawca_UserId", c => c.Int());
            AddColumn("dbo.Wnioski", "Recenzent_UserId", c => c.Int());
            AddColumn("dbo.Wnioski", "CzlonekKomisji_UserId", c => c.Int());
            AddForeignKey("dbo.Wnioski", "Konkurs_IdKonkursu", "dbo.Konkursy", "IdKonkursu");
            AddForeignKey("dbo.Wnioski", "Wnioskodawca_UserId", "dbo.UserProfile", "UserId");
            AddForeignKey("dbo.Wnioski", "Recenzent_UserId", "dbo.UserProfile", "UserId");
            AddForeignKey("dbo.Wnioski", "CzlonekKomisji_UserId", "dbo.UserProfile", "UserId");
            CreateIndex("dbo.Wnioski", "Konkurs_IdKonkursu");
            CreateIndex("dbo.Wnioski", "Wnioskodawca_UserId");
            CreateIndex("dbo.Wnioski", "Recenzent_UserId");
            CreateIndex("dbo.Wnioski", "CzlonekKomisji_UserId");
            DropColumn("dbo.Wnioski", "IdKonkursu");
            DropColumn("dbo.Wnioski", "IdWnioskodawcy");
            DropColumn("dbo.Wnioski", "IdRecenzenta");
            DropColumn("dbo.Wnioski", "IdCzlonkaKomisji");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wnioski", "IdCzlonkaKomisji", c => c.Int(nullable: false));
            AddColumn("dbo.Wnioski", "IdRecenzenta", c => c.Int(nullable: false));
            AddColumn("dbo.Wnioski", "IdWnioskodawcy", c => c.Int(nullable: false));
            AddColumn("dbo.Wnioski", "IdKonkursu", c => c.Int(nullable: false));
            DropIndex("dbo.ZrodlaDofinansowania", new[] { "Wniosek_IdWniosku" });
            DropIndex("dbo.Zadania", new[] { "Wniosek_IdWniosku" });
            DropIndex("dbo.Wydatki", new[] { "Wniosek_IdWniosku" });
            DropIndex("dbo.Kompetencje", new[] { "Dziedzina_IdDziedziny" });
            DropIndex("dbo.Kompetencje", new[] { "Recenzent_UserId" });
            DropIndex("dbo.Wnioski", new[] { "CzlonekKomisji_UserId" });
            DropIndex("dbo.Wnioski", new[] { "Recenzent_UserId" });
            DropIndex("dbo.Wnioski", new[] { "Wnioskodawca_UserId" });
            DropIndex("dbo.Wnioski", new[] { "Konkurs_IdKonkursu" });
            DropForeignKey("dbo.ZrodlaDofinansowania", "Wniosek_IdWniosku", "dbo.Wnioski");
            DropForeignKey("dbo.Zadania", "Wniosek_IdWniosku", "dbo.Wnioski");
            DropForeignKey("dbo.Wydatki", "Wniosek_IdWniosku", "dbo.Wnioski");
            DropForeignKey("dbo.Kompetencje", "Dziedzina_IdDziedziny", "dbo.Dziedziny");
            DropForeignKey("dbo.Kompetencje", "Recenzent_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Wnioski", "CzlonekKomisji_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Wnioski", "Recenzent_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Wnioski", "Wnioskodawca_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Wnioski", "Konkurs_IdKonkursu", "dbo.Konkursy");
            DropColumn("dbo.Wnioski", "CzlonekKomisji_UserId");
            DropColumn("dbo.Wnioski", "Recenzent_UserId");
            DropColumn("dbo.Wnioski", "Wnioskodawca_UserId");
            DropColumn("dbo.Wnioski", "Konkurs_IdKonkursu");
            DropTable("dbo.ZrodlaDofinansowania");
            DropTable("dbo.Zasiegi");
            DropTable("dbo.Zadania");
            DropTable("dbo.Wydatki");
            DropTable("dbo.Kompetencje");
            DropTable("dbo.Organizacje");
            DropTable("dbo.Dziedziny");
            DropTable("dbo.Konkursy");
        }
    }
}
