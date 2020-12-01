using Microsoft.EntityFrameworkCore;
using NLayer_Workflow.DataAccess.Concrete.EntityFramework.Mapping;
using NLayer_Workflow.Entities.Concrete;

namespace NLayer_Workflow.DataAccess.Concrete.EntityFramework.Contexts
{
    public class MyDataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\MSSQLLocalDB;Database=WorkFlowDB;Trusted_Connection=true;"); //Connetion String'i verdik
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API Kodlarımızı ayrı classlarda yazarak okuabilirliği arttırmış olduk
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new WorkMap());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Work> Works { get; set; }
    }
}
