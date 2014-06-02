namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class not_null : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FormularzeK1N", "KwotaWnioskowana", c => c.Double(nullable: false));
            AlterColumn("dbo.FormularzeK3", "KwotaWnioskowana", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FormularzeK3", "KwotaWnioskowana", c => c.Double());
            AlterColumn("dbo.FormularzeK1N", "KwotaWnioskowana", c => c.Double());
        }
    }
}
