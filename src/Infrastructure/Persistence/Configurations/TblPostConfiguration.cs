using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblPostConfiguration : IEntityTypeConfiguration<TblPost>
    {
        public void Configure(EntityTypeBuilder<TblPost> entity)
        {
            entity.HasKey(e => e.PostGuid);

            entity.ToTable("Tbl_Post");

            entity.HasIndex(e => e.PostUserId);

            entity.Property(e => e.PostAbstract)
                .IsRequired()
                .HasColumnName("Post_Abstract");

            entity.Property(e => e.PostCreateDate)
                .HasColumnName("Post_CreateDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.PostDescription)
                .IsRequired()
                .HasColumnName("Post_Description");

            entity.Property(e => e.PostDocumentGuid)
                .HasColumnName("Post_DocumentGuid");

            entity.Property(e => e.PostGuid)
                .HasColumnName("Post_Guid")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.PostIsDelete)
                .HasColumnName("Post_IsDelete")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.PostIsShow)
                .HasColumnName("Post_IsShow")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.PostLikeCount)
                .HasColumnName("Post_LikeCount")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.PostModifyDate)
                .HasColumnName("Post_ModifyDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.PostTitle)
                .IsRequired()
                .HasColumnName("Post_Title");

            entity.Property(e => e.PostUserId)
                .HasColumnName("Post_UserID");

            entity.Property(e => e.PostViewCount)
                .HasColumnName("Post_ViewCount")
                .HasDefaultValueSql("((0))");

            entity.HasOne(d => d.PostDocument)
                .WithMany(p => p.TblPost)
                .HasForeignKey(d => d.PostDocumentGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_Post_Tbl_Document");

            entity.HasOne(d => d.PostUser)
                .WithMany(p => p.TblPost)
                .HasForeignKey(d => d.PostUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_Post_Tbl_User");
        }
    }
}
