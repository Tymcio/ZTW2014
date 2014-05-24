namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class size_K2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FormularzeK2", "Celowosc", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK2", "DlaczegoZasluguje", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK2", "DlaczegoLepszy", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK2", "StopienInnowacji", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK2", "JakAngazuje", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK2", "JakieWarunki", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK2", "JakiePodobnePierwszy", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK2", "JakiePodobneDrugi", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK2", "WkladFinansowy", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK2", "Sponsorzy", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK2", "JakPromuje", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK2", "InneInformacje", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FormularzeK2", "InneInformacje", c => c.String());
            AlterColumn("dbo.FormularzeK2", "JakPromuje", c => c.String());
            AlterColumn("dbo.FormularzeK2", "Sponsorzy", c => c.String());
            AlterColumn("dbo.FormularzeK2", "WkladFinansowy", c => c.String());
            AlterColumn("dbo.FormularzeK2", "JakiePodobneDrugi", c => c.String());
            AlterColumn("dbo.FormularzeK2", "JakiePodobnePierwszy", c => c.String());
            AlterColumn("dbo.FormularzeK2", "JakieWarunki", c => c.String());
            AlterColumn("dbo.FormularzeK2", "JakAngazuje", c => c.String());
            AlterColumn("dbo.FormularzeK2", "StopienInnowacji", c => c.String());
            AlterColumn("dbo.FormularzeK2", "DlaczegoLepszy", c => c.String());
            AlterColumn("dbo.FormularzeK2", "DlaczegoZasluguje", c => c.String());
            AlterColumn("dbo.FormularzeK2", "Celowosc", c => c.String());
        }
    }
}
