using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class City
    {
        public City()
        {
            Client = new HashSet<Client>();
            Contractor = new HashSet<Contractor>();
        }

        [Key]
        [Column("CityID")]
        public int CityId { get; set; }
        [Column("CityGUID")]
        public Guid CityGuid { get; set; }
        [Column("ProvinceID")]
        public int ProvinceId { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [ForeignKey(nameof(ProvinceId))]
        [InverseProperty("City")]
        public virtual Province Province { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<Client> Client { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<Contractor> Contractor { get; set; }
    }
}
