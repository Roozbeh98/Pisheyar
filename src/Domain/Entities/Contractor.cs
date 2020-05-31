using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class Contractor
    {
        public Contractor()
        {
            ContractorCategory = new HashSet<ContractorCategory>();
            Order = new HashSet<Order>();
            OrderRequest = new HashSet<OrderRequest>();
            Payment = new HashSet<Payment>();
        }

        [Key]
        [Column("ContractorID")]
        public int ContractorId { get; set; }
        [Column("ContractorGUID")]
        public Guid ContractorGuid { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Column("BusinessTypeCodeID")]
        public int BusinessTypeCodeId { get; set; }
        [Column("CityID")]
        public int CityId { get; set; }
        [Required]
        [StringLength(128)]
        public string Latitude { get; set; }
        [Required]
        [StringLength(128)]
        public string Longitude { get; set; }
        public int Credit { get; set; }
        public double? AverageRate { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessTypeCodeId))]
        [InverseProperty(nameof(Code.Contractor))]
        public virtual Code BusinessTypeCode { get; set; }
        [ForeignKey(nameof(CityId))]
        [InverseProperty("Contractor")]
        public virtual City City { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Contractor")]
        public virtual User User { get; set; }
        [InverseProperty("Contractor")]
        public virtual ICollection<ContractorCategory> ContractorCategory { get; set; }
        [InverseProperty("Contractor")]
        public virtual ICollection<Order> Order { get; set; }
        [InverseProperty("Contractor")]
        public virtual ICollection<OrderRequest> OrderRequest { get; set; }
        [InverseProperty("Contractor")]
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
