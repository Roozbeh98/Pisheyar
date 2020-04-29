using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class Province
    {
        public Province()
        {
            City = new HashSet<City>();
        }

        [Key]
        [Column("ProvinceID")]
        public int ProvinceId { get; set; }
        [Column("ProvinceGUID")]
        public Guid ProvinceGuid { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [InverseProperty("Province")]
        public virtual ICollection<City> City { get; set; }
    }
}
