namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizacje", "NazwaOrganizacji", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizacje", "NazwaOrganizacji", c => c.String());
        }
    }
}
