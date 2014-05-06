namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rodzaj_wydatku : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RodzajeWydatku",
                c => new
                    {
                        IdRodzaju = c.Int(nullable: false, identity: true),
                        NazwaRodzaju = c.String(),
                    })
                .PrimaryKey(t => t.IdRodzaju);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RodzajeWydatku");
        }
    }
}
