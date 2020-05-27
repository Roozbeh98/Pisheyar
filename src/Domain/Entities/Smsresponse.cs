using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    [Table("SMSResponse")]
    public partial class SmsResponse
    {
        [Key]
        [Column("SMSResponseID")]
        public int SmsResponseId { get; set; }
        [Column("SMSResponseGUID")]
        public Guid SmsResponseGuid { get; set; }
        [Column("SMSTemplateID")]
        public int? SmsTemplateId { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        public int Status { get; set; }
        [Required]
        public string StatusText { get; set; }
        [Required]
        [StringLength(128)]
        public string Sender { get; set; }
        [Required]
        [StringLength(128)]
        public string Receptor { get; set; }
        [StringLength(128)]
        public string Token { get; set; }
        [StringLength(128)]
        public string Token1 { get; set; }
        [StringLength(128)]
        public string Token2 { get; set; }
        [Required]
        public string Message { get; set; }
        public long Cost { get; set; }
        public bool IsDelete { get; set; }
        public DateTime SentDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(SmsTemplateId))]
        [InverseProperty("SmsResponse")]
        public virtual SmsTemplate SmsTemplate { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("SmsResponse")]
        public virtual User User { get; set; }
    }
}
