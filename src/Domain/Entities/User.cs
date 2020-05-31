using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            Admin = new HashSet<Admin>();
            ChatMessage = new HashSet<ChatMessage>();
            Client = new HashSet<Client>();
            Comment = new HashSet<Comment>();
            Contractor = new HashSet<Contractor>();
            Post = new HashSet<Post>();
            SmsResponse = new HashSet<SmsResponse>();
            Token = new HashSet<Token>();
            UserPermission = new HashSet<UserPermission>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [Column("UserGUID")]
        public Guid UserGuid { get; set; }
        [Column("RoleID")]
        public int RoleId { get; set; }
        [Column("GenderCodeID")]
        public int? GenderCodeId { get; set; }
        [Column("ProfileDocumentID")]
        public int? ProfileDocumentId { get; set; }
        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(128)]
        public string LastName { get; set; }
        [StringLength(128)]
        public string Email { get; set; }
        [Required]
        [StringLength(128)]
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsRegister { get; set; }
        public bool IsDelete { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(GenderCodeId))]
        [InverseProperty(nameof(Code.User))]
        public virtual Code GenderCode { get; set; }
        [ForeignKey(nameof(ProfileDocumentId))]
        [InverseProperty(nameof(Document.User))]
        public virtual Document ProfileDocument { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty("User")]
        public virtual Role Role { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Admin> Admin { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ChatMessage> ChatMessage { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Client> Client { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Comment> Comment { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Contractor> Contractor { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Post> Post { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<SmsResponse> SmsResponse { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Token> Token { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserPermission> UserPermission { get; set; }
    }
}
