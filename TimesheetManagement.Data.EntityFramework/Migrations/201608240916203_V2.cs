using System.Data.Entity.Migrations;

namespace TimesheetManagement.Data.EntityFramework.Migrations
{
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Task", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Project", "TaxpayerIdentificationNumber", "dbo.Account");
            DropIndex("dbo.Project", new[] {"TaxpayerIdentificationNumber"});
            DropIndex("dbo.Task", new[] {"AccountId"});
            RenameColumn("dbo.Project", "TaxpayerIdentificationNumber", "AccountId");
            AlterColumn("dbo.Project", "AccountId", c => c.String(false, 9));
            CreateIndex("dbo.Project", "AccountId");
            AddForeignKey("dbo.Project", "AccountId", "dbo.Account", "TaxpayerIdentificationNumber", true);
            DropColumn("dbo.Task", "AccountId");
        }

        public override void Down()
        {
            AddColumn("dbo.Task", "AccountId", c => c.String(maxLength: 9));
            DropForeignKey("dbo.Project", "AccountId", "dbo.Account");
            DropIndex("dbo.Project", new[] {"AccountId"});
            AlterColumn("dbo.Project", "AccountId", c => c.String(maxLength: 9));
            RenameColumn("dbo.Project", "AccountId", "TaxpayerIdentificationNumber");
            CreateIndex("dbo.Task", "AccountId");
            CreateIndex("dbo.Project", "TaxpayerIdentificationNumber");
            AddForeignKey("dbo.Project", "TaxpayerIdentificationNumber", "dbo.Account", "TaxpayerIdentificationNumber");
            AddForeignKey("dbo.Task", "AccountId", "dbo.Account", "TaxpayerIdentificationNumber");
        }
    }
}