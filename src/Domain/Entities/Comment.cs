using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class Comment
    {
        public Comment()
        {
            PostComment = new HashSet<PostComment>();
        }

        [Key]
        [Column("CommentID")]
        public int CommentId { get; set; }
        [Column("CommentGUID")]
        public Guid CommentGuid { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Required]
        public string Message { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Comment")]
        public virtual User User { get; set; }
        [InverseProperty("Comment")]
        public virtual ICollection<PostComment> PostComment { get; set; }
    }
}
