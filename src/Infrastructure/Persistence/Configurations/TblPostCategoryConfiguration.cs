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
            entity.HasKey(e => e.PcId);

            entity.ToTable("Tbl_PostCategory");

            entity.HasIndex(e => e.PcPostId);

            entity.Property(e => e.PcId)
                .HasColumnName("PC_ID");

            entity.Property(e => e.PcCategoryGuid)
                .HasColumnName("PC_CategoryGuid");

            entity.Property(e => e.PcGuid)
                .HasColumnName("PC_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.PcPostId)
                .HasColumnName("PC_PostID");

            entity.HasOne(d => d.PcCategoryGu)
                .WithMany(p => p.TblPostCategory)
                .HasForeignKey(d => d.PcCategoryGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_PostCategory_Tbl_Category");

            entity.HasOne(d => d.PcPost)
                .WithMany(p => p.TblPostCategory)
                .HasForeignKey(d => d.PcPostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_PostCategory_Tbl_Post");
        }
    }
}
