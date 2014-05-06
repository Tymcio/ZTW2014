namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rodzaj_wydatku2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wydatki", "RodzajWydatku_IdRodzaju", c => c.Int());
            AddForeignKey("dbo.Wydatki", "RodzajWydatku_IdRodzaju", "dbo.RodzajeWydatku", "IdRodzaju");
            CreateIndex("dbo.Wydatki", "RodzajWydatku_IdRodzaju");
            DropColumn("dbo.Wydatki", "RodzajWydatku");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wydatki", "RodzajWydatku", c => c.String());
            DropIndex("dbo.Wydatki", new[] { "RodzajWydatku_IdRodzaju" });
            DropForeignKey("dbo.Wydatki", "RodzajWydatku_IdRodzaju", "dbo.RodzajeWydatku");
            DropColumn("dbo.Wydatki", "RodzajWydatku_IdRodzaju");
        }
    }
}
