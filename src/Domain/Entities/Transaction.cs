using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class Transaction
    {
        [Key]
        [Column("TransactionID")]
        public int TransactionId { get; set; }
        [Column("TransactionGUID")]
        public Guid TransactionGuid { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Column("TypeCodeID")]
        public int TypeCodeId { get; set; }
        public long Cost { get; set; }
        [Required]
        [StringLength(128)]
        public string Serial { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(TypeCodeId))]
        [InverseProperty(nameof(Code.Transaction))]
        public virtual Code TypeCode { get; set; }
    }
}
