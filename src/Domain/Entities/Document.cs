using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class Document
    {
        public Document()
        {
            Advertisement = new HashSet<Advertisement>();
            CategoryActiveIconDocument = new HashSet<Category>();
            CategoryCoverDocument = new HashSet<Category>();
            CategoryInactiveIconDocument = new HashSet<Category>();
            CategoryQuadMenuDocument = new HashSet<Category>();
            Post = new HashSet<Post>();
            User = new HashSet<User>();
        }

        [Key]
        [Column("DocumentID")]
        public int DocumentId { get; set; }
        [Column("DocumentGUID")]
        public Guid DocumentGuid { get; set; }
        [Column("TypeCodeID")]
        public int TypeCodeId { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public long Size { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(TypeCodeId))]
        [InverseProperty(nameof(Code.Document))]
        public virtual Code TypeCode { get; set; }
        [InverseProperty("Document")]
        public virtual ICollection<Advertisement> Advertisement { get; set; }
        [InverseProperty(nameof(Category.ActiveIconDocument))]
        public virtual ICollection<Category> CategoryActiveIconDocument { get; set; }
        [InverseProperty(nameof(Category.CoverDocument))]
        public virtual ICollection<Category> CategoryCoverDocument { get; set; }
        [InverseProperty(nameof(Category.InactiveIconDocument))]
        public virtual ICollection<Category> CategoryInactiveIconDocument { get; set; }
        [InverseProperty(nameof(Category.QuadMenuDocument))]
        public virtual ICollection<Category> CategoryQuadMenuDocument { get; set; }
        [InverseProperty("Document")]
        public virtual ICollection<Post> Post { get; set; }
        [InverseProperty("ProfileDocument")]
        public virtual ICollection<User> User { get; set; }
    }
}
