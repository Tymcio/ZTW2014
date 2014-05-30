namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kompetencje", "IdRecenzenta", "dbo.UserProfile");
            DropForeignKey("dbo.Kompetencje", "IdDziedziny", "dbo.Dziedziny");
            DropIndex("dbo.Kompetencje", new[] { "IdRecenzenta" });
            DropIndex("dbo.Kompetencje", new[] { "IdDziedziny" });
            AlterColumn("dbo.Kompetencje", "IdRecenzenta", c => c.Int());
            AlterColumn("dbo.Kompetencje", "IdDziedziny", c => c.Int());
            AddForeignKey("dbo.Kompetencje", "IdRecenzenta", "dbo.UserProfile", "UserId");
            AddForeignKey("dbo.Kompetencje", "IdDziedziny", "dbo.Dziedziny", "IdDziedziny");
            CreateIndex("dbo.Kompetencje", "IdRecenzenta");
            CreateIndex("dbo.Kompetencje", "IdDziedziny");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Kompetencje", new[] { "IdDziedziny" });
            DropIndex("dbo.Kompetencje", new[] { "IdRecenzenta" });
            DropForeignKey("dbo.Kompetencje", "IdDziedziny", "dbo.Dziedziny");
            DropForeignKey("dbo.Kompetencje", "IdRecenzenta", "dbo.UserProfile");
            AlterColumn("dbo.Kompetencje", "IdDziedziny", c => c.Int(nullable: false));
            AlterColumn("dbo.Kompetencje", "IdRecenzenta", c => c.Int(nullable: false));
            CreateIndex("dbo.Kompetencje", "IdDziedziny");
            CreateIndex("dbo.Kompetencje", "IdRecenzenta");
            AddForeignKey("dbo.Kompetencje", "IdDziedziny", "dbo.Dziedziny", "IdDziedziny", cascadeDelete: true);
            AddForeignKey("dbo.Kompetencje", "IdRecenzenta", "dbo.UserProfile", "UserId", cascadeDelete: true);
        }
    }
}
