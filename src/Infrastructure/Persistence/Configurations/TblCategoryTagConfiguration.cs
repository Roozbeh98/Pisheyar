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
            entity.HasKey(e => e.CtGuid);

            entity.ToTable("Tbl_CategoryTag");

            entity.HasIndex(e => e.CtCategoryGuid);

            entity.HasIndex(e => e.CtTagGuid);

            entity.Property(e => e.CtCategoryGuid)
                .HasColumnName("CT_CategoryGuid");

            entity.Property(e => e.CtGuid)
                .HasColumnName("CT_Guid")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.CtTagGuid)
                .HasColumnName("CT_TagGuid");

            entity.HasOne(d => d.CtCategoryGu)
                .WithMany(p => p.TblCategoryTag)
                .HasForeignKey(d => d.CtCategoryGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_CategoryTag_Tbl_Category");

            entity.HasOne(d => d.CtTag)
                .WithMany(p => p.TblCategoryTag)
                .HasForeignKey(d => d.CtTagGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_CategoryTag_Tbl_Tag");
        }
    }
}
