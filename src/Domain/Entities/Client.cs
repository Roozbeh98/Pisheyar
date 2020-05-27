using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class Client
    {
        public Client()
        {
            Order = new HashSet<Order>();
        }

        [Key]
        [Column("ClientID")]
        public int ClientId { get; set; }
        [Column("ClientGUID")]
        public Guid ClientGuid { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Column("CityID")]
        public int CityId { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Client")]
        public virtual City City { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Client")]
        public virtual User User { get; set; }
        [InverseProperty("Client")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
