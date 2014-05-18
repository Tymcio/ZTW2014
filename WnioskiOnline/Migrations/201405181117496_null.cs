namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _null : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Wnioski", "Ocena", c => c.Int());
            AlterColumn("dbo.Wnioski", "DataOceny", c => c.DateTime());
            AlterColumn("dbo.Wnioski", "DataRozpatrzenia", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Wnioski", "DataRozpatrzenia", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Wnioski", "DataOceny", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Wnioski", "Ocena", c => c.Int(nullable: false));
        }
    }
}
