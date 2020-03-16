using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblSmsproviderNumberConfiguration : IEntityTypeConfiguration<TblSmsproviderNumber>
    {
        public void Configure(EntityTypeBuilder<TblSmsproviderNumber> entity)
        {
            entity.HasKey(e => e.SpnId);

            entity.ToTable("Tbl_SMSProviderNumber");

            entity.HasIndex(e => e.SpnSpcid);

            entity.Property(e => e.SpnId)
                .HasColumnName("SPN_ID");

            entity.Property(e => e.SpnCreateDate)
                .HasColumnName("SPN_CreateDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.SpnGuid)
                .HasColumnName("SPN_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.SpnIsDelete)
                .HasColumnName("SPN_IsDelete")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.SpnModifyDate)
                .HasColumnName("SPN_ModifyDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.SpnNumber)
                .IsRequired()
                .HasColumnName("SPN_Number")
                .HasMaxLength(128);

            entity.Property(e => e.SpnSpcid)
                .HasColumnName("SPN_SPCID");

            entity.HasOne(d => d.SpnSpc)
                .WithMany(p => p.TblSmsproviderNumber)
                .HasForeignKey(d => d.SpnSpcid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_SMSProviderNumber_Tbl_SMSProviderConfiguration");
        }
    }
}
