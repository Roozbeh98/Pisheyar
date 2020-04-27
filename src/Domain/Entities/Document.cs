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
            Post = new HashSet<Post>();
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
        [InverseProperty("Document")]
        public virtual ICollection<Post> Post { get; set; }
    }
}
