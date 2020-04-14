using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblPostCommentConfiguration : IEntityTypeConfiguration<TblPostComment>
    {
        public void Configure(EntityTypeBuilder<TblPostComment> entity)
        {
            entity.HasKey(e => e.PcGuid);

            entity.ToTable("Tbl_PostComment");

            entity.HasIndex(e => e.PcCommentGuid);

            entity.HasIndex(e => e.PcPostGuid);

            entity.Property(e => e.PcGuid)
                .HasColumnName("PC_Guid")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.PcIsAccept)
                .HasColumnName("PC_IsAccept")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.PcPostGuid)
                .HasColumnName("PC_PostGuid");

            entity.HasOne(d => d.PcComment)
                .WithMany(p => p.TblPostComment)
                .HasForeignKey(d => d.PcCommentGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_PostComment_Tbl_Comment");

            entity.HasOne(d => d.PcPost)
                .WithMany(p => p.TblPostComment)
                .HasForeignKey(d => d.PcPostGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_PostComment_Tbl_Post");
        }
    }
}
