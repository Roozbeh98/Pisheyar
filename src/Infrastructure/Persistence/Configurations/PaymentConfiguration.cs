using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> entity)
        {
            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.IsSuccessful).HasDefaultValueSql("((0))");

            entity.Property(e => e.PaymentGuid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Contractor)
                .WithMany(p => p.Payment)
                .HasForeignKey(d => d.ContractorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Contractor");
        }
    }
}
