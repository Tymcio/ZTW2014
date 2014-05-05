namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wniosek_zmiana : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Statusy",
                c => new
                    {
                        IdStatusu = c.Int(nullable: false, identity: true),
                        NazwaStatusu = c.String(),
                    })
                .PrimaryKey(t => t.IdStatusu);
            
            AddColumn("dbo.Wnioski", "Status_IdStatusu", c => c.Int());
            AddForeignKey("dbo.Wnioski", "Status_IdStatusu", "dbo.Statusy", "IdStatusu");
            CreateIndex("dbo.Wnioski", "Status_IdStatusu");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Wnioski", new[] { "Status_IdStatusu" });
            DropForeignKey("dbo.Wnioski", "Status_IdStatusu", "dbo.Statusy");
            DropColumn("dbo.Wnioski", "Status_IdStatusu");
            DropTable("dbo.Statusy");
        }
    }
}
