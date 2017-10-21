namespace MyNewWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tanks", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tanks", "Image", c => c.Binary(nullable: false));
        }
    }
}
