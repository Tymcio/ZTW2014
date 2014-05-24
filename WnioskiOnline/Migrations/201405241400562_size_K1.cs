namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class size_K1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FormularzeK1N", "InfoOWarunkach", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK1N", "StanZaawans", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK1N", "StanWiedzy", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK1N", "SkladZespolu", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK1N", "Wspolpraca", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK1N", "TytulNumerUmowy", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK1N", "RezultatMaterialny", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK1N", "RezultatPoznawczy", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK1N", "RezultatSpoleczny", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK1N", "NowosciCelu", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK1N", "NowosciRozwiazan", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK1N", "NowosciRealizacji", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK1N", "NowosciDoboru", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK1N", "Upowszechnienie", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK1N", "PozyskiwanieSponsorow", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FormularzeK1N", "PozyskiwanieSponsorow", c => c.String());
            AlterColumn("dbo.FormularzeK1N", "Upowszechnienie", c => c.String());
            AlterColumn("dbo.FormularzeK1N", "NowosciDoboru", c => c.String());
            AlterColumn("dbo.FormularzeK1N", "NowosciRealizacji", c => c.String());
            AlterColumn("dbo.FormularzeK1N", "NowosciRozwiazan", c => c.String());
            AlterColumn("dbo.FormularzeK1N", "NowosciCelu", c => c.String());
            AlterColumn("dbo.FormularzeK1N", "RezultatSpoleczny", c => c.String());
            AlterColumn("dbo.FormularzeK1N", "RezultatPoznawczy", c => c.String());
            AlterColumn("dbo.FormularzeK1N", "RezultatMaterialny", c => c.String());
            AlterColumn("dbo.FormularzeK1N", "TytulNumerUmowy", c => c.String());
            AlterColumn("dbo.FormularzeK1N", "Wspolpraca", c => c.String());
            AlterColumn("dbo.FormularzeK1N", "SkladZespolu", c => c.String());
            AlterColumn("dbo.FormularzeK1N", "StanWiedzy", c => c.String());
            AlterColumn("dbo.FormularzeK1N", "StanZaawans", c => c.String());
            AlterColumn("dbo.FormularzeK1N", "InfoOWarunkach", c => c.String());
        }
    }
}
