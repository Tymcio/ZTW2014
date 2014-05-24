namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuniecie : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FormularzeK3", "NazwaProjektu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FormularzeK3", "NazwaProjektu", c => c.String());
        }
    }
}
