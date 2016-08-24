namespace TimesheetManagement.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Task", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Project", "TaxpayerIdentificationNumber", "dbo.Account");
            DropIndex("dbo.Project", new[] { "TaxpayerIdentificationNumber" });
            DropIndex("dbo.Task", new[] { "AccountId" });
            RenameColumn(table: "dbo.Project", name: "TaxpayerIdentificationNumber", newName: "AccountId");
            AlterColumn("dbo.Project", "AccountId", c => c.String(nullable: false, maxLength: 9));
            CreateIndex("dbo.Project", "AccountId");
            AddForeignKey("dbo.Project", "AccountId", "dbo.Account", "TaxpayerIdentificationNumber", cascadeDelete: true);
            DropColumn("dbo.Task", "AccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Task", "AccountId", c => c.String(maxLength: 9));
            DropForeignKey("dbo.Project", "AccountId", "dbo.Account");
            DropIndex("dbo.Project", new[] { "AccountId" });
            AlterColumn("dbo.Project", "AccountId", c => c.String(maxLength: 9));
            RenameColumn(table: "dbo.Project", name: "AccountId", newName: "TaxpayerIdentificationNumber");
            CreateIndex("dbo.Task", "AccountId");
            CreateIndex("dbo.Project", "TaxpayerIdentificationNumber");
            AddForeignKey("dbo.Project", "TaxpayerIdentificationNumber", "dbo.Account", "TaxpayerIdentificationNumber");
            AddForeignKey("dbo.Task", "AccountId", "dbo.Account", "TaxpayerIdentificationNumber");
        }
    }
}
