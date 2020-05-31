using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.OrderGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Category)
                .WithMany(p => p.Order)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Category");

            entity.HasOne(d => d.Client)
                .WithMany(p => p.Order)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Client");

            entity.HasOne(d => d.Contractor)
                .WithMany(p => p.Order)
                .HasForeignKey(d => d.ContractorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Contractor");

            entity.HasOne(d => d.StateCode)
                .WithMany(p => p.Order)
                .HasForeignKey(d => d.StateCodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Code");
        }
    }
}
