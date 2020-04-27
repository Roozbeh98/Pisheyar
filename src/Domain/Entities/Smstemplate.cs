using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    [Table("SMSTemplate")]
    public partial class SmsTemplate
    {
        public SmsTemplate()
        {
            SmsResponse = new HashSet<SmsResponse>();
        }

        [Key]
        [Column("SMSTemplateID")]
        public int SmsTemplateId { get; set; }
        [Column("SMSTemplateGUID")]
        public Guid SmsTemplateGuid { get; set; }
        [Column("SMSSettingID")]
        public int SmsSettingId { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(SmsSettingId))]
        [InverseProperty("SmsTemplate")]
        public virtual SmsSetting SmsSetting { get; set; }
        [InverseProperty("SmsTemplate")]
        public virtual ICollection<SmsResponse> SmsResponse { get; set; }
    }
}
