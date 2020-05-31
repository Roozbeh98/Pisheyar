using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class SmsProviderNumberConfiguration : IEntityTypeConfiguration<SmsProviderNumber>
    {
        public void Configure(EntityTypeBuilder<SmsProviderNumber> entity)
        {
            entity.HasIndex(e => e.SmsProviderConfigurationId)
                    .HasName("IX_Tbl_SMSProviderNumber_SPN_SPCID");

            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.SmsProviderNumberGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.SmsProviderConfiguration)
                .WithMany(p => p.SmsProviderNumber)
                .HasForeignKey(d => d.SmsProviderConfigurationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SMSProviderNumber_SMSProviderConfiguration");
        }
    }
}
