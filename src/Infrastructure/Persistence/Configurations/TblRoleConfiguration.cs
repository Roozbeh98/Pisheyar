using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblRoleConfiguration : IEntityTypeConfiguration<TblRole>
    {
        public void Configure(EntityTypeBuilder<TblRole> entity)
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("Tbl_Role");

            entity.Property(e => e.RoleId)
                .HasColumnName("Role_ID");

            entity.Property(e => e.RoleCreateDate)
                .HasColumnName("Role_CreateDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.RoleDisplay)
                .IsRequired()
                .HasColumnName("Role_Display")
                .HasMaxLength(128);

            entity.Property(e => e.RoleGuid)
                .HasColumnName("Role_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.RoleIsDelete)
                .HasColumnName("Role_IsDelete")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.RoleModifyDate)
                .HasColumnName("Role_ModifyDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.RoleName)
                .IsRequired()
                .HasColumnName("Role_Name")
                .HasMaxLength(128);
        }
    }
}
