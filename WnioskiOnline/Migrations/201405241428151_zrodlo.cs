namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zrodlo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Zasiegi", "NazwaZasiegu", c => c.String(maxLength: 50));
            AlterColumn("dbo.ZrodlaDofinansowania", "NazwaZrodla", c => c.String(maxLength: 100));
            AlterColumn("dbo.ZrodlaDofinansowania", "Wyszczegolnienie", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ZrodlaDofinansowania", "Wyszczegolnienie", c => c.String());
            AlterColumn("dbo.ZrodlaDofinansowania", "NazwaZrodla", c => c.String());
            AlterColumn("dbo.Zasiegi", "NazwaZasiegu", c => c.String());
        }
    }
}
