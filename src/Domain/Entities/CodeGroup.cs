using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class CodeGroup
    {
        public CodeGroup()
        {
            Code = new HashSet<Code>();
        }

        [Key]
        [Column("CodeGroupID")]
        public int CodeGroupId { get; set; }
        [Column("CodeGroupGUID")]
        public Guid CodeGroupGuid { get; set; }
        [StringLength(128)]
        public string Name { get; set; }
        [StringLength(128)]
        public string DisplayName { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("CodeGroup")]
        public virtual ICollection<Code> Code { get; set; }
    }
}
