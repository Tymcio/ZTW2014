namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class status : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Statusy", "NazwaStatusu", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Statusy", "NazwaStatusu", c => c.String());
        }
    }
}
