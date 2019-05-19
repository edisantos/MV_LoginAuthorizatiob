namespace DemoAuthentication.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "UserName", c => c.String(nullable: false, maxLength: 12, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "UserName");
        }
    }
}
