namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class size1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfile", "Nazwisko", c => c.String(maxLength: 40));
            AlterColumn("dbo.UserProfile", "Email", c => c.String(maxLength: 40));
            AlterColumn("dbo.UserProfile", "Telefon", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfile", "Telefon", c => c.String());
            AlterColumn("dbo.UserProfile", "Email", c => c.String());
            AlterColumn("dbo.UserProfile", "Nazwisko", c => c.String());
        }
    }
}
