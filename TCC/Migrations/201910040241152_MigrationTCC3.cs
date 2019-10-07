namespace TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationTCC3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Corporations", newName: "Companies");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Companies", newName: "Corporations");
        }
    }
}
