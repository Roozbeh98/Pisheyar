using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    [Table("SMSSetting")]
    public partial class SmsSetting
    {
        public SmsSetting()
        {
            SmsTemplate = new HashSet<SmsTemplate>();
        }

        [Key]
        [Column("SMSSettingID")]
        public int SmsSettingId { get; set; }
        [Column("SMSSettingGUID")]
        public Guid SmsSettingGuid { get; set; }
        [Column("SMSProviderConfigurationID")]
        public int SmsProviderConfigurationId { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(SmsProviderConfigurationId))]
        [InverseProperty("SmsSetting")]
        public virtual SmsProviderConfiguration SmsProviderConfiguration { get; set; }
        [InverseProperty("SmsSetting")]
        public virtual ICollection<SmsTemplate> SmsTemplate { get; set; }
    }
}
