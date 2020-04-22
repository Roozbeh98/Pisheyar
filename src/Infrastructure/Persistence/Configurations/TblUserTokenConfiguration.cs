using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Infrastructure.Persistence.Configurations
{
    public class TblUserTokenConfiguration : IEntityTypeConfiguration<TblUserToken>
    {
        public void Configure(EntityTypeBuilder<TblUserToken> entity)
        {
            entity.HasKey(e => e.UtId);

            entity.ToTable("Tbl_UserToken");

            entity.HasIndex(e => e.UtUserGuid);

            entity.Property(e => e.UtId)
                .HasColumnName("UT_ID");

            entity.Property(e => e.UtExpireDate)
                .HasColumnName("UT_ExpireDate")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.UtGuid)
                .HasColumnName("UT_Guid")
                .HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.UtToken)
                .HasColumnName("UT_Token");

            entity.Property(e => e.UtUserGuid)
                .HasColumnName("UT_UserGuid");

            entity.HasOne(d => d.UtUser)
                .WithMany(p => p.TblUserToken)
                .HasForeignKey(d => d.UtUserGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_UserToken_Tbl_User");
        }
    }
}
