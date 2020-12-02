﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;

namespace NLayer_Workflow.DataAccess.Concrete.EntityFramework.Mapping
{
    public class ReportMap : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();
            builder.Property(i => i.Description).HasMaxLength(100).IsRequired();
            builder.Property(i => i.Detail).HasColumnType("ntext");

            builder.HasOne(i => i.Work).WithMany(i => i.Reports).HasForeignKey(i => i.WorkId);
        }
    }
}
