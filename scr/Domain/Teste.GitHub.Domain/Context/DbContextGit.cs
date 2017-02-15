using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.GitHub.Domain.Entidades;

namespace Teste.GitHub.Domain.Context
{
   public class DbContextGit : DbContext
    {

        public DbContextGit() : base("DbContextGit")
        {
            //Cria o Banco de Dados caso ele não exista
            //Depois do new, existem outras opções de criação
            Database.SetInitializer(new CreateDatabaseIfNotExists<DbContextGit>());





        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Propriedade> propriedades { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Usuario> Usurios { get; set; }
        public DbSet<ArquivoPessoa> ArquivosPessoas { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();
            modelBuilder.Entity<Pessoa>().ToTable("Pessoas");
            modelBuilder.Entity<Propriedade>().ToTable("Propriedades");
            base.OnModelCreating(modelBuilder);
        }
    }
}
