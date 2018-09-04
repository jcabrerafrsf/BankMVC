namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CustomerId = c.Guid(nullable: false),
                        AccountTypeId = c.Guid(nullable: false),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountTypes", t => t.AccountTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.AccountTypeId);
            
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        MaxDeposit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxExtracion = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxTransfer = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        DNI = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 85),
                        Phone = c.String(nullable: false, maxLength: 25),
                        Email = c.String(nullable: false, maxLength: 100),
                        BankId = c.Guid(nullable: false),
                        CustomerType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId, cascadeDelete: true)
                .Index(t => t.BankId);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movements",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        AccountId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movements", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "BankId", "dbo.Banks");
            DropForeignKey("dbo.Accounts", "AccountTypeId", "dbo.AccountTypes");
            DropIndex("dbo.Movements", new[] { "AccountId" });
            DropIndex("dbo.Customers", new[] { "BankId" });
            DropIndex("dbo.Accounts", new[] { "AccountTypeId" });
            DropIndex("dbo.Accounts", new[] { "CustomerId" });
            DropTable("dbo.Movements");
            DropTable("dbo.Banks");
            DropTable("dbo.Customers");
            DropTable("dbo.AccountTypes");
            DropTable("dbo.Accounts");
        }
    }
}
