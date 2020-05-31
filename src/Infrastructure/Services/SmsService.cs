using Kavenegar;
using Kavenegar.Core.Models;
using Kavenegar.Core.Exceptions;
using Pisheyar.Application.Common.Interfaces;
using Pisheyar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kavenegar.Core.Models.Enums;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Pisheyar.Infrastructure.Services
{
    [Authorize]
    public class SmsService : ISmsService
    {
        private readonly IPisheyarContext _context;
        private readonly string apikey;

        public SmsService(IPisheyarContext context)
        {
            _context = context;
            apikey = _context.SmsProviderConfiguration.FirstOrDefault().Apikey;
        }

        private string GetSmsTemplateName(SmsTemplate template)
        {
            return _context.SmsTemplate.Where(x => x.SmsTemplateId == (int)template).FirstOrDefault().Name;
        }

        //private bool InsertIntoDB(SendResult result, string token, string token1, string token2)
        //{
        //    if (result != null)
        //    {
        //        Tbl_SMSResponse _SMSResponse = new Tbl_SMSResponse()
        //        {
        //            SMS_Guid = Guid.NewGuid(),
        //            SMS_Status = result.Status,
        //            SMS_StatusText = result.StatusText,
        //            SMS_MessageID = result.Messageid.ToString(),
        //            SMS_Message = result.Message,
        //            SMS_Token = token,
        //            SMS_Token1 = token1,
        //            SMS_Token2 = token2,
        //            SMS_Sender = result.Sender,
        //            SMS_Receptor = result.Receptor,
        //            SMS_Date = DateConverter.UnixTimeStampToDateTime(result.Date),
        //            SMS_Cost = result.Cost,
        //            SMS_CreationDate = DateTime.Now,
        //            SMS_ModifiedDate = DateTime.Now
        //        };

        //        db.Tbl_SMSResponse.Add(_SMSResponse);

        //        if (Convert.ToBoolean(db.SaveChanges() > 0))
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        //private bool InsertIntoDB(SendResult result)
        //{
        //    if (result != null)
        //    {
        //        Tbl_SMSResponse _SMSResponse = new Tbl_SMSResponse()
        //        {
        //            SMS_Guid = Guid.NewGuid(),
        //            SMS_Status = result.Status,
        //            SMS_StatusText = result.StatusText,
        //            SMS_MessageID = result.Messageid.ToString(),
        //            SMS_Message = result.Message,
        //            SMS_Sender = result.Sender,
        //            SMS_Receptor = result.Receptor,
        //            SMS_Date = DateConverter.UnixTimeStampToDateTime(result.Date),
        //            SMS_Cost = result.Cost,
        //            SMS_CreationDate = DateTime.Now,
        //            SMS_ModifiedDate = DateTime.Now
        //        };

        //        db.Tbl_SMSResponse.Add(_SMSResponse);

        //        if (Convert.ToBoolean(db.SaveChanges() > 0))
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        public async Task<object> SendServiceable(SmsTemplate template, string receptor, string token = "", string token2 = "", string token3 = "", string token10 = "", string token20 = "")
        {
            try
            {
                var api = new KavenegarApi(apikey);
                SendResult result = await api.VerifyLookup(receptor, token, token2, token3, token10, token20, GetSmsTemplateName(template), VerifyLookupType.Sms);

                //InsertIntoDB(result, token, token2, token3);

                return result;
            }
            catch (ApiException ex)
            {
                return ex.Message;
            }
            catch (HttpException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> SendAdvertising(string sender, string receptor, string message)
        {
            try
            {
                var api = new KavenegarApi(apikey);
                SendResult result = await api.Send(sender, receptor, message);

                //InsertIntoDB(result);

                return result;
            }
            catch (ApiException ex)
            {
                return ex.Message;
            }
            catch (HttpException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
