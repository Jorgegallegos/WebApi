namespace MajeBud.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRowVersionToBug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bugs", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bugs", "RowVersion");
        }
    }
}
