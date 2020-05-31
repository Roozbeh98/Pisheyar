using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    [Table("SMSProviderConfiguration")]
    public partial class SmsProviderConfiguration
    {
        public SmsProviderConfiguration()
        {
            SmsProviderNumber = new HashSet<SmsProviderNumber>();
            SmsSetting = new HashSet<SmsSetting>();
        }

        [Key]
        [Column("SMSProviderConfigurationID")]
        public int SmsProviderConfigurationId { get; set; }
        [Column("SMSProviderConfigurationGUID")]
        public Guid SmsProviderConfigurationGuid { get; set; }
        [Required]
        [StringLength(128)]
        public string Username { get; set; }
        [Required]
        [StringLength(128)]
        public string Password { get; set; }
        [Required]
        [Column("APIKey")]
        [StringLength(128)]
        public string Apikey { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("SmsProviderConfiguration")]
        public virtual ICollection<SmsProviderNumber> SmsProviderNumber { get; set; }
        [InverseProperty("SmsProviderConfiguration")]
        public virtual ICollection<SmsSetting> SmsSetting { get; set; }
    }
}
