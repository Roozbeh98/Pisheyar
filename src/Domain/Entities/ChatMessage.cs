using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class ChatMessage
    {
        [Key]
        [Column("ChatMessageID")]
        public int ChatMessageId { get; set; }
        [Column("ChatMessageGUID")]
        public Guid ChatMessageGuid { get; set; }
        [Column("OrderRequestID")]
        public int OrderRequestId { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Required]
        public string Text { get; set; }
        public bool IsSeen { get; set; }
        public bool IsModified { get; set; }
        public bool IsDelete { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(OrderRequestId))]
        [InverseProperty("ChatMessage")]
        public virtual OrderRequest OrderRequest { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("ChatMessage")]
        public virtual User User { get; set; }
    }
}
