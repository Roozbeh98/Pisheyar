using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblSmsresponseConfiguration : IEntityTypeConfiguration<TblSmsresponse>
    {
        public void Configure(EntityTypeBuilder<TblSmsresponse> entity)
        {
            entity.HasKey(e => e.SmsId);

            entity.ToTable("Tbl_SMSResponse");

            entity.HasIndex(e => e.SmsStid);

            entity.HasIndex(e => e.SmsUserGuid);

            entity.Property(e => e.SmsId)
                .HasColumnName("SMS_ID");

            entity.Property(e => e.SmsCost)
                .HasColumnName("SMS_Cost");

            entity.Property(e => e.SmsCreateDate)
                .HasColumnName("SMS_CreateDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.SmsDate)
                .HasColumnName("SMS_Date")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.SmsGuid)
                .HasColumnName("SMS_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.SmsIsDelete)
                .HasColumnName("SMS_IsDelete")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.SmsMessage)
                .IsRequired()
                .HasColumnName("SMS_Message");

            entity.Property(e => e.SmsModifyDate)
                .HasColumnName("SMS_ModifyDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.SmsReceptor)
                .IsRequired()
                .HasColumnName("SMS_Receptor")
                .HasMaxLength(128);

            entity.Property(e => e.SmsSender)
                .IsRequired()
                .HasColumnName("SMS_Sender")
                .HasMaxLength(128);

            entity.Property(e => e.SmsStatus)
                .HasColumnName("SMS_Status");

            entity.Property(e => e.SmsStatusText)
                .IsRequired()
                .HasColumnName("SMS_StatusText");

            entity.Property(e => e.SmsStid)
                .HasColumnName("SMS_STID");

            entity.Property(e => e.SmsToken)
                .HasColumnName("SMS_Token")
                .HasMaxLength(128);

            entity.Property(e => e.SmsToken1)
                .HasColumnName("SMS_Token1")
                .HasMaxLength(128);

            entity.Property(e => e.SmsToken2)
                .HasColumnName("SMS_Token2")
                .HasMaxLength(128);

            entity.Property(e => e.SmsUserGuid)
                .HasColumnName("SMS_UserGuid");

            entity.HasOne(d => d.SmsSt)
                .WithMany(p => p.TblSmsresponse)
                .HasForeignKey(d => d.SmsStid)
                .HasConstraintName("FK_Tbl_SMSResponse_Tbl_SMSTemplate");

            entity.HasOne(d => d.SmsUser)
                .WithMany(p => p.TblSmsresponse)
                .HasForeignKey(d => d.SmsUserGuid)
                .HasConstraintName("FK_Tbl_SMSResponse_Tbl_User");
        }
    }
}
