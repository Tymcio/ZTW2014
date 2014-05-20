namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Idwniosku1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FormularzeK2", "Wniosek_IdWniosku", "dbo.Wnioski");
            DropIndex("dbo.FormularzeK2", new[] { "Wniosek_IdWniosku" });
            RenameColumn(table: "dbo.FormularzeK2", name: "Wniosek_IdWniosku", newName: "IdWniosku");
            AddForeignKey("dbo.FormularzeK2", "IdWniosku", "dbo.Wnioski", "IdWniosku", cascadeDelete: true);
            CreateIndex("dbo.FormularzeK2", "IdWniosku");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FormularzeK2", new[] { "IdWniosku" });
            DropForeignKey("dbo.FormularzeK2", "IdWniosku", "dbo.Wnioski");
            RenameColumn(table: "dbo.FormularzeK2", name: "IdWniosku", newName: "Wniosek_IdWniosku");
            CreateIndex("dbo.FormularzeK2", "Wniosek_IdWniosku");
            AddForeignKey("dbo.FormularzeK2", "Wniosek_IdWniosku", "dbo.Wnioski", "IdWniosku");
        }
    }
}
