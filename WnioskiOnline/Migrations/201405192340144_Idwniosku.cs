namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Idwniosku : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FormularzeK1N", "Wniosek_IdWniosku", "dbo.Wnioski");
            DropIndex("dbo.FormularzeK1N", new[] { "Wniosek_IdWniosku" });
            RenameColumn(table: "dbo.FormularzeK1N", name: "Wniosek_IdWniosku", newName: "IdWniosku");
            AddForeignKey("dbo.FormularzeK1N", "IdWniosku", "dbo.Wnioski", "IdWniosku", cascadeDelete: true);
            CreateIndex("dbo.FormularzeK1N", "IdWniosku");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FormularzeK1N", new[] { "IdWniosku" });
            DropForeignKey("dbo.FormularzeK1N", "IdWniosku", "dbo.Wnioski");
            RenameColumn(table: "dbo.FormularzeK1N", name: "IdWniosku", newName: "Wniosek_IdWniosku");
            CreateIndex("dbo.FormularzeK1N", "Wniosek_IdWniosku");
            AddForeignKey("dbo.FormularzeK1N", "Wniosek_IdWniosku", "dbo.Wnioski", "IdWniosku");
        }
    }
}
