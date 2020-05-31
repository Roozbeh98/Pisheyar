using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class ContractorCategory
    {
        [Key]
        [Column("ContractorCategoryID")]
        public int ContractorCategoryId { get; set; }
        [Column("ContractorCategoryGUID")]
        public Guid ContractorCategoryGuid { get; set; }
        [Column("ContractorID")]
        public int ContractorId { get; set; }
        [Column("CategoryID")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("ContractorCategory")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(ContractorId))]
        [InverseProperty("ContractorCategory")]
        public virtual Contractor Contractor { get; set; }
    }
}
