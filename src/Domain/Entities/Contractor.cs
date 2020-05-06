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
            ChatRoom = new HashSet<ChatRoom>();
            ContractorCategory = new HashSet<ContractorCategory>();
            Order = new HashSet<Order>();
            OrderRequest = new HashSet<OrderRequest>();
        }

        [Key]
        [Column("ContractorID")]
        public int ContractorId { get; set; }
        [Column("ContractorGUID")]
        public Guid ContractorGuid { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Column("CityID")]
        public int CityId { get; set; }
        public long Credit { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Contractor")]
        public virtual City City { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Contractor")]
        public virtual User User { get; set; }
        [InverseProperty("Contractor")]
        public virtual ICollection<ChatRoom> ChatRoom { get; set; }
        [InverseProperty("Contractor")]
        public virtual ICollection<ContractorCategory> ContractorCategory { get; set; }
        [InverseProperty("Contractor")]
        public virtual ICollection<Order> Order { get; set; }
        [InverseProperty("Contractor")]
        public virtual ICollection<OrderRequest> OrderRequest { get; set; }
    }
}
