namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class size_decyzja : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Decyzje", "NazwaDecyzji", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Decyzje", "NazwaDecyzji", c => c.String());
        }
    }
}
