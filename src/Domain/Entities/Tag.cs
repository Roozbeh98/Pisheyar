using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class Tag
    {
        public Tag()
        {
            CategoryTag = new HashSet<CategoryTag>();
            PostTag = new HashSet<PostTag>();
        }

        [Key]
        [Column("TagID")]
        public int TagId { get; set; }
        [Column("TagGUID")]
        public Guid TagGuid { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public int Usage { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("Tag")]
        public virtual ICollection<CategoryTag> CategoryTag { get; set; }
        [InverseProperty("Tag")]
        public virtual ICollection<PostTag> PostTag { get; set; }
    }
}
