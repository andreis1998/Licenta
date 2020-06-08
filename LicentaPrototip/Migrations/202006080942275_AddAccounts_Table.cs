namespace LicentaPrototip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccounts_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Guid(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        IsAdultAccount = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Accounts");
        }
    }
}
