using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class ChatRoom
    {
        public ChatRoom()
        {
            ChatMessage = new HashSet<ChatMessage>();
        }

        [Key]
        [Column("ChatRoomID")]
        public int ChatRoomId { get; set; }
        [Column("ChatRoomGUID")]
        public Guid ChatRoomGuid { get; set; }
        [Column("ContractorID")]
        public int ContractorId { get; set; }
        [Column("ClientID")]
        public int ClientId { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Required]
        [Column("OwnerConnectionID")]
        [StringLength(128)]
        public string OwnerConnectionId { get; set; }
        [StringLength(128)]
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty("ChatRoom")]
        public virtual Client Client { get; set; }
        [ForeignKey(nameof(ContractorId))]
        [InverseProperty("ChatRoom")]
        public virtual Contractor Contractor { get; set; }
        [ForeignKey(nameof(OrderId))]
        [InverseProperty("ChatRoom")]
        public virtual Order Order { get; set; }
        [InverseProperty("ChatRoom")]
        public virtual ICollection<ChatMessage> ChatMessage { get; set; }
    }
}
