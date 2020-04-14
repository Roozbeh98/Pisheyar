using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblCategoryConfiguration : IEntityTypeConfiguration<TblCategory>
    {
        public void Configure(EntityTypeBuilder<TblCategory> entity)
        {
            entity.HasKey(e => e.CategoryGuid);

            entity.ToTable("Tbl_Category");

            entity.Property(e => e.CategoryGuid)
                .HasColumnName("Category_Guid")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.CategoryCategoryGuid)
                .HasColumnName("Category_CategoryGuid");

            entity.Property(e => e.CategoryCreateDate)
                .HasColumnName("Category_CreateDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.CategoryDisplay)
                .IsRequired()
                .HasColumnName("Category_Display")
                .HasMaxLength(128);

            entity.Property(e => e.CategoryIsDelete)
                .HasColumnName("Category_IsDelete")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.CategoryModifyDate)
                .HasColumnName("Category_ModifyDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.CategoryOrder)
                .HasColumnName("Category_Order");

            entity.HasOne(d => d.CategoryCategoryGu)
                .WithMany(p => p.InverseCategoryCategoryGu)
                .HasForeignKey(d => d.CategoryCategoryGuid)
                .HasConstraintName("FK_Tbl_Category_Tbl_Category");
        }
    }
}
