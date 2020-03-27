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
            entity.HasKey(e => e.CtId);

            entity.ToTable("Tbl_CategoryTag");

            entity.HasIndex(e => e.CtTagId);

            entity.Property(e => e.CtId)
                .HasColumnName("CT_ID");

            entity.Property(e => e.CtCategoryGuid)
                .HasColumnName("CT_CategoryGuid");

            entity.Property(e => e.CtGuid)
                .HasColumnName("CT_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.CtTagId)
                .HasColumnName("CT_TagID");

            entity.HasOne(d => d.CtCategoryGu)
                .WithMany(p => p.TblCategoryTag)
                .HasForeignKey(d => d.CtCategoryGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_CategoryTag_Tbl_Category");

            entity.HasOne(d => d.CtTag)
                .WithMany(p => p.TblCategoryTag)
                .HasForeignKey(d => d.CtTagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_CategoryTag_Tbl_Tag");
        }
    }
}
