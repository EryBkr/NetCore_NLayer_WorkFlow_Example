using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer_Workflow.Entities.Concrete;

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

            builder.HasOne(i => i.Urgency).WithMany(i => i.Works).HasForeignKey(i => i.UrgencyId);//Nullable olmadığı için UrgencyId Bu tablodan kayıt silinmesini istemiyoruz
        }
    }
}
