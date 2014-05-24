namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfile", "UserName", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfile", "UserName", c => c.String());
        }
    }
}
