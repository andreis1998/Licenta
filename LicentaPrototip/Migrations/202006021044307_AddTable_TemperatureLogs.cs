namespace LicentaPrototip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable_TemperatureLogs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TemperatureLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TemperatureLogs");
        }
    }
}
