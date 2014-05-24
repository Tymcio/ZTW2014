namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zadanie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Zadania", "NazwaZadania", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zadania", "NazwaZadania", c => c.String());
        }
    }
}
