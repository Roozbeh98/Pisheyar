using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class Post
    {
        public Post()
        {
            PostCategory = new HashSet<PostCategory>();
            PostComment = new HashSet<PostComment>();
            PostTag = new HashSet<PostTag>();
        }

        [Key]
        [Column("PostID")]
        public int PostId { get; set; }
        [Column("PostGUID")]
        public Guid PostGuid { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Column("DocumentID")]
        public int DocumentId { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Abstract { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsShow { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(DocumentId))]
        [InverseProperty("Post")]
        public virtual Document Document { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Post")]
        public virtual User User { get; set; }
        [InverseProperty("Post")]
        public virtual ICollection<PostCategory> PostCategory { get; set; }
        [InverseProperty("Post")]
        public virtual ICollection<PostComment> PostComment { get; set; }
        [InverseProperty("Post")]
        public virtual ICollection<PostTag> PostTag { get; set; }
    }
}
