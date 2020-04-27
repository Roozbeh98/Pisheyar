using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class SmsResponseConfiguration : IEntityTypeConfiguration<SmsResponse>
    {
        public void Configure(EntityTypeBuilder<SmsResponse> entity)
        {
            entity.HasIndex(e => e.SmsTemplateId)
                    .HasName("IX_Tbl_SMSResponse_SMS_STID");

            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.SentDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.SmsResponseGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.SmsTemplate)
                .WithMany(p => p.SmsResponse)
                .HasForeignKey(d => d.SmsTemplateId)
                .HasConstraintName("FK_SMSResponse_SMSTemplate");

            entity.HasOne(d => d.User)
                .WithMany(p => p.SmsResponse)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SMSResponse_User");
        }
    }
}
