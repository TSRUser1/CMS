using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.EnterpriseLibrary.Data;

using Universal.X307.AppBase;

namespace EmailService
{
    public class EmailServiceDA : AppBase
    {
        #region GetBulkEmail
        public EmailServiceDS GetBulkEmail(int maxRetryCount)
        {
            EmailServiceDS resDS = new EmailServiceDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetBulkEmail");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_maxRetryCount", DbType.Int32, maxRetryCount);
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Email.TableName);
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
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetEmailAttachment");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_EmailID", DbType.Int32, emailID);
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.EmailAttachment.TableName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateEmailStatus
        public EmailServiceDS UpdateEmailStatus(EmailServiceDS.EmailRow inputRow)
        {
            EmailServiceDS resDS = new EmailServiceDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateEmailStatus");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_EmailID", DbType.Int32, inputRow.EmailID);
                db.AddInParameter(dbCommand, "n_StatusCode", DbType.Int32, inputRow.EmailStatus);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, 0);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.Email.TableName);
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
