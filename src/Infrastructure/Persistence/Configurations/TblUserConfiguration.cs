using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblUserConfiguration : IEntityTypeConfiguration<TblUser>
    {
        public void Configure(EntityTypeBuilder<TblUser> entity)
        {
            entity.HasKey(e => e.UserGuid);

            entity.ToTable("Tbl_User");

            entity.HasIndex(e => e.UserRoleId);

            entity.Property(e => e.UserCreateDate)
                .HasColumnName("User_CreateDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.UserEmail)
                .IsRequired()
                .HasColumnName("User_Email")
                .HasMaxLength(256);

            entity.Property(e => e.UserFamily)
                .IsRequired()
                .HasColumnName("User_Family")
                .HasMaxLength(128);

            entity.Property(e => e.UserGuid)
                .HasColumnName("User_Guid")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.UserIsActive)
                .HasColumnName("User_IsActive")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.UserIsDelete)
                .HasColumnName("User_IsDelete")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.UserMobile)
                .IsRequired()
                .HasColumnName("User_Mobile")
                .HasMaxLength(11)
                .IsUnicode(false);

            entity.Property(e => e.UserModifyDate)
                .HasColumnName("User_ModifyDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.UserName)
                .IsRequired()
                .HasColumnName("User_Name")
                .HasMaxLength(128);

            entity.Property(e => e.UserRoleId)
                .HasColumnName("User_RoleID");

            entity.HasOne(d => d.UserRole)
                .WithMany(p => p.TblUser)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_User_Tbl_Role");
        }
    }
}
