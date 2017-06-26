namespace KamilCieślikLab4PD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Time", c => c.String());
        }
    }
}
