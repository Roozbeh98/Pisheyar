using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblChatMessageConfiguration : IEntityTypeConfiguration<TblChatMessage>
    {
        public void Configure(EntityTypeBuilder<TblChatMessage> entity)
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("Tbl_ChatMessage");

            entity.HasIndex(e => e.ChatRoomGuid);

            entity.Property(e => e.Guid)
                //.HasColumnName("Guid")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.Text)
                .IsRequired();
            //.HasColumnName("Text")

            entity.Property(e => e.IsSeen)
                //.HasColumnName("IsSeen")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.IsModified)
                //.HasColumnName("IsModified")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.IsDelete)
                //.HasColumnName("IsDelete")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.SentDate)
                //.HasColumnName("CreationDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.ModifiedDate)
                //.HasColumnName("ModifiedDate")
                .HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.TblChatRoom)
                .WithMany(p => p.TblChatMessage)
                .HasForeignKey(d => d.ChatRoomGuid)
                .OnDelete(DeleteBehavior.ClientSetNull);
                //.HasConstraintName("FK_Tbl_ChatMessage_Tbl_ChatRoom");
        }
    }
}
