using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblSmssettingConfiguration : IEntityTypeConfiguration<TblSmssetting>
    {
        public void Configure(EntityTypeBuilder<TblSmssetting> entity)
        {
            entity.HasKey(e => e.SsId);

            entity.ToTable("Tbl_SMSSetting");

            entity.HasIndex(e => e.SsSpcid);

            entity.Property(e => e.SsId)
                .HasColumnName("SS_ID");

            entity.Property(e => e.SsCreateDate)
                .HasColumnName("SS_CreateDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.SsGuid)
                .HasColumnName("SS_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.SsIsDelete)
                .HasColumnName("SS_IsDelete")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.SsModifyDate)
                .HasColumnName("SS_ModifyDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.SsName)
                .IsRequired()
                .HasColumnName("SS_Name")
                .HasMaxLength(50);

            entity.Property(e => e.SsSpcid)
                .HasColumnName("SS_SPCID");

            entity.HasOne(d => d.SsSpc)
                .WithMany(p => p.TblSmssetting)
                .HasForeignKey(d => d.SsSpcid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_SMSSetting_Tbl_SMSProviderConfiguration");
        }
    }
}
