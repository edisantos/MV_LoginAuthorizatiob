namespace DemoAuthentication.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "PermanecerLogado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "PermanecerLogado");
        }
    }
}
