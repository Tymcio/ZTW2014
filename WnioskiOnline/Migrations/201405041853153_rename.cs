namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Wnioseks", newName: "Wnioski");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Wnioski", newName: "Wnioseks");
        }
    }
}
