using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    [Table("SMSProviderNumber")]
    public partial class SmsProviderNumber
    {
        [Key]
        [Column("SMSProviderNumberID")]
        public int SmsProviderNumberId { get; set; }
        [Column("SMSProviderNumberGUID")]
        public Guid SmsProviderNumberGuid { get; set; }
        [Column("SMSProviderConfigurationID")]
        public int SmsProviderConfigurationId { get; set; }
        [Required]
        [StringLength(128)]
        public string Value { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(SmsProviderConfigurationId))]
        [InverseProperty("SmsProviderNumber")]
        public virtual SmsProviderConfiguration SmsProviderConfiguration { get; set; }
    }
}
