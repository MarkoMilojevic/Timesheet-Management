namespace TimesheetManagement.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Account", newName: "Client");
            RenameColumn(table: "dbo.Project", name: "AccountId", newName: "ClientId");
            RenameIndex(table: "dbo.Project", name: "IX_AccountId", newName: "IX_ClientId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Project", name: "IX_ClientId", newName: "IX_AccountId");
            RenameColumn(table: "dbo.Project", name: "ClientId", newName: "AccountId");
            RenameTable(name: "dbo.Client", newName: "Account");
        }
    }
}
