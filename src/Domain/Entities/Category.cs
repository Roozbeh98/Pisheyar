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
            ContractorCategory = new HashSet<ContractorCategory>();
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
        [Column("CoverDocumentID")]
        public int? CoverDocumentId { get; set; }
        [Column("ActiveIconDocumentID")]
        public int? ActiveIconDocumentId { get; set; }
        [Column("InactiveIconDocumentID")]
        public int? InactiveIconDocumentId { get; set; }
        [Column("QuadMenuDocumentID")]
        public int? QuadMenuDocumentId { get; set; }
        [Required]
        [StringLength(128)]
        public string DisplayName { get; set; }
        public string Abstract { get; set; }
        public string Description { get; set; }
        public int Sort { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(ActiveIconDocumentId))]
        [InverseProperty(nameof(Document.CategoryActiveIconDocument))]
        public virtual Document ActiveIconDocument { get; set; }
        [ForeignKey(nameof(CoverDocumentId))]
        [InverseProperty(nameof(Document.CategoryCoverDocument))]
        public virtual Document CoverDocument { get; set; }
        [ForeignKey(nameof(InactiveIconDocumentId))]
        [InverseProperty(nameof(Document.CategoryInactiveIconDocument))]
        public virtual Document InactiveIconDocument { get; set; }
        [ForeignKey(nameof(ParentCategoryId))]
        [InverseProperty(nameof(Category.InverseParentCategory))]
        public virtual Category ParentCategory { get; set; }
        [ForeignKey(nameof(QuadMenuDocumentId))]
        [InverseProperty(nameof(Document.CategoryQuadMenuDocument))]
        public virtual Document QuadMenuDocument { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<CategoryTag> CategoryTag { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<ContractorCategory> ContractorCategory { get; set; }
        [InverseProperty(nameof(Category.ParentCategory))]
        public virtual ICollection<Category> InverseParentCategory { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<Order> Order { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<PostCategory> PostCategory { get; set; }
    }
}
