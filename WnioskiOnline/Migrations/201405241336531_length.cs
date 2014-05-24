namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class length : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfile", "Imie", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfile", "Imie", c => c.String());
        }
    }
}
