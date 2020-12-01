using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.DataAccess.Concrete.EntityFramework.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser> //Konfigürasyonlarımızı modüler yapabilmek için ayrı bir sınıf oluşturduk.Burada fluent api işlemlerimizi kullanabiliriz
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(i => i.Name).HasMaxLength(100);
            builder.Property(i => i.Surname).HasMaxLength(100);

            builder.HasMany(i => i.Works).WithOne(i => i.AppUser).HasForeignKey(i => i.AppUserId).OnDelete(DeleteBehavior.SetNull); //AppUser tablosuna çok ilişkiyle bağlanan tabloyu tanıttık , o tablonun tekil ilişkisini tanımladık , ardına foreignkey ve user ın silinmesi durumunda görevin silinmemesi gerektiğini belirttik
        }
    }
}
