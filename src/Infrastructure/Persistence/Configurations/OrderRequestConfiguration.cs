using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class OrderRequestConfiguration : IEntityTypeConfiguration<OrderRequest>
    {
        public void Configure(EntityTypeBuilder<OrderRequest> entity)
        {
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

            entity.Property(e => e.IsAccept).HasDefaultValueSql("((0))");

            entity.Property(e => e.IsAllow).HasDefaultValueSql("((0))");

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.OrderRequestGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Contractor)
                .WithMany(p => p.OrderRequest)
                .HasForeignKey(d => d.ContractorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderRequest_Contractor");

            entity.HasOne(d => d.Order)
                .WithMany(p => p.OrderRequest)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderRequest_Order");
        }
    }
}
