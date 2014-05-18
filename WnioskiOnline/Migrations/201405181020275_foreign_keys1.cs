namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreign_keys1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Wnioski", "Konkurs_IdKonkursu", "dbo.Konkursy");
            DropForeignKey("dbo.Wnioski", "Wnioskodawca_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Wnioski", "Status_IdStatusu", "dbo.Statusy");
            DropForeignKey("dbo.FormularzeK3", "Organizacja_IdOrganizacji", "dbo.Organizacje");
            DropForeignKey("dbo.FormularzeK3", "Dziedzina_IdDziedziny", "dbo.Dziedziny");
            DropForeignKey("dbo.FormularzeK3", "Zasieg_IdZasiegu", "dbo.Zasiegi");
            DropForeignKey("dbo.FormularzeK3", "Charakter_IdCharakteru", "dbo.Charaktery");
            DropIndex("dbo.Wnioski", new[] { "Konkurs_IdKonkursu" });
            DropIndex("dbo.Wnioski", new[] { "Wnioskodawca_UserId" });
            DropIndex("dbo.Wnioski", new[] { "Status_IdStatusu" });
            DropIndex("dbo.FormularzeK3", new[] { "Organizacja_IdOrganizacji" });
            DropIndex("dbo.FormularzeK3", new[] { "Dziedzina_IdDziedziny" });
            DropIndex("dbo.FormularzeK3", new[] { "Zasieg_IdZasiegu" });
            DropIndex("dbo.FormularzeK3", new[] { "Charakter_IdCharakteru" });
            RenameColumn(table: "dbo.Wnioski", name: "Konkurs_IdKonkursu", newName: "IdKonkursu");
            RenameColumn(table: "dbo.Wnioski", name: "Wnioskodawca_UserId", newName: "IdWnioskodawcy");
            RenameColumn(table: "dbo.Wnioski", name: "Recenzent_UserId", newName: "IdRecenzenta");
            RenameColumn(table: "dbo.Wnioski", name: "CzlonekKomisji_UserId", newName: "IdCzlonkaKomisji");
            RenameColumn(table: "dbo.Wnioski", name: "Status_IdStatusu", newName: "IdStatusu");
            RenameColumn(table: "dbo.FormularzeK3", name: "Wniosek_IdWniosku", newName: "IdWniosku");
            RenameColumn(table: "dbo.FormularzeK3", name: "Organizacja_IdOrganizacji", newName: "IdOrganizacji");
            RenameColumn(table: "dbo.FormularzeK3", name: "PierwszyKoord_IdKoord", newName: "IdPierwszegoKoord");
            RenameColumn(table: "dbo.FormularzeK3", name: "DrugiKoord_IdKoord", newName: "IdDrugiegoKoord");
            RenameColumn(table: "dbo.FormularzeK3", name: "Dziedzina_IdDziedziny", newName: "IdDziedziny");
            RenameColumn(table: "dbo.FormularzeK3", name: "Zasieg_IdZasiegu", newName: "IdZasiegu");
            RenameColumn(table: "dbo.FormularzeK3", name: "Charakter_IdCharakteru", newName: "IdCharakteru");
            AddForeignKey("dbo.Wnioski", "IdKonkursu", "dbo.Konkursy", "IdKonkursu", cascadeDelete: true);
            AddForeignKey("dbo.Wnioski", "IdWnioskodawcy", "dbo.UserProfile", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Wnioski", "IdStatusu", "dbo.Statusy", "IdStatusu", cascadeDelete: true);
            AddForeignKey("dbo.FormularzeK3", "IdOrganizacji", "dbo.Organizacje", "IdOrganizacji", cascadeDelete: true);
            AddForeignKey("dbo.FormularzeK3", "IdDziedziny", "dbo.Dziedziny", "IdDziedziny", cascadeDelete: true);
            AddForeignKey("dbo.FormularzeK3", "IdZasiegu", "dbo.Zasiegi", "IdZasiegu", cascadeDelete: true);
            AddForeignKey("dbo.FormularzeK3", "IdCharakteru", "dbo.Charaktery", "IdCharakteru", cascadeDelete: true);
            CreateIndex("dbo.Wnioski", "IdKonkursu");
            CreateIndex("dbo.Wnioski", "IdWnioskodawcy");
            CreateIndex("dbo.Wnioski", "IdStatusu");
            CreateIndex("dbo.FormularzeK3", "IdOrganizacji");
            CreateIndex("dbo.FormularzeK3", "IdDziedziny");
            CreateIndex("dbo.FormularzeK3", "IdZasiegu");
            CreateIndex("dbo.FormularzeK3", "IdCharakteru");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FormularzeK3", new[] { "IdCharakteru" });
            DropIndex("dbo.FormularzeK3", new[] { "IdZasiegu" });
            DropIndex("dbo.FormularzeK3", new[] { "IdDziedziny" });
            DropIndex("dbo.FormularzeK3", new[] { "IdOrganizacji" });
            DropIndex("dbo.Wnioski", new[] { "IdStatusu" });
            DropIndex("dbo.Wnioski", new[] { "IdWnioskodawcy" });
            DropIndex("dbo.Wnioski", new[] { "IdKonkursu" });
            DropForeignKey("dbo.FormularzeK3", "IdCharakteru", "dbo.Charaktery");
            DropForeignKey("dbo.FormularzeK3", "IdZasiegu", "dbo.Zasiegi");
            DropForeignKey("dbo.FormularzeK3", "IdDziedziny", "dbo.Dziedziny");
            DropForeignKey("dbo.FormularzeK3", "IdOrganizacji", "dbo.Organizacje");
            DropForeignKey("dbo.Wnioski", "IdStatusu", "dbo.Statusy");
            DropForeignKey("dbo.Wnioski", "IdWnioskodawcy", "dbo.UserProfile");
            DropForeignKey("dbo.Wnioski", "IdKonkursu", "dbo.Konkursy");
            RenameColumn(table: "dbo.FormularzeK3", name: "IdCharakteru", newName: "Charakter_IdCharakteru");
            RenameColumn(table: "dbo.FormularzeK3", name: "IdZasiegu", newName: "Zasieg_IdZasiegu");
            RenameColumn(table: "dbo.FormularzeK3", name: "IdDziedziny", newName: "Dziedzina_IdDziedziny");
            RenameColumn(table: "dbo.FormularzeK3", name: "IdDrugiegoKoord", newName: "DrugiKoord_IdKoord");
            RenameColumn(table: "dbo.FormularzeK3", name: "IdPierwszegoKoord", newName: "PierwszyKoord_IdKoord");
            RenameColumn(table: "dbo.FormularzeK3", name: "IdOrganizacji", newName: "Organizacja_IdOrganizacji");
            RenameColumn(table: "dbo.FormularzeK3", name: "IdWniosku", newName: "Wniosek_IdWniosku");
            RenameColumn(table: "dbo.Wnioski", name: "IdStatusu", newName: "Status_IdStatusu");
            RenameColumn(table: "dbo.Wnioski", name: "IdCzlonkaKomisji", newName: "CzlonekKomisji_UserId");
            RenameColumn(table: "dbo.Wnioski", name: "IdRecenzenta", newName: "Recenzent_UserId");
            RenameColumn(table: "dbo.Wnioski", name: "IdWnioskodawcy", newName: "Wnioskodawca_UserId");
            RenameColumn(table: "dbo.Wnioski", name: "IdKonkursu", newName: "Konkurs_IdKonkursu");
            CreateIndex("dbo.FormularzeK3", "Charakter_IdCharakteru");
            CreateIndex("dbo.FormularzeK3", "Zasieg_IdZasiegu");
            CreateIndex("dbo.FormularzeK3", "Dziedzina_IdDziedziny");
            CreateIndex("dbo.FormularzeK3", "Organizacja_IdOrganizacji");
            CreateIndex("dbo.Wnioski", "Status_IdStatusu");
            CreateIndex("dbo.Wnioski", "Wnioskodawca_UserId");
            CreateIndex("dbo.Wnioski", "Konkurs_IdKonkursu");
            AddForeignKey("dbo.FormularzeK3", "Charakter_IdCharakteru", "dbo.Charaktery", "IdCharakteru");
            AddForeignKey("dbo.FormularzeK3", "Zasieg_IdZasiegu", "dbo.Zasiegi", "IdZasiegu");
            AddForeignKey("dbo.FormularzeK3", "Dziedzina_IdDziedziny", "dbo.Dziedziny", "IdDziedziny");
            AddForeignKey("dbo.FormularzeK3", "Organizacja_IdOrganizacji", "dbo.Organizacje", "IdOrganizacji");
            AddForeignKey("dbo.Wnioski", "Status_IdStatusu", "dbo.Statusy", "IdStatusu");
            AddForeignKey("dbo.Wnioski", "Wnioskodawca_UserId", "dbo.UserProfile", "UserId");
            AddForeignKey("dbo.Wnioski", "Konkurs_IdKonkursu", "dbo.Konkursy", "IdKonkursu");
        }
    }
}
