using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblPostTagConfiguration : IEntityTypeConfiguration<TblPostTag>
    {
        public void Configure(EntityTypeBuilder<TblPostTag> entity)
        {
            entity.HasKey(e => e.PtId);

            entity.ToTable("Tbl_PostTag");

            entity.HasIndex(e => e.PtPostId);

            entity.HasIndex(e => e.PtTagId);

            entity.Property(e => e.PtId)
                .HasColumnName("PT_ID");

            entity.Property(e => e.PtGuid)
                .HasColumnName("PT_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.PtPostId)
                .HasColumnName("PT_PostID");

            entity.Property(e => e.PtTagId)
                .HasColumnName("PT_TagID");

            entity.HasOne(d => d.PtPost)
                .WithMany(p => p.TblPostTag)
                .HasForeignKey(d => d.PtPostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_PostTag_Tbl_Post");

            entity.HasOne(d => d.PtTag)
                .WithMany(p => p.TblPostTag)
                .HasForeignKey(d => d.PtTagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_PostTag_Tbl_Tag");
        }
    }
}
