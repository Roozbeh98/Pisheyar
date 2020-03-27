using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblTagConfiguration : IEntityTypeConfiguration<TblTag>
    {
        public void Configure(EntityTypeBuilder<TblTag> entity)
        {
            entity.HasKey(e => e.TagId);

            entity.ToTable("Tbl_Tag");

            entity.Property(e => e.TagId)
                .HasColumnName("Tag_ID");

            entity.Property(e => e.TagCreateDate)
                .HasColumnName("Tag_CreateDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.TagGuid)
                .HasColumnName("Tag_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.TagIsDelete)
                .HasColumnName("Tag_IsDelete")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.TagModifyDate)
                .HasColumnName("Tag_ModifyDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.TagName)
                .IsRequired()
                .HasColumnName("Tag_Name");

            entity.Property(e => e.TagUsage)
                .HasColumnName("Tag_Usage")
                .HasDefaultValueSql("((0))");
        }
    }
}
