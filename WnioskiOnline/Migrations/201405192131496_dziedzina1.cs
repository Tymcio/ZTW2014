namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dziedzina1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormularzeK1N", "IdDziedziny", c => c.Int(nullable: false));
            AddForeignKey("dbo.FormularzeK1N", "IdDziedziny", "dbo.Dziedziny", "IdDziedziny", cascadeDelete: true);
            CreateIndex("dbo.FormularzeK1N", "IdDziedziny");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FormularzeK1N", new[] { "IdDziedziny" });
            DropForeignKey("dbo.FormularzeK1N", "IdDziedziny", "dbo.Dziedziny");
            DropColumn("dbo.FormularzeK1N", "IdDziedziny");
        }
    }
}
