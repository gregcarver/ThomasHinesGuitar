namespace ThomasHinesGuitar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d_1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomerOrders", "orderNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerOrders", "orderNumber", c => c.Int(nullable: false));
        }
    }
}
