using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblCommentConfiguration : IEntityTypeConfiguration<TblComment>
    {
        public void Configure(EntityTypeBuilder<TblComment> entity)
        {
            entity.HasKey(e => e.CommentGuid);

            entity.ToTable("Tbl_Comment");

            entity.HasIndex(e => e.CommentUserId);

            entity.Property(e => e.CommentDate)
                .HasColumnName("Comment_Date")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.CommentGuid)
                .HasColumnName("Comment_Guid")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.CommentText)
                .IsRequired()
                .HasColumnName("Comment_Text");

            entity.Property(e => e.CommentUserId)
                .HasColumnName("Comment_UserID");

            entity.HasOne(d => d.CommentUser)
                .WithMany(p => p.TblComment)
                .HasForeignKey(d => d.CommentUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_Comment_Tbl_User");
        }
    }
}
