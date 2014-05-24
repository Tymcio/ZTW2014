namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class size3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Charaktery", "NazwaCharakteru", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Charaktery", "NazwaCharakteru", c => c.String());
        }
    }
}
