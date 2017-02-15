namespace Teste.GitHub.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArquivosUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArquivoPessoa",
                c => new
                    {
                        ArquivoPessoaId = c.Int(nullable: false, identity: true),
                        ArquivoCaminho = c.String(nullable: false, maxLength: 100, unicode: false),
                        extencao = c.String(maxLength: 5, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        PessoaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArquivoPessoaId)
                .ForeignKey("dbo.Pessoas", t => t.PessoaId)
                .Index(t => t.PessoaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArquivoPessoa", "PessoaId", "dbo.Pessoas");
            DropIndex("dbo.ArquivoPessoa", new[] { "PessoaId" });
            DropTable("dbo.ArquivoPessoa");
        }
    }
}
