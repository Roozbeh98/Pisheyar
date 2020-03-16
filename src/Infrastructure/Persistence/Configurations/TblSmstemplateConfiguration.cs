using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblSmstemplateConfiguration : IEntityTypeConfiguration<TblSmstemplate>
    {
        public void Configure(EntityTypeBuilder<TblSmstemplate> entity)
        {
            entity.HasKey(e => e.StId);

            entity.ToTable("Tbl_SMSTemplate");

            entity.HasIndex(e => e.StSsid);

            entity.Property(e => e.StId)
                .HasColumnName("ST_ID");

            entity.Property(e => e.StCreateDate)
                .HasColumnName("ST_CreateDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.StGuid)
                .HasColumnName("ST_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.StIsDelete)
                .HasColumnName("ST_IsDelete")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.StModifyDate)
                .HasColumnName("ST_ModifyDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.StName)
                .IsRequired()
                .HasColumnName("ST_Name")
                .HasMaxLength(128);

            entity.Property(e => e.StSsid)
                .HasColumnName("ST_SSID");

            entity.HasOne(d => d.StSs)
                .WithMany(p => p.TblSmstemplate)
                .HasForeignKey(d => d.StSsid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_SMSTemplate_Tbl_SMSSetting");
        }
    }
}
