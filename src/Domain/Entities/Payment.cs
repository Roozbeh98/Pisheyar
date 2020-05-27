using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class Payment
    {
        [Key]
        [Column("PaymentID")]
        public int PaymentId { get; set; }
        [Column("PaymentGUID")]
        public Guid PaymentGuid { get; set; }
        [Column("ContractorID")]
        public int ContractorId { get; set; }
        public int Cost { get; set; }
        public int Discount { get; set; }
        public long? TrackingToken { get; set; }
        public bool IsSuccessful { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(ContractorId))]
        [InverseProperty("Payment")]
        public virtual Contractor Contractor { get; set; }
    }
}
