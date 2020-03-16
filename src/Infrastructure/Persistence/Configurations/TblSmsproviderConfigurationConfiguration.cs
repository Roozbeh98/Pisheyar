using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblSmsproviderConfigurationConfiguration : IEntityTypeConfiguration<TblSmsproviderConfiguration>
    {
        public void Configure(EntityTypeBuilder<TblSmsproviderConfiguration> entity)
        {
            entity.HasKey(e => e.SpcId);

            entity.ToTable("Tbl_SMSProviderConfiguration");

            entity.Property(e => e.SpcId)
                .HasColumnName("SPC_ID");

            entity.Property(e => e.SpcApiKey)
                .IsRequired()
                .HasColumnName("SPC_ApiKey")
                .HasMaxLength(128);

            entity.Property(e => e.SpcCreateDate)
                .HasColumnName("SPC_CreateDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.SpcGuid)
                .HasColumnName("SPC_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.SpcIsDelete)
                .HasColumnName("SPC_IsDelete")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.SpcModifyDate)
                .HasColumnName("SPC_ModifyDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.SpcPassword)
                .IsRequired()
                .HasColumnName("SPC_Password")
                .HasMaxLength(128);

            entity.Property(e => e.SpcUsername)
                .IsRequired()
                .HasColumnName("SPC_Username")
                .HasMaxLength(128);
        }
    }
}
