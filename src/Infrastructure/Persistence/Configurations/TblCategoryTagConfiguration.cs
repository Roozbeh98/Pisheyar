using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblCategoryTagConfiguration : IEntityTypeConfiguration<TblCategoryTag>
    {
        public void Configure(EntityTypeBuilder<TblCategoryTag> entity)
        {
            entity.HasKey(e => e.CategoryTagId);

            entity.ToTable("Tbl_CategoryTag");

            entity.HasIndex(e => e.CategoryTagCategoryId);

            entity.HasIndex(e => e.CategoryTagTagId);

            entity.Property(e => e.CategoryTagId)
                .HasColumnName("CategoryTag_ID");

            entity.Property(e => e.CategoryTagCategoryId)
                .HasColumnName("CategoryTag_CategoryID");

            entity.Property(e => e.CategoryTagGuid)
                .HasColumnName("CategoryTag_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.CategoryTagTagId)
                .HasColumnName("CategoryTag_TagID");

            entity.HasOne(d => d.CategoryTagCategory)
                .WithMany(p => p.TblCategoryTag)
                .HasForeignKey(d => d.CategoryTagCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_CategoryTag_Tbl_Category");

            entity.HasOne(d => d.CategoryTagTag)
                .WithMany(p => p.TblCategoryTag)
                .HasForeignKey(d => d.CategoryTagTagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_CategoryTag_Tbl_Tag");
        }
    }
}
