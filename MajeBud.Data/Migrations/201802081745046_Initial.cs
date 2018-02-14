namespace MajeBud.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bugs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 120),
                        Body = c.String(nullable: false, maxLength: 500),
                        IsFixed = c.Boolean(nullable: false),
                        StepsToReproduce = c.String(maxLength: 250),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(),
                        CreatedById = c.String(nullable: false, maxLength: 128),
                        ModfiedById = c.String(maxLength: 128),
                        Severity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ModfiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.ModfiedById);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreatedAd = c.DateTime(nullable: false),
                        DisplayName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bugs", "ModfiedById", "dbo.Users");
            DropForeignKey("dbo.Bugs", "CreatedById", "dbo.Users");
            DropIndex("dbo.Bugs", new[] { "ModfiedById" });
            DropIndex("dbo.Bugs", new[] { "CreatedById" });
            DropTable("dbo.Users");
            DropTable("dbo.Bugs");
        }
    }
}
