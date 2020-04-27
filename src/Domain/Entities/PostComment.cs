using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class PostComment
    {
        [Key]
        [Column("PostCommentID")]
        public int PostCommentId { get; set; }
        [Column("PostCommentGUID")]
        public Guid PostCommentGuid { get; set; }
        [Column("CommentID")]
        public int CommentId { get; set; }
        [Column("PostID")]
        public int PostId { get; set; }
        [Required]
        public bool IsAccept { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(CommentId))]
        [InverseProperty("PostComment")]
        public virtual Comment Comment { get; set; }
        [ForeignKey(nameof(PostId))]
        [InverseProperty("PostComment")]
        public virtual Post Post { get; set; }
    }
}
