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
            entity.HasKey(e => e.PcId);

            entity.ToTable("Tbl_PostComment");

            entity.HasIndex(e => e.PcCommentId);

            entity.HasIndex(e => e.PcPostId);

            entity.Property(e => e.PcId)
                .HasColumnName("PC_ID");

            entity.Property(e => e.PcCommentId)
                .HasColumnName("PC_CommentID");

            entity.Property(e => e.PcGuid)
                .HasColumnName("PC_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.PcIsAccept)
                .HasColumnName("PC_IsAccept")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.PcPostId)
                .HasColumnName("PC_PostID");

            entity.HasOne(d => d.PcComment)
                .WithMany(p => p.TblPostComment)
                .HasForeignKey(d => d.PcCommentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_PostComment_Tbl_Comment");

            entity.HasOne(d => d.PcPost)
                .WithMany(p => p.TblPostComment)
                .HasForeignKey(d => d.PcPostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_PostComment_Tbl_Post");
        }
    }
}
