namespace LicentaPrototip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_AccountsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Password", c => c.String());
            CreateIndex("dbo.Accounts", "IsAdmin", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Accounts", new[] { "IsAdmin" });
            DropColumn("dbo.Accounts", "Password");
        }
    }
}
