namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class size_dormularzK1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FormularzeK1N", "CelProjektu", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FormularzeK1N", "CelProjektu", c => c.String());
        }
    }
}
