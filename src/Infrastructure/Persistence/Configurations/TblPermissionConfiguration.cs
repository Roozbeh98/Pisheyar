using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblPermissionConfiguration : IEntityTypeConfiguration<TblPermission>
    {
        public void Configure(EntityTypeBuilder<TblPermission> entity)
        {
            entity.HasKey(e => e.PermissionId);

            entity.ToTable("Tbl_Permission");

            entity.Property(e => e.PermissionId)
                .HasColumnName("Permission_ID");

            entity.Property(e => e.PermissionCreateDate)
                .HasColumnName("Permission_CreateDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.PermissionDisplay)
                .IsRequired()
                .HasColumnName("Permission_Display")
                .HasMaxLength(128);

            entity.Property(e => e.PermissionGuid)
                .HasColumnName("Permission_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.PermissionIsActive)
                .IsRequired()
                .HasColumnName("Permission_IsActive")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.PermissionIsDelete)
                .HasColumnName("Permission_IsDelete")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.PermissionModifyDate)
                .HasColumnName("Permission_ModifyDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.PermissionName)
                .IsRequired()
                .HasColumnName("Permission_Name")
                .HasMaxLength(128);
        }
    }
}
