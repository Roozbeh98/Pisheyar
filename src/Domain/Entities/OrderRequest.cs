using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class OrderRequest
    {
        [Key]
        [Column("OrderRequestID")]
        public int OrderRequestId { get; set; }
        [Column("OrderRequestGUID")]
        public Guid OrderRequestGuid { get; set; }
        [Column("ContractorID")]
        public int ContractorId { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Required]
        public string Message { get; set; }
        public bool IsAccept { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(ContractorId))]
        [InverseProperty("OrderRequest")]
        public virtual Contractor Contractor { get; set; }
        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderRequest")]
        public virtual Order Order { get; set; }
    }
}
