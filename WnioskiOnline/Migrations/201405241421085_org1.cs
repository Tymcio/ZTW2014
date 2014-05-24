namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizacje", "Miasto", c => c.String(maxLength: 30));
            AlterColumn("dbo.Organizacje", "Ulica", c => c.String(maxLength: 40));
            AlterColumn("dbo.Organizacje", "Telefon", c => c.String(maxLength: 30));
            AlterColumn("dbo.Organizacje", "Email", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizacje", "Email", c => c.String());
            AlterColumn("dbo.Organizacje", "Telefon", c => c.String());
            AlterColumn("dbo.Organizacje", "Ulica", c => c.String());
            AlterColumn("dbo.Organizacje", "Miasto", c => c.String());
        }
    }
}
