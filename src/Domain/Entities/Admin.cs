using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class Admin
    {
        [Key]
        [Column("AdminID")]
        public int AdminId { get; set; }
        [Column("AdminGUID")]
        public Guid AdminGuid { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Admin")]
        public virtual User User { get; set; }
    }
}
