namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kompetencja : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kompetencje", "Recenzent_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Kompetencje", "Dziedzina_IdDziedziny", "dbo.Dziedziny");
            DropIndex("dbo.Kompetencje", new[] { "Recenzent_UserId" });
            DropIndex("dbo.Kompetencje", new[] { "Dziedzina_IdDziedziny" });
            RenameColumn(table: "dbo.Kompetencje", name: "Recenzent_UserId", newName: "IdRecenzenta");
            RenameColumn(table: "dbo.Kompetencje", name: "Dziedzina_IdDziedziny", newName: "IdDziedziny");
            AddForeignKey("dbo.Kompetencje", "IdRecenzenta", "dbo.UserProfile", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Kompetencje", "IdDziedziny", "dbo.Dziedziny", "IdDziedziny", cascadeDelete: true);
            CreateIndex("dbo.Kompetencje", "IdRecenzenta");
            CreateIndex("dbo.Kompetencje", "IdDziedziny");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Kompetencje", new[] { "IdDziedziny" });
            DropIndex("dbo.Kompetencje", new[] { "IdRecenzenta" });
            DropForeignKey("dbo.Kompetencje", "IdDziedziny", "dbo.Dziedziny");
            DropForeignKey("dbo.Kompetencje", "IdRecenzenta", "dbo.UserProfile");
            RenameColumn(table: "dbo.Kompetencje", name: "IdDziedziny", newName: "Dziedzina_IdDziedziny");
            RenameColumn(table: "dbo.Kompetencje", name: "IdRecenzenta", newName: "Recenzent_UserId");
            CreateIndex("dbo.Kompetencje", "Dziedzina_IdDziedziny");
            CreateIndex("dbo.Kompetencje", "Recenzent_UserId");
            AddForeignKey("dbo.Kompetencje", "Dziedzina_IdDziedziny", "dbo.Dziedziny", "IdDziedziny");
            AddForeignKey("dbo.Kompetencje", "Recenzent_UserId", "dbo.UserProfile", "UserId");
        }
    }
}
