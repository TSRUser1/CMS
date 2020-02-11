using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.EnterpriseLibrary.Data;

using Universal.X307.AppBase;

namespace BatchDataProcess
{
    class BatchDataProcessDA : AppBase
    {
        #region GetAllMember
        public BatchDataProcessDS GetAllMember()
        {
            BatchDataProcessDS resDS = new BatchDataProcessDS();
            try
            {
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetAllMember");

                #region Parameters Initialization
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.UserDetail.TableName);
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
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateMember");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_MemberID", DbType.Int32, inputRow.MemberID);
                db.AddInParameter(dbCommand, "b_Image", DbType.Binary, inputRow.BarCodeImage);
                db.AddInParameter(dbCommand, "n_ModifiedBy", DbType.Int32, 0);
                db.AddInParameter(dbCommand, "d_ModifiedDateTime", DbType.DateTime, GetLocalTime());
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.UserDetail.TableName);
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
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetAllColorCode");

                #region Parameters Initialization
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ColorCode.TableName);
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
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateColorCode");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_Id", DbType.Int32, inputRow.Id);
                db.AddInParameter(dbCommand, "b_ColorImage", DbType.Binary, inputRow.ColorImage);
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ColorCode.TableName);
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
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_S_GetAllZoneAccessColorCode");

                #region Parameters Initialization
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ColorCode.TableName);
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
                Database db = GetDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.SP_U_UpdateZoneAccessColorCode");

                #region Parameters Initialization
                db.AddInParameter(dbCommand, "n_Id", DbType.Int32, inputRow.Id);
                db.AddInParameter(dbCommand, "b_ColorImage", DbType.Binary, inputRow.ColorImage);
                #endregion

                db.LoadDataSet(dbCommand, resDS, resDS.ColorCode.TableName);
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
