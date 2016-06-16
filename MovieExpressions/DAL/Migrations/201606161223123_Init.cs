namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Author = c.String(nullable: false, maxLength: 100),
                        Time = c.DateTime(nullable: false),
                        Text = c.String(nullable: false, maxLength: 1000),
                        Film_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Films", t => t.Film_ID)
                .Index(t => t.Film_ID);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.String(),
                        Rating = c.String(),
                        Plot = c.String(),
                        IMDbUrl = c.String(),
                        Poster = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Film_ID", "dbo.Films");
            DropIndex("dbo.Comments", new[] { "Film_ID" });
            DropTable("dbo.Films");
            DropTable("dbo.Comments");
        }
    }
}
