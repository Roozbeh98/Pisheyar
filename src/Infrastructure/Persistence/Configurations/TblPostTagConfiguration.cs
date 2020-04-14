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
            entity.HasKey(e => e.PtGuid);

            entity.ToTable("Tbl_PostTag");

            entity.HasIndex(e => e.PtPostGuid);

            entity.HasIndex(e => e.PtTagGuid);

            entity.Property(e => e.PtGuid)
                .HasColumnName("PT_Guid")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.PtPostGuid)
                .HasColumnName("PT_PostGuid");

            entity.Property(e => e.PtTagGuid)
                .HasColumnName("PT_TagGuid");

            entity.HasOne(d => d.PtPost)
                .WithMany(p => p.TblPostTag)
                .HasForeignKey(d => d.PtPostGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_PostTag_Tbl_Post");

            entity.HasOne(d => d.PtTag)
                .WithMany(p => p.TblPostTag)
                .HasForeignKey(d => d.PtTagGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_PostTag_Tbl_Tag");
        }
    }
}
