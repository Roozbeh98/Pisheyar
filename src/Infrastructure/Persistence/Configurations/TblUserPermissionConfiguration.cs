using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblUserPermissionConfiguration : IEntityTypeConfiguration<TblUserPermission>
    {
        public void Configure(EntityTypeBuilder<TblUserPermission> entity)
        {
            entity.HasKey(e => e.UpId);

            entity.ToTable("Tbl_UserPermission");

            entity.HasIndex(e => e.UpPermissionId);

            entity.HasIndex(e => e.UpUserGuid);

            entity.Property(e => e.UpId)
                .HasColumnName("UP_ID");

            entity.Property(e => e.UpCreateDate)
                .HasColumnName("UP_CreateDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.UpGuid)
                .HasColumnName("UP_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.UpIsActive)
                .IsRequired()
                .HasColumnName("UP_IsActive")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.UpIsDelete)
                .HasColumnName("UP_IsDelete")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.UpModifyDate)
                .HasColumnName("UP_ModifyDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.UpPermissionId)
                .HasColumnName("UP_PermissionID");

            entity.Property(e => e.UpUserGuid)
                .HasColumnName("UP_UserGuid");

            entity.HasOne(d => d.UpPermission)
                .WithMany(p => p.TblUserPermission)
                .HasForeignKey(d => d.UpPermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_UserPermission_Tbl_Permission");

            entity.HasOne(d => d.UpUser)
                .WithMany(p => p.TblUserPermission)
                .HasForeignKey(d => d.UpUserGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_UserPermission_Tbl_User");
        }
    }
}
