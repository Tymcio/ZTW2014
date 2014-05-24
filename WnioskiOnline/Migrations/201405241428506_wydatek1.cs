namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wydatek1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RodzajeWydatku", "NazwaRodzaju", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RodzajeWydatku", "NazwaRodzaju", c => c.String());
        }
    }
}
