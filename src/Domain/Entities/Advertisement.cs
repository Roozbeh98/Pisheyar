using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class Advertisement
    {
        [Key]
        [Column("AdvertisementID")]
        public int AdvertisementId { get; set; }
        [Column("AdvertisementGUID")]
        public Guid AdvertisementGuid { get; set; }
        [Column("DocumentID")]
        public int DocumentId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsShow { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(DocumentId))]
        [InverseProperty("Advertisement")]
        public virtual Document Document { get; set; }
    }
}
