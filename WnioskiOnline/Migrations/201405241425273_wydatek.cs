namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wydatek : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Wydatki", "Wyszczegolnienie", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Wydatki", "Wyszczegolnienie", c => c.String());
        }
    }
}
