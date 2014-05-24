namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kod_pocztowy : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizacje", "KodPocztowy", c => c.String(maxLength: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizacje", "KodPocztowy", c => c.String());
        }
    }
}
