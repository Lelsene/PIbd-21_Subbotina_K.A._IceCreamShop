namespace IceCreamShopServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        IceCreamId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateImplement = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.IceCreams", t => t.IceCreamId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.IceCreamId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IceCreams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IceCreamName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IceCreamIngredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IceCreamId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                        IngredientName = c.String(),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .Index(t => t.IngredientId);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StorageIngredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StorageId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.StorageId)
                .Index(t => t.IngredientId);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StorageName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StorageIngredients", "StorageId", "dbo.Storages");
            DropForeignKey("dbo.StorageIngredients", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.IceCreamIngredients", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.Bookings", "IceCreamId", "dbo.IceCreams");
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            DropIndex("dbo.StorageIngredients", new[] { "IngredientId" });
            DropIndex("dbo.StorageIngredients", new[] { "StorageId" });
            DropIndex("dbo.IceCreamIngredients", new[] { "IngredientId" });
            DropIndex("dbo.Bookings", new[] { "IceCreamId" });
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropTable("dbo.Storages");
            DropTable("dbo.StorageIngredients");
            DropTable("dbo.Ingredients");
            DropTable("dbo.IceCreamIngredients");
            DropTable("dbo.IceCreams");
            DropTable("dbo.Customers");
            DropTable("dbo.Bookings");
        }
    }
}
