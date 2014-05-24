namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class size_koordynator : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Koordynatorzy", "Imie", c => c.String(maxLength: 40));
            AlterColumn("dbo.Koordynatorzy", "Nazwisko", c => c.String(maxLength: 40));
            AlterColumn("dbo.Koordynatorzy", "NrIndeksu", c => c.String(maxLength: 20));
            AlterColumn("dbo.Koordynatorzy", "Telefon", c => c.String(maxLength: 15));
            AlterColumn("dbo.Koordynatorzy", "Email", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Koordynatorzy", "Email", c => c.String());
            AlterColumn("dbo.Koordynatorzy", "Telefon", c => c.String());
            AlterColumn("dbo.Koordynatorzy", "NrIndeksu", c => c.String());
            AlterColumn("dbo.Koordynatorzy", "Nazwisko", c => c.String());
            AlterColumn("dbo.Koordynatorzy", "Imie", c => c.String());
        }
    }
}
