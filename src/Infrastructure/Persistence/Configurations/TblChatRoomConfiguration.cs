using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblChatRoomConfiguration : IEntityTypeConfiguration<TblChatRoom>
    {
        public void Configure(EntityTypeBuilder<TblChatRoom> entity)
        {
            entity.HasKey(e => e.Guid);

            entity.ToTable("Tbl_ChatRoom");

            entity.HasIndex(e => e.UserGuid);

            entity.Property(e => e.Guid)
                //.HasColumnName("Guid")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.OwnerConnectionId)
                .IsRequired()
                //.HasColumnName("OwnerConnectionId")
                .HasMaxLength(450);

            entity.Property(e => e.Name)
                //.IsRequired()
                //.HasColumnName("Name")
                .HasMaxLength(450);

            entity.Property(e => e.IsDelete)
                //.HasColumnName("IsDelete")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.CreationDate)
                //.HasColumnName("CreationDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.ModifiedDate)
                //.HasColumnName("ModifiedDate")
                .HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.TblUser)
                .WithMany(p => p.TblChatRoom)
                .HasForeignKey(d => d.UserGuid)
                .OnDelete(DeleteBehavior.ClientSetNull);
                //.HasConstraintName("FK_Tbl_ChatRoom_Tbl_User");
        }
    }
}
