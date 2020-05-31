using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderRequest = new HashSet<OrderRequest>();
        }

        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("OrderGUID")]
        public Guid OrderGuid { get; set; }
        [Column("ClientID")]
        public int ClientId { get; set; }
        [Column("ContractorID")]
        public int? ContractorId { get; set; }
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [Column("StateCodeID")]
        public int StateCodeId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Comment { get; set; }
        public double? Rate { get; set; }
        public int? Cost { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Order")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(ClientId))]
        [InverseProperty("Order")]
        public virtual Client Client { get; set; }
        [ForeignKey(nameof(ContractorId))]
        [InverseProperty("Order")]
        public virtual Contractor Contractor { get; set; }
        [ForeignKey(nameof(StateCodeId))]
        [InverseProperty(nameof(Code.Order))]
        public virtual Code StateCode { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderRequest> OrderRequest { get; set; }
    }
}
