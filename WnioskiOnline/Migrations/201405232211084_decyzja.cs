namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class decyzja : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Decyzje",
                c => new
                    {
                        IdDecyzji = c.Int(nullable: false, identity: true),
                        NazwaDecyzji = c.String(),
                    })
                .PrimaryKey(t => t.IdDecyzji);
            
            AddColumn("dbo.Wnioski", "IdDecyzji", c => c.Int());
            AddForeignKey("dbo.Wnioski", "IdDecyzji", "dbo.Decyzje", "IdDecyzji");
            CreateIndex("dbo.Wnioski", "IdDecyzji");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Wnioski", new[] { "IdDecyzji" });
            DropForeignKey("dbo.Wnioski", "IdDecyzji", "dbo.Decyzje");
            DropColumn("dbo.Wnioski", "IdDecyzji");
            DropTable("dbo.Decyzje");
        }
    }
}
