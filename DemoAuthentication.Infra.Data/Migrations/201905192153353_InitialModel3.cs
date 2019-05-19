namespace DemoAuthentication.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuario", "Senha", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuario", "Senha", c => c.String(nullable: false, maxLength: 12, unicode: false));
        }
    }
}
