namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wniosek : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Wnioski", "TytulWniosku", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Wnioski", "TytulWniosku", c => c.String());
        }
    }
}
