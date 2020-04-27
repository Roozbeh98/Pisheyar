using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class PostCategory
    {
        [Key]
        [Column("PostCategoryID")]
        public int PostCategoryId { get; set; }
        [Column("PostCategoryGUID")]
        public Guid PostCategoryGuid { get; set; }
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [Column("PostID")]
        public int PostId { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("PostCategory")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(PostId))]
        [InverseProperty("PostCategory")]
        public virtual Post Post { get; set; }
    }
}
