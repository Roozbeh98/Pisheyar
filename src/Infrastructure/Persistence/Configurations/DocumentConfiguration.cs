using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> entity)
        {
            entity.HasIndex(e => e.TypeCodeId)
                    .HasName("IX_Tbl_Document_Document_TypeCodeID");

            entity.Property(e => e.DocumentGuid)
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.TypeCode)
                .WithMany(p => p.Document)
                .HasForeignKey(d => d.TypeCodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document_Code");
        }
    }
}
