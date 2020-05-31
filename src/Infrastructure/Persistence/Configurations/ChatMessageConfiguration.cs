using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> entity)
        {
            entity.Property(e => e.ChatMessageGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

            entity.Property(e => e.IsModified).HasDefaultValueSql("((0))");

            entity.Property(e => e.IsSeen).HasDefaultValueSql("((0))");

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.SentAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.OrderRequest)
                .WithMany(p => p.ChatMessage)
                .HasForeignKey(d => d.OrderRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChatMessage_OrderRequest");

            entity.HasOne(d => d.User)
                    .WithMany(p => p.ChatMessage)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChatMessage_User");
        }
    }
}
