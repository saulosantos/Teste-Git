namespace Teste.GitHub.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeiroMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        PessoaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Endereco = c.String(maxLength: 100, unicode: false),
                        CPF = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Telefone = c.String(nullable: false, maxLength: 11, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaId);
            
            CreateTable(
                "dbo.Propriedades",
                c => new
                    {
                        PropriedadeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Endereco = c.String(maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        PessoaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PropriedadeId)
                .ForeignKey("dbo.Pessoas", t => t.PessoaId)
                .Index(t => t.PessoaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Propriedades", "PessoaId", "dbo.Pessoas");
            DropIndex("dbo.Propriedades", new[] { "PessoaId" });
            DropTable("dbo.Propriedades");
            DropTable("dbo.Pessoas");
        }
    }
}
