using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class Code
    {
        public Code()
        {
            ContactUs = new HashSet<ContactUs>();
            Contractor = new HashSet<Contractor>();
            Document = new HashSet<Document>();
            Order = new HashSet<Order>();
            Token = new HashSet<Token>();
            Transaction = new HashSet<Transaction>();
            User = new HashSet<User>();
        }

        [Key]
        [Column("CodeID")]
        public int CodeId { get; set; }
        [Column("CodeGUID")]
        public Guid CodeGuid { get; set; }
        [Column("CodeGroupID")]
        public int CodeGroupId { get; set; }
        [StringLength(128)]
        public string Name { get; set; }
        [StringLength(128)]
        public string DisplayName { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(CodeGroupId))]
        [InverseProperty("Code")]
        public virtual CodeGroup CodeGroup { get; set; }
        [InverseProperty("ContactUsBusinessTypeCode")]
        public virtual ICollection<ContactUs> ContactUs { get; set; }
        [InverseProperty("BusinessTypeCode")]
        public virtual ICollection<Contractor> Contractor { get; set; }
        [InverseProperty("TypeCode")]
        public virtual ICollection<Document> Document { get; set; }
        [InverseProperty("StateCode")]
        public virtual ICollection<Order> Order { get; set; }
        [InverseProperty("RoleCode")]
        public virtual ICollection<Token> Token { get; set; }
        [InverseProperty("TypeCode")]
        public virtual ICollection<Transaction> Transaction { get; set; }
        [InverseProperty("GenderCode")]
        public virtual ICollection<User> User { get; set; }
    }
}
