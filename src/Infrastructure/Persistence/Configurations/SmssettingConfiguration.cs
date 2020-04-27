using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class SmsSettingConfiguration : IEntityTypeConfiguration<SmsSetting>
    {
        public void Configure(EntityTypeBuilder<SmsSetting> entity)
        {
            entity.HasIndex(e => e.SmsProviderConfigurationId)
                    .HasName("IX_Tbl_SMSSetting_SS_SPCID");

            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.SmsSettingGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.SmsProviderConfiguration)
                .WithMany(p => p.SmsSetting)
                .HasForeignKey(d => d.SmsProviderConfigurationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SMSSetting_SMSProviderConfiguration");
        }
    }
}
