namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dziedziny2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wnioski", "IdDziedziny", c => c.Int());
            AddForeignKey("dbo.Wnioski", "IdDziedziny", "dbo.Dziedziny", "IdDziedziny");
            CreateIndex("dbo.Wnioski", "IdDziedziny");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Wnioski", new[] { "IdDziedziny" });
            DropForeignKey("dbo.Wnioski", "IdDziedziny", "dbo.Dziedziny");
            DropColumn("dbo.Wnioski", "IdDziedziny");
        }
    }
}
