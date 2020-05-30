using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class ContactUs
    {
        [Key]
        [Column("ContactUsID")]
        public int ContactUsId { get; set; }
        [Column("ContactUsGUID")]
        public Guid ContactUsGuid { get; set; }
        [Column("ContactUsBusinessTypeCodeID")]
        public int ContactUsBusinessTypeCodeId { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        [StringLength(128)]
        public string Email { get; set; }
        [Required]
        [StringLength(128)]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(ContactUsBusinessTypeCodeId))]
        [InverseProperty(nameof(Code.ContactUs))]
        public virtual Code ContactUsBusinessTypeCode { get; set; }
    }
}
