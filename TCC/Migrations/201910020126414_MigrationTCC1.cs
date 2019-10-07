namespace TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationTCC1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        CEP = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Corporations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cnpj = c.String(),
                        Adress_Id = c.Int(),
                        Category_Id = c.Int(),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adresses", t => t.Adress_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .Index(t => t.Adress_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Contact_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Corporations", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Corporations", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Corporations", "Adress_Id", "dbo.Adresses");
            DropIndex("dbo.Corporations", new[] { "Contact_Id" });
            DropIndex("dbo.Corporations", new[] { "Category_Id" });
            DropIndex("dbo.Corporations", new[] { "Adress_Id" });
            DropTable("dbo.Corporations");
            DropTable("dbo.Contacts");
            DropTable("dbo.Categories");
            DropTable("dbo.Adresses");
        }
    }
}
