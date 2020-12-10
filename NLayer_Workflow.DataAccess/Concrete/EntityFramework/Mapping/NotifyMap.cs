using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.DataAccess.Concrete.EntityFramework.Mapping
{
    public class NotifyMap : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();
            builder.Property(i => i.Description).HasColumnType("ntext").IsRequired();
            builder.HasOne(i => i.AppUser).WithMany(i => i.Notifications).HasForeignKey(i => i.AppUserId); //İlişkinin tek tarafı appuser , appuser'ın çok ilişkisi notification,aralarında ki foreignkey ise AppUserId olarak tanımlandı

        }
    }
}
