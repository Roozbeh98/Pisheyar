using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblPostCategoryConfiguration : IEntityTypeConfiguration<TblPostCategory>
    {
        public void Configure(EntityTypeBuilder<TblPostCategory> entity)
        {
            entity.HasKey(e => e.PcGuid);

            entity.ToTable("Tbl_PostCategory");

            entity.HasIndex(e => e.PcCategoryGuid);

            entity.HasIndex(e => e.PcPostGuid);

            entity.Property(e => e.PcCategoryGuid)
                .HasColumnName("PC_CategoryGuid");

            entity.Property(e => e.PcGuid)
                .HasColumnName("PC_Guid")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.PcPostGuid)
                .HasColumnName("PC_PostGuid");

            entity.HasOne(d => d.PcCategoryGu)
                .WithMany(p => p.TblPostCategory)
                .HasForeignKey(d => d.PcCategoryGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_PostCategory_Tbl_Category");

            entity.HasOne(d => d.PcPost)
                .WithMany(p => p.TblPostCategory)
                .HasForeignKey(d => d.PcPostGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_PostCategory_Tbl_Post");
        }
    }
}
