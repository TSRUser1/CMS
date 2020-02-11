using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universal.X307.AppBase;

namespace AdmissionControl
{
    public class AdmissionControlDA : AppBase
    {
        #region GetSingleAdminUser
        public AdmissionControlDS GetSingleAdminUser(AdmissionControlDS.AdminUserRow inputRow)
        {
            AdmissionControlDS resDS = new AdmissionControlDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetSingleAdminUser");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_AdminUserID", DbType.Int32, inputRow.AdminUserID);
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.AdminUser.TableName);
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
