namespace SampleEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdministrationId = c.Int(nullable: false),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Administrations", t => t.AdministrationId, cascadeDelete: true)
                .Index(t => t.AdministrationId);
            
            CreateTable(
                "dbo.InvoiceLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: false)
                .Index(t => t.InvoiceId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdministrationId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Administrations", t => t.AdministrationId, cascadeDelete: true)
                .Index(t => t.AdministrationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceLines", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "AdministrationId", "dbo.Administrations");
            DropForeignKey("dbo.InvoiceLines", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "AdministrationId", "dbo.Administrations");
            DropIndex("dbo.Items", new[] { "AdministrationId" });
            DropIndex("dbo.InvoiceLines", new[] { "ItemId" });
            DropIndex("dbo.InvoiceLines", new[] { "InvoiceId" });
            DropIndex("dbo.Invoices", new[] { "AdministrationId" });
            DropTable("dbo.Items");
            DropTable("dbo.InvoiceLines");
            DropTable("dbo.Invoices");
            DropTable("dbo.Administrations");
        }
    }
}
