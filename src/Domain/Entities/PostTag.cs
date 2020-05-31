using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class PostTag
    {
        [Key]
        [Column("PostTagID")]
        public int PostTagId { get; set; }
        [Column("PostTagGUID")]
        public Guid PostTagGuid { get; set; }
        [Column("PostID")]
        public int PostId { get; set; }
        [Column("TagID")]
        public int TagId { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(PostId))]
        [InverseProperty("PostTag")]
        public virtual Post Post { get; set; }
        [ForeignKey(nameof(TagId))]
        [InverseProperty("PostTag")]
        public virtual Tag Tag { get; set; }
    }
}
