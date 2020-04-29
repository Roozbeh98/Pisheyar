﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class Code
    {
        public Code()
        {
            Document = new HashSet<Document>();
            Order = new HashSet<Order>();
            Transaction = new HashSet<Transaction>();
        }

        [Key]
        [Column("CodeID")]
        public int CodeId { get; set; }
        [Column("CodeGUID")]
        public Guid CodeGuid { get; set; }
        [Column("CodeGroupID")]
        public int CodeGroupId { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        [StringLength(128)]
        public string DisplayName { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(CodeGroupId))]
        [InverseProperty("Code")]
        public virtual CodeGroup CodeGroup { get; set; }
        [InverseProperty("TypeCode")]
        public virtual ICollection<Document> Document { get; set; }
        [InverseProperty("StateCode")]
        public virtual ICollection<Order> Order { get; set; }
        [InverseProperty("TypeCode")]
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}