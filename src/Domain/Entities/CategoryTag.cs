using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class CategoryTag
    {
        [Key]
        [Column("CategoryTagID")]
        public int CategoryTagId { get; set; }
        [Column("CategoryTagGUID")]
        public Guid CategoryTagGuid { get; set; }
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [Column("TagID")]
        public int TagId { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("CategoryTag")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(TagId))]
        [InverseProperty("CategoryTag")]
        public virtual Tag Tag { get; set; }
    }
}
