namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class size_K3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FormularzeK3", "Uzasadnienie", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK3", "Uwagi", c => c.String(maxLength: 500));
            AlterColumn("dbo.FormularzeK3", "WniosekZawiera", c => c.String(maxLength: 500));
            DropColumn("dbo.FormularzeK3", "Zalacznik");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FormularzeK3", "Zalacznik", c => c.String());
            AlterColumn("dbo.FormularzeK3", "WniosekZawiera", c => c.String());
            AlterColumn("dbo.FormularzeK3", "Uwagi", c => c.String());
            AlterColumn("dbo.FormularzeK3", "Uzasadnienie", c => c.String());
        }
    }
}
