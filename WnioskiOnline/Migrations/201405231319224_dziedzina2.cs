namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dziedzina2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FormularzeK1N", "IdDziedziny", "dbo.Dziedziny");
            DropForeignKey("dbo.FormularzeK2", "IdDziedziny", "dbo.Dziedziny");
            DropForeignKey("dbo.FormularzeK3", "IdDziedziny", "dbo.Dziedziny");
            DropIndex("dbo.FormularzeK1N", new[] { "IdDziedziny" });
            DropIndex("dbo.FormularzeK2", new[] { "IdDziedziny" });
            DropIndex("dbo.FormularzeK3", new[] { "IdDziedziny" });
            DropColumn("dbo.FormularzeK1N", "IdDziedziny");
            DropColumn("dbo.FormularzeK2", "IdDziedziny");
            DropColumn("dbo.FormularzeK3", "IdDziedziny");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FormularzeK3", "IdDziedziny", c => c.Int());
            AddColumn("dbo.FormularzeK2", "IdDziedziny", c => c.Int());
            AddColumn("dbo.FormularzeK1N", "IdDziedziny", c => c.Int());
            CreateIndex("dbo.FormularzeK3", "IdDziedziny");
            CreateIndex("dbo.FormularzeK2", "IdDziedziny");
            CreateIndex("dbo.FormularzeK1N", "IdDziedziny");
            AddForeignKey("dbo.FormularzeK3", "IdDziedziny", "dbo.Dziedziny", "IdDziedziny");
            AddForeignKey("dbo.FormularzeK2", "IdDziedziny", "dbo.Dziedziny", "IdDziedziny");
            AddForeignKey("dbo.FormularzeK1N", "IdDziedziny", "dbo.Dziedziny", "IdDziedziny");
        }
    }
}
