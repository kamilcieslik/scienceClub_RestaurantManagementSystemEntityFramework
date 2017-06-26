namespace KamilCieślikLab4PD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Time", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Time");
        }
    }
}
