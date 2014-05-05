namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wnioski_tytul : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wnioski", "TytulWniosku", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Wnioski", "TytulWniosku");
        }
    }
}
