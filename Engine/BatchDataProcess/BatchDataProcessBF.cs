using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Universal.X307.AppBase;

namespace BatchDataProcess
{
    class BatchDataProcessBF : AppBase
    {
        #region GetAllMember
        public BatchDataProcessDS GetAllMember()
        {
            BatchDataProcessDS resDS = new BatchDataProcessDS();
            try
            {
                BatchDataProcessDA da = new BatchDataProcessDA();
                resDS = da.GetAllMember();
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion
        
        #region UpdateMember
        public BatchDataProcessDS UpdateMember(BatchDataProcessDS.UserDetailRow inputRow)
        {
            BatchDataProcessDS resDS = new BatchDataProcessDS();
            try
            {
                BatchDataProcessDA da = new BatchDataProcessDA();
                resDS = da.UpdateMember(inputRow);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetAllColorCode
        public BatchDataProcessDS GetAllColorCode()
        {
            BatchDataProcessDS resDS = new BatchDataProcessDS();
            try
            {
                BatchDataProcessDA da = new BatchDataProcessDA();
                resDS = da.GetAllColorCode();
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateColorCode
        public BatchDataProcessDS UpdateColorCode(BatchDataProcessDS.ColorCodeRow inputRow)
        {
            BatchDataProcessDS resDS = new BatchDataProcessDS();
            try
            {
                BatchDataProcessDA da = new BatchDataProcessDA();
                resDS = da.UpdateColorCode(inputRow);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetAllZoneAccessColorCode
        public BatchDataProcessDS GetAllZoneAccessColorCode()
        {
            BatchDataProcessDS resDS = new BatchDataProcessDS();
            try
            {
                BatchDataProcessDA da = new BatchDataProcessDA();
                resDS = da.GetAllZoneAccessColorCode();
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateZoneAccessColorCode
        public BatchDataProcessDS UpdateZoneAccessColorCode(BatchDataProcessDS.ColorCodeRow inputRow)
        {
            BatchDataProcessDS resDS = new BatchDataProcessDS();
            try
            {
                BatchDataProcessDA da = new BatchDataProcessDA();
                resDS = da.UpdateZoneAccessColorCode(inputRow);
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
