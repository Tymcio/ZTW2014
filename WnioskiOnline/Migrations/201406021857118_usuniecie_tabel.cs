namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuniecie_tabel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Wydatki", "RodzajWydatku_IdRodzaju", "dbo.RodzajeWydatku");
            DropForeignKey("dbo.Wydatki", "Wniosek_IdWniosku", "dbo.Wnioski");
            DropForeignKey("dbo.Zadania", "Wniosek_IdWniosku", "dbo.Wnioski");
            DropForeignKey("dbo.ZrodlaDofinansowania", "Wniosek_IdWniosku", "dbo.Wnioski");
            DropIndex("dbo.Wydatki", new[] { "RodzajWydatku_IdRodzaju" });
            DropIndex("dbo.Wydatki", new[] { "Wniosek_IdWniosku" });
            DropIndex("dbo.Zadania", new[] { "Wniosek_IdWniosku" });
            DropIndex("dbo.ZrodlaDofinansowania", new[] { "Wniosek_IdWniosku" });
            AddColumn("dbo.FormularzeK1N", "KwotaWnioskowana", c => c.Double());
            AddColumn("dbo.FormularzeK3", "KwotaWnioskowana", c => c.Double());
            DropTable("dbo.Wydatki");
            DropTable("dbo.RodzajeWydatku");
            DropTable("dbo.Zadania");
            DropTable("dbo.ZrodlaDofinansowania");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ZrodlaDofinansowania",
                c => new
                    {
                        IdZrodla = c.Int(nullable: false, identity: true),
                        NazwaZrodla = c.String(maxLength: 100),
                        Wyszczegolnienie = c.String(maxLength: 500),
                        Kwota = c.Double(nullable: false),
                        Wniosek_IdWniosku = c.Int(),
                    })
                .PrimaryKey(t => t.IdZrodla);
            
            CreateTable(
                "dbo.Zadania",
                c => new
                    {
                        IdZadania = c.Int(nullable: false, identity: true),
                        NazwaZadania = c.String(maxLength: 100),
                        DataRozpoczecia = c.DateTime(nullable: false),
                        DataZakonczenia = c.DateTime(nullable: false),
                        UdzialFinansowyUczelni = c.Double(nullable: false),
                        Wniosek_IdWniosku = c.Int(),
                    })
                .PrimaryKey(t => t.IdZadania);
            
            CreateTable(
                "dbo.RodzajeWydatku",
                c => new
                    {
                        IdRodzaju = c.Int(nullable: false, identity: true),
                        NazwaRodzaju = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.IdRodzaju);
            
            CreateTable(
                "dbo.Wydatki",
                c => new
                    {
                        IdWydatku = c.Int(nullable: false, identity: true),
                        Wyszczegolnienie = c.String(maxLength: 100),
                        KwotaOgolem = c.Double(nullable: false),
                        KwotaDoSfinans = c.Double(nullable: false),
                        RodzajWydatku_IdRodzaju = c.Int(),
                        Wniosek_IdWniosku = c.Int(),
                    })
                .PrimaryKey(t => t.IdWydatku);
            
            DropColumn("dbo.FormularzeK3", "KwotaWnioskowana");
            DropColumn("dbo.FormularzeK1N", "KwotaWnioskowana");
            CreateIndex("dbo.ZrodlaDofinansowania", "Wniosek_IdWniosku");
            CreateIndex("dbo.Zadania", "Wniosek_IdWniosku");
            CreateIndex("dbo.Wydatki", "Wniosek_IdWniosku");
            CreateIndex("dbo.Wydatki", "RodzajWydatku_IdRodzaju");
            AddForeignKey("dbo.ZrodlaDofinansowania", "Wniosek_IdWniosku", "dbo.Wnioski", "IdWniosku");
            AddForeignKey("dbo.Zadania", "Wniosek_IdWniosku", "dbo.Wnioski", "IdWniosku");
            AddForeignKey("dbo.Wydatki", "Wniosek_IdWniosku", "dbo.Wnioski", "IdWniosku");
            AddForeignKey("dbo.Wydatki", "RodzajWydatku_IdRodzaju", "dbo.RodzajeWydatku", "IdRodzaju");
        }
    }
}
