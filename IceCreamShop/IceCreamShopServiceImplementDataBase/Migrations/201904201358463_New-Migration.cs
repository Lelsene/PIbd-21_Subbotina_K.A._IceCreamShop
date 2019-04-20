namespace IceCreamShopServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Icemen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IcemanFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Bookings", "IcemanId", c => c.Int());
            CreateIndex("dbo.Bookings", "IcemanId");
            AddForeignKey("dbo.Bookings", "IcemanId", "dbo.Icemen", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "IcemanId", "dbo.Icemen");
            DropIndex("dbo.Bookings", new[] { "IcemanId" });
            DropColumn("dbo.Bookings", "IcemanId");
            DropTable("dbo.Icemen");
        }
    }
}
