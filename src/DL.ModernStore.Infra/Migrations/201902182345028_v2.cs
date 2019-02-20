namespace DL.ModernStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.OrderItems", "Product_Id", "dbo.Products");
            DropIndex("dbo.Customers", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.OrderItems", new[] { "Product_Id" });
            RenameColumn(table: "dbo.Customers", name: "Name_FirtName", newName: "FirtName");
            RenameColumn(table: "dbo.Customers", name: "Name_LastName", newName: "LastName");
            RenameColumn(table: "dbo.Customers", name: "Document_Number", newName: "Document");
            RenameColumn(table: "dbo.Customers", name: "Email_Address", newName: "Email");
            AddColumn("dbo.Customers", "UserName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Customers", "Password", c => c.String(nullable: false, maxLength: 32, fixedLength: true));
            AddColumn("dbo.Customers", "User_Active", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Customers", "FirtName", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Customers", "Document", c => c.String(nullable: false, maxLength: 11, fixedLength: true));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 160));
            AlterColumn("dbo.Customers", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "User_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Orders", "Number", c => c.String(nullable: false, maxLength: 8, fixedLength: true));
            AlterColumn("dbo.Orders", "DeliveryFee", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Orders", "Discount", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Orders", "Customer_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.OrderItems", "Price", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.OrderItems", "Product_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Products", "Title", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Products", "Image", c => c.String(nullable: false, maxLength: 1024));
            CreateIndex("dbo.Orders", "Customer_Id");
            CreateIndex("dbo.OrderItems", "Product_Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderItems", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.OrderItems", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.OrderItems", new[] { "Product_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            AlterColumn("dbo.Products", "Image", c => c.String());
            AlterColumn("dbo.Products", "Title", c => c.String());
            AlterColumn("dbo.OrderItems", "Product_Id", c => c.Guid());
            AlterColumn("dbo.OrderItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "Customer_Id", c => c.Guid());
            AlterColumn("dbo.Orders", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "DeliveryFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "Number", c => c.String());
            AlterColumn("dbo.Customers", "User_Id", c => c.Guid());
            AlterColumn("dbo.Customers", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "Document", c => c.String());
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "FirtName", c => c.String());
            DropColumn("dbo.Customers", "User_Active");
            DropColumn("dbo.Customers", "Password");
            DropColumn("dbo.Customers", "UserName");
            RenameColumn(table: "dbo.Customers", name: "Email", newName: "Email_Address");
            RenameColumn(table: "dbo.Customers", name: "Document", newName: "Document_Number");
            RenameColumn(table: "dbo.Customers", name: "LastName", newName: "Name_LastName");
            RenameColumn(table: "dbo.Customers", name: "FirtName", newName: "Name_FirtName");
            CreateIndex("dbo.OrderItems", "Product_Id");
            CreateIndex("dbo.Orders", "Customer_Id");
            CreateIndex("dbo.Customers", "User_Id");
            AddForeignKey("dbo.OrderItems", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Customers", "User_Id", "dbo.Users", "Id");
        }
    }
}
