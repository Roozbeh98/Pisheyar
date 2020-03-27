using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            InverseCategoryCategoryGu = new HashSet<TblCategory>();
            TblCategoryTag = new HashSet<TblCategoryTag>();
            TblPostCategory = new HashSet<TblPostCategory>();
        }


        public Guid CategoryGuid { get; set; }

        public Guid? CategoryCategoryGuid { get; set; }

        public string CategoryDisplay { get; set; }

        public int CategoryOrder { get; set; }

        public DateTime CategoryCreateDate { get; set; }

        public DateTime CategoryModifyDate { get; set; }

        public bool CategoryIsDelete { get; set; }


        public virtual TblCategory CategoryCategoryGu { get; set; }

        public virtual ICollection<TblCategory> InverseCategoryCategoryGu { get; set; }

        public virtual ICollection<TblCategoryTag> TblCategoryTag { get; set; }

        public virtual ICollection<TblPostCategory> TblPostCategory { get; set; }
    }
}
