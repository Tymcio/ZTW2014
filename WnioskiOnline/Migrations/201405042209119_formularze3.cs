namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class formularze3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormularzeK1N", "PozyskiwanieSponsorow", c => c.String());
            DropColumn("dbo.FormularzeK1N", "PozyskiwanieSponsorów");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FormularzeK1N", "PozyskiwanieSponsorów", c => c.String());
            DropColumn("dbo.FormularzeK1N", "PozyskiwanieSponsorow");
        }
    }
}
