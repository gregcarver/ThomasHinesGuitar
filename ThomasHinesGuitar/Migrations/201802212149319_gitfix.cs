namespace ThomasHinesGuitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gitfix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 255),
                        Name = c.String(nullable: false),
                        orderNumber = c.Int(nullable: false),
                        dateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerOrders");
        }
    }
}
