using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class Token
    {
        [Key]
        [Column("TokenID")]
        public int TokenId { get; set; }
        [Column("TokenGUID")]
        public Guid TokenGuid { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Column("RoleCodeID")]
        public int RoleCodeId { get; set; }
        public int Value { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(RoleCodeId))]
        [InverseProperty(nameof(Code.Token))]
        public virtual Code RoleCode { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Token")]
        public virtual User User { get; set; }
    }
}
