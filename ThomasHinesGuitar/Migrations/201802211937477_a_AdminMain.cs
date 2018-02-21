namespace ThomasHinesGuitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a_AdminMain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminMains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Contact = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminMains");
        }
    }
}
