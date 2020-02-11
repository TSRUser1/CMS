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
    public class AdmissionControlBF : AppBase
    {
        #region GetSingleAdminUser
        public AdmissionControlDS GetSingleAdminUser(AdmissionControlDS inputDS)
        {
            AdmissionControlDS resDS = new AdmissionControlDS();
            try
            {
                AdmissionControlDA da = new AdmissionControlDA();
                resDS = da.GetSingleAdminUser(inputDS.AdminUser[0]);
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
