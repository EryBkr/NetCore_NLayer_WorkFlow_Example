using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.DataAccess.Concrete.EntityFramework.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User> //Konfigürasyonlarımızı modüler yapabilmek için ayrı bir sınıf oluşturduk.Burada fluent api işlemlerimizi kullanabiliriz
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();

            builder.Property(i => i.Name).HasMaxLength(100).IsRequired();
            builder.Property(i => i.Surname).HasMaxLength(100).IsRequired(false);
            builder.Property(i => i.Phone).HasMaxLength(50).IsRequired();
            builder.Property(i => i.Email).HasMaxLength(100).IsRequired();

            builder.HasMany(i => i.Works).WithOne(i => i.User).HasForeignKey(i => i.UserId)/*.OnDelete(DeleteBehavior.Cascade)*/; //İlişkiyi belirttik.Cascade parametresini verirsek kullanıcı silinirse onun ilişkide olduğu tablo satırlarıda silinir
        }
    }
}
