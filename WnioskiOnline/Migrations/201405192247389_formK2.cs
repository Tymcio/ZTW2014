namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class formK2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FormularzeK2", "Organizacja_IdOrganizacji", "dbo.Organizacje");
            DropForeignKey("dbo.FormularzeK2", "Dziedzina_IdDziedziny", "dbo.Dziedziny");
            DropForeignKey("dbo.FormularzeK2", "Zasieg_IdZasiegu", "dbo.Zasiegi");
            DropForeignKey("dbo.FormularzeK2", "Charakter_IdCharakteru", "dbo.Charaktery");
            DropIndex("dbo.FormularzeK2", new[] { "Organizacja_IdOrganizacji" });
            DropIndex("dbo.FormularzeK2", new[] { "Dziedzina_IdDziedziny" });
            DropIndex("dbo.FormularzeK2", new[] { "Zasieg_IdZasiegu" });
            DropIndex("dbo.FormularzeK2", new[] { "Charakter_IdCharakteru" });
            RenameColumn(table: "dbo.FormularzeK2", name: "Organizacja_IdOrganizacji", newName: "IdOrganizacji");
            RenameColumn(table: "dbo.FormularzeK2", name: "PierwszyKoord_IdKoord", newName: "IdPierwszegoKoord");
            RenameColumn(table: "dbo.FormularzeK2", name: "DrugiKoord_IdKoord", newName: "IdDrugiegoKoord");
            RenameColumn(table: "dbo.FormularzeK2", name: "Dziedzina_IdDziedziny", newName: "IdDziedziny");
            RenameColumn(table: "dbo.FormularzeK2", name: "Zasieg_IdZasiegu", newName: "IdZasiegu");
            RenameColumn(table: "dbo.FormularzeK2", name: "Charakter_IdCharakteru", newName: "IdCharakteru");
            AddForeignKey("dbo.FormularzeK2", "IdOrganizacji", "dbo.Organizacje", "IdOrganizacji", cascadeDelete: true);
            AddForeignKey("dbo.FormularzeK2", "IdDziedziny", "dbo.Dziedziny", "IdDziedziny", cascadeDelete: true);
            AddForeignKey("dbo.FormularzeK2", "IdZasiegu", "dbo.Zasiegi", "IdZasiegu", cascadeDelete: true);
            AddForeignKey("dbo.FormularzeK2", "IdCharakteru", "dbo.Charaktery", "IdCharakteru", cascadeDelete: true);
            CreateIndex("dbo.FormularzeK2", "IdOrganizacji");
            CreateIndex("dbo.FormularzeK2", "IdDziedziny");
            CreateIndex("dbo.FormularzeK2", "IdZasiegu");
            CreateIndex("dbo.FormularzeK2", "IdCharakteru");
            DropColumn("dbo.FormularzeK2", "TytulProjektu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FormularzeK2", "TytulProjektu", c => c.String());
            DropIndex("dbo.FormularzeK2", new[] { "IdCharakteru" });
            DropIndex("dbo.FormularzeK2", new[] { "IdZasiegu" });
            DropIndex("dbo.FormularzeK2", new[] { "IdDziedziny" });
            DropIndex("dbo.FormularzeK2", new[] { "IdOrganizacji" });
            DropForeignKey("dbo.FormularzeK2", "IdCharakteru", "dbo.Charaktery");
            DropForeignKey("dbo.FormularzeK2", "IdZasiegu", "dbo.Zasiegi");
            DropForeignKey("dbo.FormularzeK2", "IdDziedziny", "dbo.Dziedziny");
            DropForeignKey("dbo.FormularzeK2", "IdOrganizacji", "dbo.Organizacje");
            RenameColumn(table: "dbo.FormularzeK2", name: "IdCharakteru", newName: "Charakter_IdCharakteru");
            RenameColumn(table: "dbo.FormularzeK2", name: "IdZasiegu", newName: "Zasieg_IdZasiegu");
            RenameColumn(table: "dbo.FormularzeK2", name: "IdDziedziny", newName: "Dziedzina_IdDziedziny");
            RenameColumn(table: "dbo.FormularzeK2", name: "IdDrugiegoKoord", newName: "DrugiKoord_IdKoord");
            RenameColumn(table: "dbo.FormularzeK2", name: "IdPierwszegoKoord", newName: "PierwszyKoord_IdKoord");
            RenameColumn(table: "dbo.FormularzeK2", name: "IdOrganizacji", newName: "Organizacja_IdOrganizacji");
            CreateIndex("dbo.FormularzeK2", "Charakter_IdCharakteru");
            CreateIndex("dbo.FormularzeK2", "Zasieg_IdZasiegu");
            CreateIndex("dbo.FormularzeK2", "Dziedzina_IdDziedziny");
            CreateIndex("dbo.FormularzeK2", "Organizacja_IdOrganizacji");
            AddForeignKey("dbo.FormularzeK2", "Charakter_IdCharakteru", "dbo.Charaktery", "IdCharakteru");
            AddForeignKey("dbo.FormularzeK2", "Zasieg_IdZasiegu", "dbo.Zasiegi", "IdZasiegu");
            AddForeignKey("dbo.FormularzeK2", "Dziedzina_IdDziedziny", "dbo.Dziedziny", "IdDziedziny");
            AddForeignKey("dbo.FormularzeK2", "Organizacja_IdOrganizacji", "dbo.Organizacje", "IdOrganizacji");
        }
    }
}
