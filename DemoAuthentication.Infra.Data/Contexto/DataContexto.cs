using DemoAuthentication.Application.ViewModels;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DemoAuthentication.Infra.Data.Contexto
{
    public class DataContexto:DbContext
    {
        
        public DataContexto()
            :base(@"Data Source=DESKTOP-1Q2TUU2\LEMOSDATABASE;Initial Catalog=DemoDatabase;Integrated Security=True")
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
