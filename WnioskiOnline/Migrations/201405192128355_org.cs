namespace WnioskiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormularzeK1N", "IdOrganizacji", c => c.Int(nullable: false));
            AddForeignKey("dbo.FormularzeK1N", "IdOrganizacji", "dbo.Organizacje", "IdOrganizacji", cascadeDelete: true);
            CreateIndex("dbo.FormularzeK1N", "IdOrganizacji");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FormularzeK1N", new[] { "IdOrganizacji" });
            DropForeignKey("dbo.FormularzeK1N", "IdOrganizacji", "dbo.Organizacje");
            DropColumn("dbo.FormularzeK1N", "IdOrganizacji");
        }
    }
}
