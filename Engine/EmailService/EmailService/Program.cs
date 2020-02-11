using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Universal.X307.AppBase;

namespace EmailService
{
    public class Program : AppBase
    {
        static void Main(string[] args)
        {
            EmailServiceBF bf = new EmailServiceBF();
            int maxRetryCount = Convert.ToInt32(ConfigurationManager.AppSettings[AS_DEFAULTRETRYCOUNT]);

            if (args.Length > 0)
            {
                if (!int.TryParse(args[0], out maxRetryCount))
                {
                    maxRetryCount = 5;
                }
            }

            EmailServiceDS resDS = bf.GetBulkEmail(maxRetryCount);

            foreach (EmailServiceDS.EmailRow row in resDS.Email)
            {
                string attachmentList = string.Empty;
                EmailServiceDS attachmentDS = bf.GetEmailAttachment(row.EmailID);

                foreach (EmailServiceDS.EmailAttachmentRow attachmentRow in attachmentDS.EmailAttachment)
                {
                    attachmentList += attachmentRow + ",";
                }

                SmtpStatusCode returnCode = bf.SendEmail(row.ReceiverEmail, row.ReceiverEmail_BCC, row.ReceiverEmail_CC, row.EmailSubject, row.EmailContent, attachmentList);

                EmailServiceDS requestDS = new EmailServiceDS();
                EmailServiceDS.EmailRow requestRow = requestDS.Email.NewEmailRow();

                requestRow.EmailID = row.EmailID;
                requestRow.EmailStatus = (uint)returnCode;
                requestDS.Email.AddEmailRow(requestRow);

                bf.UpdateEmailStatus(requestDS);
            }
        }
    }
}
