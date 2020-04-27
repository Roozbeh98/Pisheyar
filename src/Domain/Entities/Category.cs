using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class Category
    {
        public Category()
        {
            CategoryTag = new HashSet<CategoryTag>();
            InverseParentCategory = new HashSet<Category>();
            Order = new HashSet<Order>();
            PostCategory = new HashSet<PostCategory>();
        }

        [Key]
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [Column("CategoryGUID")]
        public Guid CategoryGuid { get; set; }
        [Column("ParentCategoryID")]
        public int? ParentCategoryId { get; set; }
        [Required]
        [StringLength(128)]
        public string DisplayName { get; set; }
        public int Sort { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(ParentCategoryId))]
        [InverseProperty(nameof(Category.InverseParentCategory))]
        public virtual Category ParentCategory { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<CategoryTag> CategoryTag { get; set; }
        [InverseProperty(nameof(Category.ParentCategory))]
        public virtual ICollection<Category> InverseParentCategory { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<Order> Order { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<PostCategory> PostCategory { get; set; }
    }
}
