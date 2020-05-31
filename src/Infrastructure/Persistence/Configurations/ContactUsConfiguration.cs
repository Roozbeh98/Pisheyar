using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class ContactUsConfiguration : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> entity)
        {
            entity.Property(e => e.ContactUsGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.ContactUsBusinessTypeCode)
                .WithMany(p => p.ContactUs)
                .HasForeignKey(d => d.ContactUsBusinessTypeCodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactUs_Code");
        }
    }
}
