using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Universal.X307.AppBase;

namespace EmailService
{
    public class EmailServiceBF : AppBase
    {
        #region GetBulkEmail
        public EmailServiceDS GetBulkEmail(int maxRetryCount)
        {
            EmailServiceDS resDS = new EmailServiceDS();
            try
            {
                EmailServiceDA da = new EmailServiceDA();
                resDS = da.GetBulkEmail(maxRetryCount);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetEmailAttachment
        public EmailServiceDS GetEmailAttachment(int emailID)
        {
            EmailServiceDS resDS = new EmailServiceDS();
            try
            {
                EmailServiceDA da = new EmailServiceDA();
                resDS = da.GetEmailAttachment(emailID);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateEmailStatus
        public EmailServiceDS UpdateEmailStatus(EmailServiceDS inputDS)
        {
            EmailServiceDS resDS = new EmailServiceDS();
            try
            {
                EmailServiceDA da = new EmailServiceDA();
                resDS = da.UpdateEmailStatus(inputDS.Email[0]);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion
    }
}
