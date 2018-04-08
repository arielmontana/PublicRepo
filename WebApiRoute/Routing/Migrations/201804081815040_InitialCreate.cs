namespace Routing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeagueModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        caption = c.String(),
                        leagueCaption = c.String(),
                        year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LeagueModels");
        }
    }
}
