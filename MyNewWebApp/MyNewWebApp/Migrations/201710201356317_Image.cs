namespace MyNewWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tanks", "ImageId", c => c.Int(nullable: false));
            AddColumn("dbo.Tanks", "ImageName", c => c.String());
            AddColumn("dbo.Tanks", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tanks", "Image");
            DropColumn("dbo.Tanks", "ImageName");
            DropColumn("dbo.Tanks", "ImageId");
        }
    }
}
