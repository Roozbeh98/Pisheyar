using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblSmsresponse
    {
        public int SmsId { get; set; }

        public Guid SmsGuid { get; set; }

        public int? SmsUserId { get; set; }

        public int? SmsStid { get; set; }

        public int SmsStatus { get; set; }

        public string SmsStatusText { get; set; }

        public string SmsMessage { get; set; }

        public string SmsToken { get; set; }

        public string SmsToken1 { get; set; }

        public string SmsToken2 { get; set; }

        public string SmsSender { get; set; }

        public string SmsReceptor { get; set; }

        public DateTime SmsDate { get; set; }

        public int SmsCost { get; set; }

        public DateTime SmsCreateDate { get; set; }

        public DateTime SmsModifyDate { get; set; }

        public bool SmsIsDelete { get; set; }


        public virtual TblSmstemplate SmsSt { get; set; }

        public virtual TblUser SmsUser { get; set; }
    }
}
