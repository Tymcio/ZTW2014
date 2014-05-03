namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wnioseks",
                c => new
                    {
                        IdWniosku = c.Int(nullable: false, identity: true),
                        IdKonkursu = c.Int(nullable: false),
                        IdWnioskodawcy = c.Int(nullable: false),
                        IdRecenzenta = c.Int(nullable: false),
                        IdCzlonkaKomisji = c.Int(nullable: false),
                        Ocena = c.Int(nullable: false),
                        DataZlozenia = c.DateTime(nullable: false),
                        DataOceny = c.DateTime(nullable: false),
                        DataRozpatrzenia = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdWniosku);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Wnioseks");
        }
    }
}
