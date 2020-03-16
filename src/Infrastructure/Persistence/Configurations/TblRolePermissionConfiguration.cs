using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblRolePermissionConfiguration : IEntityTypeConfiguration<TblRolePermission>
    {
        public void Configure(EntityTypeBuilder<TblRolePermission> entity)
        {
            entity.HasKey(e => e.RpId);

            entity.ToTable("Tbl_RolePermission");

            entity.HasIndex(e => e.RpPermissionId);

            entity.HasIndex(e => e.RpRoleId);

            entity.Property(e => e.RpId)
                .HasColumnName("RP_ID");

            entity.Property(e => e.RpCreateDate)
                .HasColumnName("RP_CreateDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.RpGuid)
                .HasColumnName("RP_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.RpIsActive)
                .IsRequired()
                .HasColumnName("RP_IsActive")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.RpIsDelete)
                .HasColumnName("RP_IsDelete")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.RpModifyDate)
                .HasColumnName("RP_ModifyDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.RpPermissionId)
                .HasColumnName("RP_PermissionID");

            entity.Property(e => e.RpRoleId)
                .HasColumnName("RP_RoleID");

            entity.HasOne(d => d.RpPermission)
                .WithMany(p => p.TblRolePermission)
                .HasForeignKey(d => d.RpPermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_RolePermission_Tbl_Permission");

            entity.HasOne(d => d.RpRole)
                .WithMany(p => p.TblRolePermission)
                .HasForeignKey(d => d.RpRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_RolePermission_Tbl_Role");
        }
    }
}
