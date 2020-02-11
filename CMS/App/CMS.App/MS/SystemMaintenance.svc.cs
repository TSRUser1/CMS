using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.CL.MS.BF.SystemMaintenanceFacade;
using SEM.CMS.CL.MS.DS.SystemMaintenanceDataset;

namespace SEM.CMS.App.MS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SystemMaintenance" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SystemMaintenance.svc or SystemMaintenance.svc.cs at the Solution Explorer and start debugging.
    public class SystemMaintenance : ISystemMaintenance
    {
        public SystemMaintenanceDS DeleteDataGridColumn(SystemMaintenanceDS inputDS)
        {
            AppBase.WCFAuthentication();
            SystemMaintenanceBF bf = new SystemMaintenanceBF();
            SystemMaintenanceDS ds = new SystemMaintenanceDS();
            ds = bf.DeleteDataGridColumn(inputDS);
            return ds;
        }

        public SystemMaintenanceDS GetDataColumnByDataGridName(string DataGridName)
        {
            AppBase.WCFAuthentication();
            SystemMaintenanceBF bf = new SystemMaintenanceBF();
            SystemMaintenanceDS ds = new SystemMaintenanceDS();
            ds = bf.GetDataColumnByDataGridName(DataGridName);
            return ds;
        }

        public SystemMaintenanceDS GetDataColumnList(string DataGridName)
        {
            AppBase.WCFAuthentication();
            SystemMaintenanceBF bf = new SystemMaintenanceBF();
            SystemMaintenanceDS ds = new SystemMaintenanceDS();
            ds = bf.GetDataColumnList(DataGridName);
            return ds;
        }

        public SystemMaintenanceDS GetDataColumnName()
        {
            AppBase.WCFAuthentication();
            SystemMaintenanceBF bf = new SystemMaintenanceBF();
            SystemMaintenanceDS ds = new SystemMaintenanceDS();
            ds = bf.GetDataColumnName();
            return ds;
        }

        public SystemMaintenanceDS GetReferenceByReferenceCategoryID(SystemMaintenanceDS inputDS)
        {
            AppBase.WCFAuthentication();
            SystemMaintenanceBF bf = new SystemMaintenanceBF();
            SystemMaintenanceDS ds = new SystemMaintenanceDS();
            ds = bf.GetReferenceByReferenceCategoryID(inputDS);
            return ds;
        }

        public SystemMaintenanceDS InsertDataGridColumn(SystemMaintenanceDS inputDS)
        {
            AppBase.WCFAuthentication();
            SystemMaintenanceBF bf = new SystemMaintenanceBF();
            SystemMaintenanceDS ds = new SystemMaintenanceDS();
            ds = bf.InsertDataGridColumn(inputDS);
            return ds;
        }

        public SystemMaintenanceDS UpdateDataGridColumn(SystemMaintenanceDS inputDS)
        {
            AppBase.WCFAuthentication();
            SystemMaintenanceBF bf = new SystemMaintenanceBF();
            SystemMaintenanceDS ds = new SystemMaintenanceDS();
            ds = bf.UpdateDataGridColumn(inputDS);
            return ds;
        }
    }
}
