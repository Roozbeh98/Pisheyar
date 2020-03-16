using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblDocumentConfiguration : IEntityTypeConfiguration<TblDocument>
    {
        public void Configure(EntityTypeBuilder<TblDocument> entity)
        {
            entity.HasKey(e => e.DocumentId);

            entity.ToTable("Tbl_Document");

            entity.Property(e => e.DocumentId)
                .HasColumnName("Document_ID");

            entity.Property(e => e.DocumentCreateDate)
                .HasColumnName("Document_CreateDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.DocumentFileName)
                .IsRequired()
                .HasColumnName("Document_FileName")
                .HasMaxLength(128);

            entity.Property(e => e.DocumentGuid)
                .HasColumnName("Document_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.DocumentIsDelete)
                .HasColumnName("Document_IsDelete");

            entity.Property(e => e.DocumentModifyDate)
                .HasColumnName("Document_ModifyDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.DocumentPath)
                .IsRequired()
                .HasColumnName("Document_Path")
                .HasMaxLength(512);

            entity.Property(e => e.DocumentTypeCodeId)
                .HasColumnName("Document_TypeCodeID");

            entity.HasOne(d => d.DocumentTypeCode)
                .WithMany(p => p.TblDocument)
                .HasForeignKey(d => d.DocumentTypeCodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_Document_Tbl_Code");
        }
    }
}
