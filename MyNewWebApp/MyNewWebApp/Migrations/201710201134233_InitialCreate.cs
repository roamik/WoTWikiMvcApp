namespace MyNewWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tanks",
                c => new
                    {
                        TankId = c.Int(nullable: false, identity: true),
                        TankLevel = c.Int(nullable: false),
                        TankName = c.String(),
                        TankNation = c.String(),
                        TankDescription = c.String(),
                    })
                .PrimaryKey(t => t.TankId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tanks");
        }
    }
}
