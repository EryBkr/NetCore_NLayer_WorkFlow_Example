using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NLayer_Workflow.DataAccess.Concrete.EntityFramework.Mapping;
using NLayer_Workflow.Entities.Concrete;

namespace NLayer_Workflow.DataAccess.Concrete.EntityFramework.Contexts
{
    public class MyDataContext:IdentityDbContext<AppUser,AppRole,int> //Kullanacağı User ,Role ve diğer tabloların primary key tipini verdim
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\MSSQLLocalDB;Database=WorkFlowDB;Trusted_Connection=true;"); //Connetion String'i verdik
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API Kodlarımızı ayrı classlarda yazarak okuabilirliği arttırmış olduk
            modelBuilder.ApplyConfiguration(new WorkMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new UrgencyMap());
            modelBuilder.ApplyConfiguration(new ReportMap());
            modelBuilder.ApplyConfiguration(new NotifyMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Work> Works { get; set; }
        public DbSet<Urgency> Urgencies { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
