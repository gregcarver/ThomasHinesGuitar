namespace ThomasHinesGuitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d_ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminMains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Contact = c.String(nullable: false),
                        Location = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropTable("dbo.ContactViewModels");
            DropTable("dbo.AdminMains");
        }
    }
}
