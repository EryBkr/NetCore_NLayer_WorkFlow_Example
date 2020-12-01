using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.DataAccess.Concrete.EntityFramework.Mapping
{
   public class WorkMap : IEntityTypeConfiguration<Work> //Konfigürasyonlarımızı modüler yapabilmek için ayrı bir sınıf oluşturduk.Burada fluent api işlemlerimizi kullanabiliriz
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();

            builder.Property(i => i.Name).HasMaxLength(200);
            builder.Property(i => i.Description).HasColumnType("ntext");
        }
    }
}
