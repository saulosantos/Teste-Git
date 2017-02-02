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
                
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Propriedade> propriedades { get; set; }


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
