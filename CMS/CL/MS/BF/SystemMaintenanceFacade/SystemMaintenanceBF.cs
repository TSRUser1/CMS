using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.CL.MS.DA.SystemMaintenanceDataAccess;
using SEM.CMS.CL.MS.DS.SystemMaintenanceDataset;

namespace SEM.CMS.CL.MS.BF.SystemMaintenanceFacade
{
    public class SystemMaintenanceBF : AppBase
    {
        string code = "", message = "";

        #region DeleteDataGridColumn
        public SystemMaintenanceDS DeleteDataGridColumn(SystemMaintenanceDS inputDS)
        {
            SystemMaintenanceDS resDS = new SystemMaintenanceDS();
            try
            {
                SystemMaintenanceDA da = new SystemMaintenanceDA();
                resDS = da.DeleteDataGridColumn(inputDS.DataGridColumn[0]);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetDataColumnByDataGridName
        public SystemMaintenanceDS GetDataColumnByDataGridName(string DataGridName)
        {
            SystemMaintenanceDS resDS = new SystemMaintenanceDS();
            try
            {
                SystemMaintenanceDA da = new SystemMaintenanceDA();
                resDS = da.GetDataColumnByDataGridName(DataGridName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetDataColumnList
        public SystemMaintenanceDS GetDataColumnList(string DataGridName)
        {
            SystemMaintenanceDS resDS = new SystemMaintenanceDS();
            try
            {
                SystemMaintenanceDA da = new SystemMaintenanceDA();
                resDS = da.GetDataColumnList(DataGridName);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetDataColumnName
        public SystemMaintenanceDS GetDataColumnName()
        {
            SystemMaintenanceDS resDS = new SystemMaintenanceDS();
            try
            {
                SystemMaintenanceDA da = new SystemMaintenanceDA();
                resDS = da.GetDataColumnName();
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region GetReferenceByReferenceCategoryID
        public SystemMaintenanceDS GetReferenceByReferenceCategoryID(SystemMaintenanceDS inputDS)
        {
            SystemMaintenanceDS resDS = new SystemMaintenanceDS();
            try
            {
                SystemMaintenanceDA da = new SystemMaintenanceDA();
                resDS = da.GetReferenceByReferenceCategoryID(inputDS.Reference[0]);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region InsertDataGridColumn
        public SystemMaintenanceDS InsertDataGridColumn(SystemMaintenanceDS inputDS)
        {
            SystemMaintenanceDS resDS = new SystemMaintenanceDS();
            try
            {
                SystemMaintenanceDA da = new SystemMaintenanceDA();
                resDS = da.InsertDataGridColumn(inputDS.DataGridColumn[0]);
            }
            catch (Exception ex)
            {
                BusinessErrorHandling(ex, GetCurrentMethod());
            }
            return resDS;
        }
        #endregion

        #region UpdateDataGridColumn
        public SystemMaintenanceDS UpdateDataGridColumn(SystemMaintenanceDS inputDS)
        {
            SystemMaintenanceDS resDS = new SystemMaintenanceDS();
            try
            {
                SystemMaintenanceDA da = new SystemMaintenanceDA();
                resDS = da.UpdateDataGridColumn(inputDS.DataGridColumn[0]);
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
