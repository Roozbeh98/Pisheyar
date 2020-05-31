using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> entity)
        {
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.TransactionGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.TypeCode)
                .WithMany(p => p.Transaction)
                .HasForeignKey(d => d.TypeCodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaction_Code");
        }
    }
}
