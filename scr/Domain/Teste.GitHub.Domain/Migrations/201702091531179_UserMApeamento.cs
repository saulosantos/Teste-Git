namespace Teste.GitHub.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserMApeamento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoUsuario",
                c => new
                    {
                        TipoUsuarioId = c.Int(nullable: false, identity: true),
                        NomeTipoUsuario = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoUsuarioId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        NomeUsuario = c.String(nullable: false, maxLength: 8000, unicode: false),
                        LoginUser = c.String(nullable: false, maxLength: 8000, unicode: false),
                        SenhaUsuario = c.String(nullable: false, maxLength: 15),
                        ConfirmaSenha = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        TipoUsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.TipoUsuario", t => t.TipoUsuarioId)
                .Index(t => t.TipoUsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "TipoUsuarioId", "dbo.TipoUsuario");
            DropIndex("dbo.Usuario", new[] { "TipoUsuarioId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.TipoUsuario");
        }
    }
}
