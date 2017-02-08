namespace Teste.GitHub.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quarta0802 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pessoas", "Email", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pessoas", "Email", c => c.String(maxLength: 8000, unicode: false));
        }
    }
}
