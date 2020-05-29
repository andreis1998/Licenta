namespace LicentaPrototip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GuidPrimaryKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.HouseParameters");
            AddColumn("dbo.HouseParameters", "ParameterId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.HouseParameters", "ParameterId");
            DropColumn("dbo.HouseParameters", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HouseParameters", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.HouseParameters");
            DropColumn("dbo.HouseParameters", "ParameterId");
            AddPrimaryKey("dbo.HouseParameters", "Id");
        }
    }
}
