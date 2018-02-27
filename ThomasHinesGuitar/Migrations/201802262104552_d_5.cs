namespace ThomasHinesGuitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d_5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AboutModels", "aboutView", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AboutModels", "aboutView", c => c.String());
        }
    }
}
