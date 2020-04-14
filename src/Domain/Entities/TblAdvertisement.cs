using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblAdvertisement
    {
        public int AdvertisementId { get; set; }

        public Guid AdvertisementGuid { get; set; }

        public Guid AdvertisementDocumentGuid { get; set; }

        public string AdvertisementTitle { get; set; }

        public string AdvertisementAbstract { get; set; }

        public string AvertisementPicture { get; set; }

        public DateTime AdvertisementCreateDate { get; set; }

        public DateTime AdvertisementModifyDate { get; set; }

        public bool AdvertisementIsShow { get; set; }

        public bool AdvertisementIsDelete { get; set; }


        public virtual TblDocument AdvertisementDocument { get; set; }
    }
}
