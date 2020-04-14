using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblDocument
    {
        public TblDocument()
        {
            TblAdvertisement = new HashSet<TblAdvertisement>();
            TblPost = new HashSet<TblPost>();
        }


        public Guid DocumentGuid { get; set; }

        public int DocumentTypeCodeId { get; set; }

        public string DocumentPath { get; set; }

        public string DocumentSize { get; set; }

        public string DocumentFileName { get; set; }

        public DateTime DocumentCreateDate { get; set; }

        public DateTime DocumentModifyDate { get; set; }

        public bool DocumentIsDelete { get; set; }


        public virtual TblCode DocumentTypeCode { get; set; }

        public virtual ICollection<TblAdvertisement> TblAdvertisement { get; set; }

        public virtual ICollection<TblPost> TblPost { get; set; }
    }
}
